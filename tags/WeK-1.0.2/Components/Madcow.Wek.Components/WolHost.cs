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
using System.ComponentModel;
using System.Net;

using Madcow.ComponentModel;
using Madcow.Network.Management;

#endregion

namespace Madcow.Wek.Components
{
    /// <summary>
    /// 
    /// </summary>
    public class WolHost
    {
        #region Public Constructors

        /// <summary>
        /// 
        /// </summary>
        public WolHost()
            : this(null,
                   null,
                   null,
                   PhysicalAddress.None,
                   null,
                   false,
                   PhysicalAddress.None,
                   0)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="owner"></param>
        /// <param name="requireSecureOn"></param>
        /// <param name="secureOnPassword"></param>
        /// <param name="machineAddress"></param>
        /// <param name="hostAddress"></param>
        /// <param name="weight"></param>
        public WolHost(
            string name,
            string description,
            string owner,
            PhysicalAddress machineAddress,
            string hostAddress,
            bool requireSecureOn,
            PhysicalAddress secureOnPassword,
            int weight)
        {
            this.Name = name;
            this.Description = description;
            this.Owner = owner;
            this.MachineAddress = machineAddress;
            this.HostAddress = hostAddress;
            this.RequireSecureOn = requireSecureOn;
            this.SecureOnPassword = secureOnPassword;
            this.Weight = weight;
        }

        #endregion

        #region Public Properties

        private string _name;
        /// <summary>
        /// 
        /// </summary>
        [Browsable(true), Localizable(true), DisplayName("Name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _description;
        /// <summary>
        /// 
        /// </summary>
        [Browsable(true), Localizable(true), DisplayName("Description")]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _owner;
        /// <summary>
        /// 
        /// </summary>
        [Browsable(true), Localizable(true), DisplayName("Owner")]
        public string Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        private bool _requireSecureOn;
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public bool RequireSecureOn
        {
            get { return _requireSecureOn; }
            set { _requireSecureOn = value; }
        }

        private PhysicalAddress _machineAddress;
        /// <summary>
        /// 
        /// </summary>
        [Browsable(true), Localizable(true), DisplayName("Machine Address"), DefaultFormatString("C")]
        public PhysicalAddress MachineAddress
        {
            get { return _machineAddress; }
            set { _machineAddress = value; }
        }

        private string _hostAddress;
        /// <summary>
        /// 
        /// </summary>
        [Browsable(true), Localizable(true), DisplayName("Host Address")]
        public string HostAddress
        {
            get { return _hostAddress; }
            set { _hostAddress = value; }
        }

        private PhysicalAddress _secureOnPassword;
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public PhysicalAddress SecureOnPassword
        {
            get { return _secureOnPassword; }
            set { _secureOnPassword = value; }
        }

        private int _weight;
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a deep copy of this object.
        /// </summary>
        /// <returns>The deep copy of this WolHost object.</returns>
        public WolHost Clone()
        {
            WolHost CloneObject = new WolHost();
            CloneObject.Name = this.Name;
            CloneObject.MachineAddress = (this.MachineAddress != null ? this.MachineAddress.Clone() : null);
            CloneObject.HostAddress = this.HostAddress;
            CloneObject.Owner = this.Owner;
            CloneObject.RequireSecureOn = this.RequireSecureOn;
            CloneObject.SecureOnPassword = (this.SecureOnPassword != null ? this.SecureOnPassword.Clone() : null);
            CloneObject.Description = this.Description;
            CloneObject.Weight = this.Weight;

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
    }
}
