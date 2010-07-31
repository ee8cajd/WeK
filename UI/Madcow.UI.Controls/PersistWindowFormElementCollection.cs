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
    [ConfigurationCollection(typeof(PersistWindowFormElement), AddItemName = "forms", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class PersistWindowFormElementCollection : ConfigurationElementCollection
    {
        #region Private Members

        private static ConfigurationPropertyCollection _properties;

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        static PersistWindowFormElementCollection()
        {
            _properties = new ConfigurationPropertyCollection();
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        protected override string ElementName
        {
            get { return "form"; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override ConfigurationPropertyCollection Properties
        {
            get { return _properties; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public PersistWindowFormElement this[int index]
        {
            get { return (PersistWindowFormElement)base.BaseGet(index); }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }

                base.BaseAdd(index, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public new PersistWindowFormElement this[string name]
        {
            get { return (PersistWindowFormElement)base.BaseGet(name); }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="thing"></param>
        public void Add(PersistWindowFormElement thing)
        {
            base.BaseAdd(thing);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            base.BaseClear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetKey(int index)
        {
            return (string)base.BaseGetKey(index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public void Remove(string name)
        {
            base.BaseRemove(name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="thing"></param>
        public void Remove(PersistWindowFormElement thing)
        {
            base.BaseRemove(GetElementKey(thing));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            base.BaseRemoveAt(index);
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new PersistWindowFormElement();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as PersistWindowFormElement).Name;
        }

        #endregion
    }
}
