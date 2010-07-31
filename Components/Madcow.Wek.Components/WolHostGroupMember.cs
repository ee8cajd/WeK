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
using System.Collections.Generic;

#endregion

namespace Madcow.Wek.Components
{
    /// <summary>
    /// 
    /// </summary>
    public class WolHostGroupMember
    {
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="host"></param>
        public WolHostGroupMember(WolHost host)
            : this(host, Guid.Empty)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="host"></param>
        /// <param name="defaultNetwork"></param>
        public WolHostGroupMember(WolHost host, Guid defaultNetwork)
        {
            this.DefaultNetwork = defaultNetwork;
            this.Host = host;
        }

        #endregion

        #region Public Properties

        private Guid _defaultNetwork;
        /// <summary>
        /// Gets or sets the network that will be used for waking the associated host when
        /// accessed via the parent group.
        /// </summary>
        public Guid DefaultNetwork
        {
            get { return _defaultNetwork; }
            set { _defaultNetwork = value; }
        }

        private WolHost _host;
        /// <summary>
        /// Gets or sets the host referenced by this group membership mapping.
        /// </summary>
        public WolHost Host
        {
            get { return _host; }
            set { _host = value; }
        }

        #endregion

        #region Public Methods

        #endregion
    }
}
