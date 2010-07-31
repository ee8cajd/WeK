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
using System.Windows.Forms;

#endregion

namespace Madcow.UI.Controls.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public class PersistWindowFormElement : ConfigurationElement
    {
        #region Private Members

        private static ConfigurationPropertyCollection _properties;

        private static ConfigurationProperty _propertyName;
        private static ConfigurationProperty _propertyX;
        private static ConfigurationProperty _propertyY;
        private static ConfigurationProperty _propertyWidth;
        private static ConfigurationProperty _propertyHeight;
        private static ConfigurationProperty _propertyState;

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        static PersistWindowFormElement()
        {
            _properties = new ConfigurationPropertyCollection();

            _propertyName = new ConfigurationProperty(PersistWindow.SettingItemWindowName, typeof(String), null, ConfigurationPropertyOptions.IsRequired);
            _propertyX = new ConfigurationProperty(PersistWindow.SettingItemWindowX, typeof(Int32), 0, ConfigurationPropertyOptions.IsRequired);
            _propertyY = new ConfigurationProperty(PersistWindow.SettingItemWindowY, typeof(Int32), 0, ConfigurationPropertyOptions.IsRequired);
            _propertyWidth = new ConfigurationProperty(PersistWindow.SettingItemWindowWidth, typeof(Int32), 0, ConfigurationPropertyOptions.IsRequired);
            _propertyHeight = new ConfigurationProperty(PersistWindow.SettingItemWindowHeight, typeof(Int32), 0, ConfigurationPropertyOptions.IsRequired);
            _propertyState = new ConfigurationProperty(PersistWindow.SettingItemWindowState, typeof(String), "Normal", ConfigurationPropertyOptions.None);

            _properties.Add(_propertyName);
            _properties.Add(_propertyX);
            _properties.Add(_propertyY);
            _properties.Add(_propertyWidth);
            _properties.Add(_propertyHeight);
            _properties.Add(_propertyState);
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return base[_propertyName] as String; }
            set { base[_propertyName] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("x", IsRequired = true)]
        public int X
        {
            get { return (int)base[_propertyX]; }
            set { base[_propertyX] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("y", IsRequired = true)]
        public int Y
        {
            get { return (int)base[_propertyY]; }
            set { base[_propertyY] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("w", IsRequired = true)]
        public int Width
        {
            get { return (int)base[_propertyWidth]; }
            set { base[_propertyWidth] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("h", IsRequired = true)]
        public int Height
        {
            get { return (int)base[_propertyHeight]; }
            set { base[_propertyHeight] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("state", IsRequired = true)]
        public FormWindowState State
        {
            get { return PersistWindow.ParseFormWindowStateString(base[_propertyState].ToString()); }
            set { base[_propertyState] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override ConfigurationPropertyCollection Properties
        {
            get { return _properties; }
        }

        #endregion
    }
}
