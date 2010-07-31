/*

WeK - A magic packet Wake On LAN Utility for Microsoft Windows.
Copyright © 2010 Chris Dickson

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
using System.ComponentModel;
using System.Net;

#endregion

namespace Madcow.Wek.Components
{
    /// <summary>
    /// Class encapsulating details of the network location of a host.
    /// </summary>
    public class WolHostNetwork
    {
        #region Public Enumerations

        /// <summary>
        /// Enumeration describing the various types of Network Locality.
        /// </summary>
        public enum NetworkLocality
        {
            [Description("NetworkLocality_LocalSubnet"), LocalizableAttribute(true)]
            LocalSubnet,
            [Description("NetworkLocality_Remote"), LocalizableAttribute(true)]
            Remote
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of a WolHostNetwork object.
        /// </summary>
        public WolHostNetwork()
            : this(Guid.NewGuid(),
                   null,
                   null,
                   0,
                   null,
                   NetworkLocality.LocalSubnet)
        {
        }

        /// <summary>
        /// Creates a new instance of a WolHostNetwork object and initializes the object
        /// with the given data.
        /// </summary>
        /// <param name="name">The common name of the network.</param>
        /// <param name="address">The address to which magic packets will be sent.</param>
        /// <param name="port">The port to which magic packets will be send.</param>
        /// <param name="subnetMask">The subnet mask of the network on which the host is located.</param>
        /// <param name="locality">The locality of the network.</param>
        public WolHostNetwork(string name, string address, int port, IPAddress subnetMask, NetworkLocality locality)
            : this(Guid.NewGuid(), 
                   name,
                   address,
                   port,
                   subnetMask,
                   locality)
        {
        }

        /// <summary>
        /// Creates a new instance of a WolHostNetwork object and initializes the object
        /// with the given data.
        /// </summary>
        /// <param name="networkId">The internal Id used to manage the network instance.</param>
        /// /// <param name="name">The common name of the network.</param>
        /// <param name="address">The address to which magic packets will be sent.</param>
        /// <param name="port">The port to which magic packets will be send.</param>
        /// <param name="subnetMask">The subnet mask of the network on which the host is located.</param>
        /// <param name="locality">The locality of the network.</param>
        public WolHostNetwork(Guid networkId, string name, string address, int port, IPAddress subnetMask, NetworkLocality locality)
        {
            this.NetworkId = networkId;
            this.Name = name;
            this.Address = address;
            this.Port = port;
            this.SubnetMask = subnetMask;
            this.Locality = locality;
        }

        #endregion

        #region Public Properties

        private Guid _networkId;
        /// <summary>
        /// Gets or sets the unique identifier of the network.
        /// </summary>
        public Guid NetworkId
        {
            get { return _networkId; }
            set { _networkId = value; }
        }

        private string _name;
        /// <summary>
        /// Gets or sets the Name of the network.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _address;
        /// <summary>
        /// Gets or sets the Address to be used on this network.
        /// </summary>
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private int _port;
        /// <summary>
        /// Gets or sets the Port to be used on this network.
        /// </summary>
        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }

        private IPAddress _subnetMask;
        /// <summary>
        /// Gets or sets the Subnet Mask to be used on this network.
        /// </summary>
        public IPAddress SubnetMask
        {
            get { return _subnetMask; }
            set { _subnetMask = value; }
        }

        private NetworkLocality _locality;
        /// <summary>
        /// Gets or sets the locality of the network.
        /// </summary>
        public NetworkLocality Locality
        {
            get { return _locality; }
            set { _locality = value; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a deep copy of the WolHostNetwork object.
        /// </summary>
        /// <returns></returns>
        public WolHostNetwork Clone()
        {
            return this.MemberwiseClone() as WolHostNetwork;
        }

        #endregion
    }
}
