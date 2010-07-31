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
using System.Configuration;

#endregion

namespace Madcow.UI.Controls.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public class PersistWindowSection : ConfigurationSection
    {
        #region Private Members

        private static ConfigurationPropertyCollection _properties;
        private static ConfigurationProperty _propertyForms;

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        static PersistWindowSection()
        {
            _properties = new ConfigurationPropertyCollection();

            _propertyForms = new ConfigurationProperty("forms", typeof(PersistWindowFormElementCollection), null, ConfigurationPropertyOptions.None);

            _properties.Add(_propertyForms);
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("forms")]
        public PersistWindowFormElementCollection Forms
        {
            get { return (PersistWindowFormElementCollection)base[_propertyForms]; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override ConfigurationPropertyCollection Properties
        {
            get { return _properties; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static PersistWindowSection GetSection()
        {
            return ConfigurationManager.GetSection("persistWindow") as PersistWindowSection;
        }

        #endregion
    }
}
