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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;

using Madcow.ComponentModel;
using Madcow.Network.Management;

#endregion

namespace Madcow.Wek.Components
{
    /// <summary>
    /// Class encapsulating the properties of a host capable of being woken via a network connection.
    /// </summary>
    public class WolHost
    {
        #region Public Constructors

        /// <summary>
        /// 
        /// </summary>
        public WolHost()
            : this(Guid.NewGuid(),
                   null,
                   null,
                   null,
                   PhysicalAddress.None,
                   false,
                   PhysicalAddress.None,
                   Guid.Empty)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="owner"></param>
        /// <param name="requireSecureOn"></param>
        /// <param name="secureOnPassword"></param>
        /// <param name="machineAddress"></param>
        /// <param name="defaultNetwork"></param>
        public WolHost(
            Guid id,
            string name,
            string description,
            string owner,
            PhysicalAddress machineAddress,
            bool requireSecureOn,
            PhysicalAddress secureOnPassword,
            Guid defaultNetwork)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Owner = owner;
            this.MachineAddress = machineAddress;
            this.RequireSecureOn = requireSecureOn;
            this.SecureOnPassword = secureOnPassword;
            this.DefaultNetwork = defaultNetwork;
        }

        #endregion

        #region Public Properties

        private Guid _id;
        /// <summary>
        /// The unique identification code for the host.
        /// </summary>
        [Browsable(false)]
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;
        /// <summary>
        /// The name of the host, for display purposes only.
        /// </summary>
        [Browsable(true), Localizable(true), DisplayName("Name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _description;
        /// <summary>
        /// A simple, textual description of the host.
        /// </summary>
        [Browsable(true), Localizable(true), DisplayName("Description")]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _owner;
        /// <summary>
        /// The person responsible for managing the host.
        /// </summary>
        [Browsable(true), Localizable(true), DisplayName("Owner")]
        public string Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        private bool _requireSecureOn;
        /// <summary>
        /// Flag to indicate whether the host requires a Wake On LAN password to be provided.
        /// </summary>
        [Browsable(false)]
        public bool RequireSecureOn
        {
            get { return _requireSecureOn; }
            set { _requireSecureOn = value; }
        }

        private PhysicalAddress _machineAddress;
        /// <summary>
        /// The MAC address of the network interface on the host.
        /// </summary>
        [Browsable(true), Localizable(true), DisplayName("Machine Address"), DefaultFormatString("C")]
        public PhysicalAddress MachineAddress
        {
            get { return _machineAddress; }
            set { _machineAddress = value; }
        }

        /// <summary>
        /// Gets the IPv4 address of default network defined for the host.
        /// </summary>
        [Browsable(true), Localizable(true), DisplayName("Host Address")]
        public string HostAddress
        {
            get
            {
                string Address = null;

                if (this.DefaultNetwork != Guid.Empty)
                {
                    // Get the details for the default network.
                    WolHostNetwork DefaultNetworkItem = this.Networks[this.DefaultNetwork];
                    if (DefaultNetworkItem != null)
                    {
                        Address = DefaultNetworkItem.Address;
                    }
                }
                
                if(String.IsNullOrEmpty(Address) && this.Networks.Count > 0)
                {
                    // If no default network is defined, prefer the first available network item.
                    Address = this.Networks[0].Address;
                }

                return Address;
            }
        }

        /// <summary>
        /// Gets the name of the default network defined for the host.
        /// </summary>
        [Browsable(true), Localizable(true), DisplayName("Default Network")]
        public string DefaultNetworkName
        {
            get
            {
                string NetworkName = null;

                if (this.DefaultNetwork != Guid.Empty)
                {
                    // Get the details for the default network.
                    WolHostNetwork DefaultNetworkItem = this.Networks[this.DefaultNetwork];
                    if (DefaultNetworkItem != null)
                    {
                        NetworkName = DefaultNetworkItem.Name;
                    }
                }

                if (String.IsNullOrEmpty(NetworkName) && this.Networks.Count > 0)
                {
                    // If not default network is defined, prefer the first available network item.
                    NetworkName = this.Networks[0].Name;
                }

                return NetworkName;
            }
        }
        
        private PhysicalAddress _secureOnPassword;
        /// <summary>
        /// The SecureOn Password required by the host to accept a Wake On LAN request.
        /// </summary>
        [Browsable(false)]
        public PhysicalAddress SecureOnPassword
        {
            get { return _secureOnPassword; }
            set { _secureOnPassword = value; }
        }

        private WolHostNetworkCollection _networks;
        /// <summary>
        /// The collection of networks through which this host may be woken.
        /// </summary>
        [Browsable(false)]
        public WolHostNetworkCollection Networks
        {
            get
            {
                if (_networks == null)
                {
                    _networks = new WolHostNetworkCollection();
                }

                return _networks;
            }
        }

        private Guid _defaultNetwork; 
        /// <summary>
        /// Gets or sets the ID of the default network used by generic operations.
        /// </summary>
        [Browsable(false)]
        public Guid DefaultNetwork
        {
            get { return _defaultNetwork; }
            set { _defaultNetwork = value; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a deep copy of this object.
        /// </summary>
        /// <returns>The deep copy of this WolHost object.</returns>
        public WolHost Clone()
        {
            WolHost CloneObject = MemberwiseClone() as WolHost;
            CloneObject.MachineAddress = (this.MachineAddress != null ? this.MachineAddress.Clone() : null);
            CloneObject.SecureOnPassword = (this.SecureOnPassword != null ? this.SecureOnPassword.Clone() : null);

            return CloneObject;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "[WolHost: " + this.MachineAddress.ToString("C", null) + "]";
        }

        #endregion

        #region Helper Types

        /// <summary>
        /// 
        /// </summary>
        public class WolHostNetworkCollection : Collection<WolHostNetwork>
        {
            #region Public Properties

            /// <summary>
            /// 
            /// </summary>
            /// <param name="networkId"></param>
            /// <returns></returns>
            public WolHostNetwork this[Guid networkId]
            {
                get
                {
                    WolHostNetwork Network = null;
                    for (int i = 0; i < this.Items.Count; i++)
                    {
                        if (this.Items[i].NetworkId == networkId)
                        {
                            Network = this.Items[i];
                            break;
                        }
                    }

                    return Network;
                }
            }

            #endregion

            #region Public Methods

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public WolHostNetworkCollection Clone()
            {
                WolHostNetworkCollection CollectionClone = new WolHostNetworkCollection();
                for (int i = 0; i < this.Items.Count; i++)
                {
                    CollectionClone.Add(this.Items[i].Clone());
                }

                return CollectionClone;
            }

            #endregion
        }

        #endregion
    }
}
