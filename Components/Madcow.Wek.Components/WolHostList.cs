/*

WeK - A magic packet Wake On LAN Utility for Microsoft Windows.
Copyright © 2009 Chris Dickson

WeK is free software; you can redistribute it and/or modify 
it under the terms of the GNU General Public License as 
published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

WeK is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

*/

#region Using Statements

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.XPath;

using Madcow.ComponentModel;
using Madcow.Network.Management;

#endregion

namespace Madcow.Wek.Components
{
    /// <summary>
    /// 
    /// </summary>
    public class WolHostList
    {
        #region Private Members

        private ObservableHostList _hosts;
        private WolHostGroupCollection _groups;

        private bool _modified;
        private bool _converting;
        private bool _appDataLocationExists;
        private string _listVersion;

        private string ApplicationDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WeK");
        private const string DefaultWolHostsFilename = "wekhosts.xml";

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of a WolHostList object.
        /// </summary>
        public WolHostList()
        {
            _hosts = new ObservableHostList();
            _hosts.ListChanged += new EventHandler(delegate(object sender, EventArgs e) { _modified = true; });

            _modified = false;

            _appDataLocationExists = Directory.Exists(ApplicationDataPath);

            if (_appDataLocationExists == false)
            {
                Directory.CreateDirectory(ApplicationDataPath);
                _appDataLocationExists = true;
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a flag indicating whether the format of the configuration has been converted.
        /// </summary>
        public bool Converting
        {
            get { return _converting; }
        }

        /// <summary>
        /// The collection of hosts.
        /// </summary>
        public ICollection<WolHost> Items
        {
            get { return _hosts; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ListVersion
        {
            get { return _listVersion; }
        }

        /// <summary>
        /// Gets or sets a flag that indicates whether the list has changed.
        /// </summary>
        public bool Modified
        {
            get { return _modified; }
            private set { _modified = value; }
        }

        /// <summary>
        /// Indexer to allow access to a specific WolHost at a given position in the host collection.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public WolHost this[int index]
        {
            get { return _hosts[index]; }
            set { _hosts[index] = value; }
        }

        /// <summary>
        /// Gets the collection of Host Groups that are currently defined.
        /// </summary>
        public WolHostGroupCollection HostGroups
        {
            get
            {
                if (_groups == null)
                {
                    _groups = new WolHostGroupCollection();
                }

                return _groups;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Saves the current host configuration to disk with the default filename.
        /// </summary>
        /// <returns>True if the configuration file was saved successfully.</returns>
        public bool Save()
        {
            return Save(Path.Combine(ApplicationDataPath, DefaultWolHostsFilename));
        }

        /// <summary>
        /// Saves the current host configuration to disk with the given filename.
        /// </summary>
        /// <param name="pathName">The name and path of the file in which the configuration will be saved.</param>
        /// <returns>True if the configuration file was saved successfully.</returns>
        public bool Save(string pathName)
        {
            bool Success = true;

            if (_appDataLocationExists)
            {
                // Get the base filename with which to save the file so that a temporary file can
                // be created first.
                string TempFilename = Path.ChangeExtension(pathName, "bak");

                try
                {
                    // Move any current configuration to the temporary name.
                    if (File.Exists(pathName))
                    {
                        File.Move(pathName, TempFilename);
                    }

                    // Persist the XML.
                    XmlWriterSettings WriterSettings = new XmlWriterSettings();
                    WriterSettings.Indent = true;
                    WriterSettings.NewLineHandling = NewLineHandling.Entitize;
                    WriterSettings.OmitXmlDeclaration = false;
                    WriterSettings.ConformanceLevel = ConformanceLevel.Document;
                    WriterSettings.CloseOutput = true;

                    using (XmlWriter HostsWriter = XmlWriter.Create(pathName, WriterSettings))
                    {
                        HostsWriter.WriteStartDocument();
                        HostsWriter.WriteStartElement("wekHosts");
                        HostsWriter.WriteAttributeString("version", "2.0");

                        // Write the hosts node.
                        HostsWriter.WriteStartElement("hosts");

                        foreach (WolHost CurrentHost in _hosts)
                        {
                            PersistHost(HostsWriter, CurrentHost);
                        }

                        HostsWriter.WriteEndElement();

                        // Write the groups node.
                        // TODO: Add group handling when UI has been completed.
                        HostsWriter.WriteStartElement("groups");
                        HostsWriter.WriteStartElement("group");
                        HostsWriter.WriteAttributeString("name", "_default");

                        foreach (WolHost CurrentHost in _hosts)
                        {
                            HostsWriter.WriteElementString("groupMember", CurrentHost.Id.ToString());
                        }

                        HostsWriter.WriteEndElement();
                        HostsWriter.WriteEndElement();

                        HostsWriter.WriteEndElement();
                    }

                    // Delete the old configuration. Use the fact that an exception is not thrown if
                    // the file doesn't exist to keep the code simple.
                    File.Delete(TempFilename);
                }
                catch (Exception)
                {
                    // Attempt to restore the old configuration file.
                    File.Delete(pathName);

                    try
                    {
                        File.Move(TempFilename, pathName);
                    }
                    catch
                    {
                    }

#if DEBUG
                    throw;
#else
                    Success = false;
#endif
                }
            }

            return Success;
        }

        /// <summary>
        /// Loads the host configuration from disk using the default host configuration filename.
        /// </summary>
        /// <returns>True if the file was loaded successfully.</returns>
        public bool Load()
        {
            return Load(Path.Combine(ApplicationDataPath, DefaultWolHostsFilename));
        }

        /// <summary>
        /// Loads the host configuration from disk using the given filename.
        /// </summary>
        /// <param name="pathName">The name and path of the host configuration file to load.</param>
        /// <returns>True if the file was loaded successfully.</returns>
        public bool Load(string pathName)
        {
            bool Success = true;

            if (_appDataLocationExists)
            {
                _hosts.Clear();
                _modified = false;

                try
                {
                    // Load the configuration file into an XPathDocument.
                    XPathDocument HostsDocument = new XPathDocument(pathName);
                    XPathNavigator HostsNavigator = HostsDocument.CreateNavigator();

                    // Get the version of the file to decide how to continue the processing.
                    XPathNavigator HostsVersionNavigator = HostsNavigator.SelectSingleNode("//wekHosts");
                    if (HostsVersionNavigator != null)
                    {
                        _listVersion = HostsVersionNavigator.GetAttribute("version", String.Empty);
                        switch (_listVersion)
                        {
                            case "1.0":
                                _converting = true;
                                LoadVersionOneXml(HostsVersionNavigator);
                                break;

                            case "2.0":
                                LoadVersionTwoXml(HostsVersionNavigator);
                                break;

                            default:
                                throw new InvalidDataException("Unsupported hosts file format version.");
                        }
                    }
                    else
                    {
                        Success = false;
                    }

                    _modified = false;
                }
                catch (XmlException)
                {
                    Success = false;
                }
                catch (FileNotFoundException)
                {
                    Success = false;
                }
                catch (Exception)
                {
                    Success = false;
                    throw;
                }
            }

            return Success;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Loads a WeK Hosts File defined with version 1.0 format.
        /// </summary>
        /// <param name="hostsNavigator"></param>
        private void LoadVersionOneXml(XPathNavigator hostsNavigator)
        {
            XPathNodeIterator HostNodes = hostsNavigator.Select("//wekHosts/host");
            while(HostNodes.MoveNext())
            {
                // Create a new object for the host that is about to be read in.
                WolHost NewHost = new WolHost();

                // Add a new network and set those properties that are completely new
                // in the version 2 XML schemata.
                WolHostNetwork NewNetwork = new WolHostNetwork();
                NewNetwork.NetworkId = Guid.NewGuid();
                NewNetwork.Name = "New Network";
                NewNetwork.Locality = WolHostNetwork.NetworkLocality.LocalSubnet;
                NewNetwork.SubnetMask = IPAddress.None;
                NewHost.Networks.Add(NewNetwork);

                SetHostPropertiesFromXml(NewHost, HostNodes.Current);

                // Process the child nodes of the host item.
                XPathNodeIterator CurrentHostIterator = HostNodes.Current.SelectChildren(XPathNodeType.Element);
                while (CurrentHostIterator.MoveNext())
                {
                    SetHostPropertiesFromXml(NewHost, CurrentHostIterator.Current);
                }

                _hosts.Add(NewHost);
            }
        }

        /// <summary>
        /// Loads a WeK Hosts File defined with version 2.0 format.
        /// </summary>
        /// <param name="hostsNavigator"></param>
        private void LoadVersionTwoXml(XPathNavigator hostsNavigator)
        {
            // Load the hosts.
            XPathNodeIterator HostNodes = hostsNavigator.Select("//wekHosts/hosts/host");
            while (HostNodes.MoveNext())
            {
                WolHost NewHost = new WolHost();

                SetHostPropertiesFromXml(NewHost, HostNodes.Current);

                // Process child nodes of the host item.
                XPathNodeIterator CurrentHostIterator = HostNodes.Current.SelectChildren(XPathNodeType.Element);
                while (CurrentHostIterator.MoveNext())
                {
                    SetHostPropertiesFromXml(NewHost, CurrentHostIterator.Current);
                }

                // Ensure that there is a default network indicated if not set in the WekHosts file.
                if (NewHost.DefaultNetwork == Guid.Empty && NewHost.Networks.Count > 0)
                {
                    NewHost.DefaultNetwork = NewHost.Networks[0].NetworkId;
                }

                this.Items.Add(NewHost);
            }

            // Load the groups and resolve their membership.
            XPathNodeIterator GroupNodes = hostsNavigator.Select("//wekHosts/groups/group");
            while (GroupNodes.MoveNext())
            {
                WolHostGroup NewGroup = new WolHostGroup();

                if (GroupNodes.Current.HasAttributes)
                {
                    NewGroup.Name = GroupNodes.Current.GetAttribute("name", String.Empty);
                }
                else
                {
                    NewGroup.Name = "_default";
                }

                XPathNodeIterator GroupMemberIterator = GroupNodes.Current.SelectChildren(XPathNodeType.Element);
                while (GroupMemberIterator.MoveNext())
                {
                    switch (GroupMemberIterator.Current.Name)
                    {
                        case "memberHost":
                            WolHost Member = _hosts.Find(delegate(WolHost Host)
                                                         {
                                                             return Host.Id.Equals(new Guid(GroupMemberIterator.Current.Value));
                                                         });

                            if (Member != null)
                            {
                                // Set the preferred network for the host when part of the group. The presence of
                                // the default network Id does not guarantee that the network exists for the host.
                                string DefaultNetworkId = null;
                                if (GroupMemberIterator.Current.HasAttributes)
                                {
                                    DefaultNetworkId = GroupMemberIterator.Current.GetAttribute("defaultNetwork", String.Empty);
                                    if (String.IsNullOrEmpty(DefaultNetworkId) == false)
                                    {
                                        NewGroup.Add(new WolHostGroupMember(Member, new Guid(DefaultNetworkId)));
                                    }
                                }

                                if (String.IsNullOrEmpty(DefaultNetworkId) == false)
                                {
                                    NewGroup.Add(new WolHostGroupMember(Member, new Guid(DefaultNetworkId)));
                                }
                                else
                                {
                                    NewGroup.Add(new WolHostGroupMember(Member));
                                }
                            }

                            break;
                    }
                }

                this.HostGroups.Add(NewGroup);
            }
        }

        /// <summary>
        /// Writes the configuration data for a WolHost into XML format for storage in a file.
        /// </summary>
        /// <param name="writer">An open XML Writer to which the XML will be written.</param>
        /// <param name="host">The WolHost to be persisted.</param>
        private void PersistHost(XmlWriter writer, WolHost host)
        {
            writer.WriteStartElement("host");
            writer.WriteAttributeString("id", host.Id.ToString());

            if (host.RequireSecureOn)
            {
                writer.WriteAttributeString("secureOn", "true");
            }

            if (host.DefaultNetwork != Guid.Empty)
            {
                writer.WriteAttributeString("defaultNetwork", host.DefaultNetwork.ToString());
            }

            writer.WriteElementString("name", host.Name);
            writer.WriteElementString("owner", host.Owner);
            writer.WriteElementString("physicalAddress", host.MachineAddress.ToString("C", null));
            writer.WriteElementString("description", host.Description);
            writer.WriteElementString("secureOnPassword", (host.RequireSecureOn ? host.SecureOnPassword.ToString("C", null) : null));

            writer.WriteStartElement("networks");

            foreach (WolHostNetwork CurrentNetwork in host.Networks)
            {
                writer.WriteStartElement("network");
                writer.WriteAttributeString("id", CurrentNetwork.NetworkId.ToString());
                writer.WriteElementString("name", CurrentNetwork.Name);
                writer.WriteElementString("locality", CurrentNetwork.Locality.ToString());
                writer.WriteElementString("address", CurrentNetwork.Address);
                writer.WriteElementString("subnetMask", (CurrentNetwork.SubnetMask == IPAddress.None ? null : CurrentNetwork.SubnetMask.ToString()));
                writer.WriteElementString("port", CurrentNetwork.Port.ToString());
                writer.WriteEndElement();
            }

            writer.WriteEndElement();

            writer.WriteEndElement();
        }

        /// <summary>
        /// Updates a WolHostNetwork instance with settings from persisted XML configuration data.
        /// </summary>
        /// <param name="network"></param>
        /// <param name="networkNodeNavigator"></param>
        private void SetNetworkPropertiesFromXml(WolHostNetwork network, XPathNavigator networkNodeNavigator)
        {
            if (networkNodeNavigator.HasAttributes)
            {
                string NetworkId = networkNodeNavigator.GetAttribute("id", String.Empty);
                if (String.IsNullOrEmpty(NetworkId) == false)
                {
                    network.NetworkId = new Guid(NetworkId);
                }
                else
                {
                    throw new InvalidDataException("Host network cannot be defined without a Network Id.");
                }
            }

            XPathNodeIterator NetworkNodeIterator = networkNodeNavigator.SelectDescendants(XPathNodeType.Element, false);
            while (NetworkNodeIterator.MoveNext())
            {
                switch (NetworkNodeIterator.Current.Name)
                {
                    case "address":
                        network.Address = NetworkNodeIterator.Current.Value;
                        break;

                    case "locality":
                        if (String.IsNullOrEmpty(NetworkNodeIterator.Current.Value) == false)
                        {
                            network.Locality = (WolHostNetwork.NetworkLocality)Enum.Parse(typeof(WolHostNetwork.NetworkLocality),
                                                                                          NetworkNodeIterator.Current.Value);
                        }
                        else
                        {
                            network.Locality = WolHostNetwork.NetworkLocality.LocalSubnet;
                        }
                        break;

                    case "name":
                        network.Name = NetworkNodeIterator.Current.Value;
                        break;

                    case "port":
                        int HostPort;
                        if (Int32.TryParse(NetworkNodeIterator.Current.Value, out HostPort))
                        {
                            network.Port = HostPort;
                        }
                        else
                        {
                            network.Port = 0;
                        }
                        break;

                    case "subnetMask":
                        IPAddress PersistedMask;
                        if (IPAddress.TryParse(NetworkNodeIterator.Current.Value, out PersistedMask))
                        {
                            network.SubnetMask = PersistedMask;
                        }
                        else
                        {
                            network.SubnetMask = IPAddress.None;
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Updates a WolHost instance with settings from persisted XML configuration data.
        /// </summary>
        /// <param name="host"></param>
        /// <param name="hostNodeNavigator"></param>
        private void SetHostPropertiesFromXml(WolHost host, XPathNavigator hostNodeNavigator)
        {
            PhysicalAddress ParsedAddress;

            switch (hostNodeNavigator.Name)
            {
                case "host":
                    if (hostNodeNavigator.HasAttributes)
                    {
                        string SecureOnAttribute = hostNodeNavigator.GetAttribute("secureOn", String.Empty);
                        host.RequireSecureOn = (String.IsNullOrEmpty(SecureOnAttribute) ? false : SecureOnAttribute.Equals("true", StringComparison.InvariantCultureIgnoreCase));

                        string HostId = hostNodeNavigator.GetAttribute("id", String.Empty);
                        host.Id = String.IsNullOrEmpty(HostId) ? Guid.NewGuid() : new Guid(HostId);

                        string DefaultNetworkId = hostNodeNavigator.GetAttribute("defaultNetwork", String.Empty);
                        host.DefaultNetwork = String.IsNullOrEmpty(DefaultNetworkId) ? Guid.Empty : new Guid(DefaultNetworkId);
                    }
                    else
                    {
                        host.RequireSecureOn = false;
                    }

                    break;

                case "networks":
                    // Process the networks.
                    XPathNodeIterator NetworksIterator = hostNodeNavigator.Select("network");
                    while (NetworksIterator.MoveNext())
                    {
                        WolHostNetwork NewNetwork = new WolHostNetwork();
                        SetNetworkPropertiesFromXml(NewNetwork, NetworksIterator.Current);
                        
                        host.Networks.Add(NewNetwork);
                    }

                    break;

                case "name":
                    host.Name = hostNodeNavigator.Value;
                    break;

                case "description":
                    host.Description = hostNodeNavigator.Value;
                    break;

                case "physicalAddress":
                    if (PhysicalAddress.TryParse(hostNodeNavigator.Value, out ParsedAddress))
                    {
                        host.MachineAddress = ParsedAddress;
                    }
                    break;

                case "hostAddress":
                    host.Networks[0].Address = hostNodeNavigator.Value;
                    break;

                case "hostPort":
                    int HostPort;
                    if (Int32.TryParse(hostNodeNavigator.Value, out HostPort))
                    {
                        host.Networks[0].Port = HostPort;
                    }
                    else
                    {
                        host.Networks[0].Port = 0;
                    }
                    break;

                case "secureOnPassword":
                    if (PhysicalAddress.TryParse(hostNodeNavigator.Value, out ParsedAddress))
                    {
                        host.SecureOnPassword = ParsedAddress;
                    }
                    break;

                case "owner":
                    host.Owner = hostNodeNavigator.Value;
                    break;
            }
        }

        #endregion

        #region Helper Classes

        /// <summary>
        /// 
        /// </summary>
        private sealed class ObservableHostList : ObservableCollection<WolHost>
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public sealed class WolHostGroupCollection : ObservableCollection<WolHostGroup>
        {
        }

        #endregion
    }
}
