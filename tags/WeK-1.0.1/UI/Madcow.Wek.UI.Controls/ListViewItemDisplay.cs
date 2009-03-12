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
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#endregion

namespace Madcow.Wek.UI.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ListViewItemDisplay : UserControl
    {
        #region Private Members


        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public ListViewItemDisplay()
        {
            InitializeComponent();

            this.SuspendLayout();

            this.TopRowComboBox.FlatStyle = FlatStyle.Popup;
            this.TopRowComboBox.Text = null;
            this.MiddleRowComboBox.FlatStyle = FlatStyle.Popup;
            this.MiddleRowComboBox.Text = null;
            this.BottomRowComboBox.FlatStyle = FlatStyle.Popup;
            this.BottomRowComboBox.Text = null;

            this.ListItemImage.Image = null;

            this.ResumeLayout();
        }

        #endregion

        #region Event Handlers and base class overrides

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            this.SuspendLayout();

            foreach (Control ChildControl in this.Controls)
            {
                ChildControl.Enabled = this.Enabled;
            }

            this.BackColor = (this.Enabled ? SystemColors.Window : SystemColors.Control);

            this.ResumeLayout();
        }

        #endregion

        #region Public Properties

        [Browsable(true), Category("Appearance"), DefaultValue(typeof(Image), "null")]
        public Image ItemImage
        {
            get { return this.ListItemImage.Image; }
            set { this.ListItemImage.Image = value; }
        }
	

        private Type _objectType;
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public Type ItemObjectType
        {
            get { return _objectType; }
            set
            {
                _objectType = value;
                SetItemClass();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(true), Category("Display Rows"), DefaultValue(""), DisplayName("Row 1")]
        public string TopRowValue
        {
            get { return GetComboBoxValue(this.TopRowComboBox); }
            set { this.TopRowComboBox.SelectedValue = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(true), Category("Display Rows"), DefaultValue(""), DisplayName("Row 2")]
        public string MiddleRowValue
        {
            get { return GetComboBoxValue(this.MiddleRowComboBox); }
            set { this.MiddleRowComboBox.SelectedValue = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(true), Category("Display Rows"), DefaultValue(""), DisplayName("Row 3")]
        public string BottomRowValue
        {
            get { return GetComboBoxValue(this.BottomRowComboBox); }
            set { this.BottomRowComboBox.SelectedValue = value; }
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comboBoxToQuery"></param>
        /// <returns></returns>
        private static string GetComboBoxValue(ComboBox comboBoxToQuery)
        {
            return (comboBoxToQuery.SelectedValue == null ? null : comboBoxToQuery.SelectedValue.ToString());
        }

        /// <summary>
        /// Reflects on the type set at the Item Object Class and populates the combo boxes with those
        /// public properties that have been marked as Browsable.
        /// </summary>
        private void SetItemClass()
        {
            if (_objectType != null)
            {
                // Retrieve the public properties of the Item Object Class.
                PropertyInfo[] ItemClassProperties = _objectType.GetProperties(BindingFlags.Instance | BindingFlags.Public);

                if (ItemClassProperties != null && ItemClassProperties.Length > 0)
                {
                    // Create the list to hold the visible properties.
                    List<KeyValuePair<string, string>> ItemClassBrowsableProperties = new List<KeyValuePair<string, string>>(ItemClassProperties.Length);

                    foreach (PropertyInfo ClassProperty in ItemClassProperties)
                    {
                        // Pick up declarative settings on the class properties relating to their display.
                        object[] CustomAttributes = ClassProperty.GetCustomAttributes(false);

                        if (CustomAttributes != null)
                        {
                            bool PropertyIsBrowsable = false;
                            string PropertyDisplayName = ClassProperty.Name;

                            for (int i = 0; i < CustomAttributes.Length; i++)
                            {
                                if (CustomAttributes[i] is BrowsableAttribute)
                                {
                                    // The property has a Browsable declaration.
                                    BrowsableAttribute BrowsableMarker = CustomAttributes[i] as BrowsableAttribute;
                                    PropertyIsBrowsable = BrowsableMarker.Browsable;
                                }
                                else if (CustomAttributes[i] is DisplayNameAttribute)
                                {
                                    // The property has a DisplayName declaration. This overrides the default of
                                    // doubling the Property Name as the displayed name.
                                    DisplayNameAttribute DisplayNameMarker = CustomAttributes[i] as DisplayNameAttribute;
                                    PropertyDisplayName = DisplayNameMarker.DisplayName;
                                }
                            }

                            // If the property has been declared browsable, add it to the list of visible properties.
                            if (PropertyIsBrowsable)
                            {
                                ItemClassBrowsableProperties.Add(new KeyValuePair<string, string>(ClassProperty.Name, PropertyDisplayName));
                            }
                        }
                    }

                    // If there are no properties to display, the Item Object Class isn't suitable for use.
                    Debug.Assert(ItemClassBrowsableProperties.Count > 0, "ItemObjectClass does not expose any public, browsable properties");

                    // Sort the list of properties by their Display Name (the Value of the KV pair) then
                    // add a blank entry as the first item in the list.
                    ItemClassBrowsableProperties.Sort(new KeyValuePairValueComparer<string, string>());
                    ItemClassBrowsableProperties.Insert(0, new KeyValuePair<string, string>());

                    const string DisplayMember = "Value";
                    const string ValueMember = "Key";

                    this.TopRowComboBox.DisplayMember = DisplayMember;
                    this.TopRowComboBox.ValueMember = ValueMember;
                    this.TopRowComboBox.DataSource = ItemClassBrowsableProperties.ToArray();
                    this.TopRowComboBox.SelectedIndex = -1;

                    this.MiddleRowComboBox.DisplayMember = DisplayMember;
                    this.MiddleRowComboBox.ValueMember = ValueMember;
                    this.MiddleRowComboBox.DataSource = ItemClassBrowsableProperties.ToArray();
                    this.MiddleRowComboBox.SelectedIndex = -1;

                    this.BottomRowComboBox.DisplayMember = DisplayMember;
                    this.BottomRowComboBox.ValueMember = ValueMember;
                    this.BottomRowComboBox.DataSource = ItemClassBrowsableProperties.ToArray();
                    this.BottomRowComboBox.SelectedIndex = -1;
                }
            }
        }

        #endregion

        #region Helper Classes

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        private class KeyValuePairValueComparer<TKey, TValue> : IComparer<KeyValuePair<TKey, TValue>>
            where TValue : IComparable<TValue>
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public int Compare(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y)
            {
                return x.Value.CompareTo(y.Value);
            }
        }

        #endregion
    }
}
