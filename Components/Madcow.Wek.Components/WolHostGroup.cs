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
using System.Collections.ObjectModel;

#endregion

namespace Madcow.Wek.Components
{
    /// <summary>
    /// Strongly types collection of hosts.
    /// </summary>
    public class WolHostGroup : Collection<WolHostGroupMember>
    {
        #region Constructors

        #endregion

        #region Public Properties

        private string _name;
        /// <summary>
        /// Gets or sets the name of the group of hosts.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        #endregion

        #region Public Methods

        #endregion
    }
}
