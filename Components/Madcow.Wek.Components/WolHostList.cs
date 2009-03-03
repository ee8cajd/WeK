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
using System.IO;
using System.Xml;

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
        private bool _modified;
        private string _listVersion;

        private const string DefaultWolHostsFilename = "wolhosts.xml";

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public WolHostList()
        {
            _hosts = new ObservableHostList();
            _hosts.ListChanged += new EventHandler(delegate(object sender, EventArgs e) { _modified = true; });

            _modified = false;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        public bool Modified
        {
            get { return _modified; }
            private set { _modified = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public WolHost this[int index]
        {
            get { return _hosts[index]; }
            set { _hosts[index] = value; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            return Save(DefaultWolHostsFilename);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Save(string filename)
        {
            bool Success = true;

            try
            {
                XmlWriterSettings WriterSettings = new XmlWriterSettings();
                WriterSettings.Indent = true;
                WriterSettings.NewLineHandling = NewLineHandling.Entitize;
                WriterSettings.OmitXmlDeclaration = false;
                WriterSettings.ConformanceLevel = ConformanceLevel.Document;
                WriterSettings.CloseOutput = true;

                using (XmlWriter HostsWriter = XmlWriter.Create(filename, WriterSettings))
                {
                    HostsWriter.WriteStartDocument();
                    HostsWriter.WriteStartElement("wolHosts");
                    HostsWriter.WriteAttributeString("version", "1.0");

                    foreach (WolHost CurrentHost in _hosts)
                    {
                        PersistHost(HostsWriter, CurrentHost);
                    }

                    HostsWriter.WriteEndElement();
                }

                _modified = false;
            }
            catch (Exception)
            {
                Success = false;
            }

            return Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Load()
        {
            return Load(DefaultWolHostsFilename);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Load(string filename)
        {
            bool Success = true;

            _hosts.Clear();
            _modified = false;

            try
            {
                XmlReaderSettings ReaderSettings = new XmlReaderSettings();
                ReaderSettings.CloseInput = true;
                ReaderSettings.ConformanceLevel = ConformanceLevel.Document;
                ReaderSettings.IgnoreComments = true;
                ReaderSettings.IgnoreWhitespace = true;
                ReaderSettings.ProhibitDtd = true;
                ReaderSettings.ValidationType = ValidationType.None;

                using (XmlReader HostsReader = XmlReader.Create(filename, ReaderSettings))
                {
                    HostsReader.ReadStartElement("wolHosts");

                    if (HostsReader.HasAttributes)
                    {
                        _listVersion = HostsReader.GetAttribute("version");
                    }

                    while (HostsReader.IsStartElement())
                    {
                        _hosts.Add(ReadHostXml(HostsReader));
                    }

                    HostsReader.ReadEndElement();
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

            return Success;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private WolHost ReadHostXml(XmlReader reader)
        {
            WolHost NewHost = null;

            if (reader.IsStartElement("host"))
            {
                NewHost = new WolHost();

                // Read the 'host' node and look for the secureOn attribute.
                if (reader.HasAttributes)
                {
                    string SecureOnAttribute = reader.GetAttribute("secureOn");
                    NewHost.RequireSecureOn = (String.IsNullOrEmpty(SecureOnAttribute) ? false : SecureOnAttribute.ToLowerInvariant() == "true");

                    int HostWeight;
                    if (Int32.TryParse(reader.GetAttribute("weight") ?? "0", out HostWeight))
                    {
                        NewHost.Weight = HostWeight;
                    }
                    else
                    {
                        NewHost.Weight = 0;
                    }
                }
                else
                {
                    NewHost.RequireSecureOn = false;
                    NewHost.Weight = 0;
                }

                // Process the child nodes of thr 'host' element.
                while (reader.Read())
                {
                    if(reader.IsStartElement())
                    {
                        PhysicalAddress ParsedAddress;
                        string ElementValue = (reader.IsEmptyElement ? null : reader.ReadString());

                        switch (reader.Name)
                        {
                            case "name":
                                NewHost.Name = ElementValue;
                                break;

                            case "description":
                                NewHost.Description = ElementValue;
                                break;

                            case "physicalAddress":
                                if (PhysicalAddress.TryParse(ElementValue, out ParsedAddress))
                                {
                                    NewHost.MachineAddress = ParsedAddress;
                                }
                                break;

                            case "hostAddress":
                                NewHost.HostAddress = ElementValue;
                                break;

                            case "secureOnPassword":
                                if (PhysicalAddress.TryParse(ElementValue, out ParsedAddress))
                                {
                                    NewHost.SecureOnPassword = ParsedAddress;
                                }
                                break;

                            case "owner":
                                NewHost.Owner = ElementValue;
                                break;
                        }
                    }
                    else
                    {
                        // Read the closing tag of the 'host' element.
                        reader.Read();
                        break;
                    }
                }
            }

            return NewHost;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="host"></param>
        private void PersistHost(XmlWriter writer, WolHost host)
        {
            writer.WriteStartElement("host");
            writer.WriteAttributeString("weight", host.Weight.ToString());

            if (host.RequireSecureOn)
            {
                writer.WriteAttributeString("secureOn", "true");
            }

            writer.WriteElementString("name", host.Name);
            writer.WriteElementString("owner", host.Owner);
            writer.WriteElementString("physicalAddress", host.MachineAddress.ToString("C", null));
            writer.WriteElementString("description", host.Description);
            writer.WriteElementString("hostAddress", host.HostAddress);
            writer.WriteElementString("secureOnPassword", (host.RequireSecureOn ? host.SecureOnPassword.ToString("C", null) : null));

            writer.WriteEndElement();
        }

        #endregion

        #region Helper Classes

        public sealed class ObservableHostList : List<WolHost>
        {
            #region Public Events

            public event EventHandler ListChanged;

            #endregion

            #region Public Properties

            /// <summary>
            /// 
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public new WolHost this[int index]
            {
                get { return base[index]; }
                set
                {
                    base[index] = value;
                    OnListChanged();
                }
            }

            #endregion

            #region Public Methods

            /// <summary>
            /// 
            /// </summary>
            /// <param name="item"></param>
            public new void Add(WolHost item)
            {
                base.Add(item);
                OnListChanged();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="collection"></param>
            public new void AddRange(IEnumerable<WolHost> collection)
            {
                base.AddRange(collection);
                OnListChanged();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="index"></param>
            /// <param name="item"></param>
            public new void Insert(int index, WolHost item)
            {
                base.Insert(index, item);
                OnListChanged();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="index"></param>
            /// <param name="collection"></param>
            public new void InsertRange(int index, IEnumerable<WolHost> collection)
            {
                base.InsertRange(index, collection);
                OnListChanged();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="item"></param>
            public new void Remove(WolHost item)
            {
                base.Remove(item);
                OnListChanged();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="match"></param>
            /// <returns></returns>
            public new int RemoveAll(Predicate<WolHost> match)
            {
                int BaseResult = base.RemoveAll(match);
                OnListChanged();

                return BaseResult;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="index"></param>
            public new void RemoveAt(int index)
            {
                base.RemoveAt(index);
                OnListChanged();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="index"></param>
            /// <param name="count"></param>
            public new void RemoveRange(int index, int count)
            {
                base.RemoveRange(index, count);
                OnListChanged();
            }

            #endregion

            #region Private Methods

            private void OnListChanged()
            {
                EventHandler Handler = ListChanged;

                if (Handler != null)
                {
                    // Raise the event.
                    ListChanged(this, null);
                }
            }

            #endregion
        }

        #endregion
    }
}
