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
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

using Madcow.ComponentModel;

#endregion

namespace Madcow.Wek.UI
{
    /// <summary>
    /// 
    /// </summary>
    public enum ActionMode
    {
        None,
        Add,
        Amend,
        View
    }

    /// <summary>
    /// 
    /// </summary>
    internal enum HostDoubleClickAction
    {
        [Description("HostDoubleClickAction_DoNothing"), Localizable(true)]
        DoNothing,
        [Description("HostDoubleClickAction_WakeTheHost"), Localizable(true)]
        Wake,
        [Description("HostDoubleClickAction_ShowHostProperties"), Localizable(true)]
        ShowProperties
    }

    /// <summary>
    /// 
    /// </summary>
    public static class GuiHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetCombo"></param>
        /// <param name="source"></param>
        public static void PopulateComboFromEnum(ComboBox targetCombo, Type source)
        {
            PopulateComboFromEnum(targetCombo, source, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetCombo"></param>
        /// <param name="source"></param>
        /// <param name="resources"></param>
        public static void PopulateComboFromEnum(ComboBox targetCombo, Type source, ResourceManager resources)
        {
            FieldInfo[] EnumFields = source.GetFields(BindingFlags.Public | BindingFlags.Static);

            if(EnumFields.Length > 0)
            {
                ComboItemHelper[] ComboItemList = new ComboItemHelper[EnumFields.Length];

                for(int i = 0 ; i < EnumFields.Length ; i++)
                {
                    DescriptionAttribute EnumDisplayName = null;
                    LocalizableAttribute DisplayNameLocalizable = null;

                    foreach (object CustomAttribute in EnumFields[i].GetCustomAttributes(false))
                    {
                        if(CustomAttribute is DescriptionAttribute)
                        {
                            EnumDisplayName = CustomAttribute as DescriptionAttribute;
                        }
                        else if(CustomAttribute is LocalizableAttribute)
                        {
                            DisplayNameLocalizable = CustomAttribute as LocalizableAttribute;
                        }
                    }

                    if(EnumDisplayName == null || String.IsNullOrEmpty(EnumDisplayName.Description))
                    {
                        // No alternative Display Name has been specified, so use the plain enum name.
                        ComboItemList[i].DisplayName = EnumFields[i].Name;
                    }
                    else
                    {
                        // There is an explicit Display Name specified. Localize it if required.
                        if (DisplayNameLocalizable != null && DisplayNameLocalizable.IsLocalizable && resources != null)
                        {
                            // Look up the enumeration description in localized resources; fall back to
                            // the plain enum name if the localization lookup fails.
                            ComboItemList[i].DisplayName = resources.GetString(EnumDisplayName.Description) ?? EnumFields[i].Name;
                        }
                        else
                        {
                            // Use the value passed as the enumeration description.
                            ComboItemList[i].DisplayName = EnumDisplayName.Description;
                        }
                    }

                    // Set the value.
                    ComboItemList[i].Value = Enum.Parse(source, EnumFields[i].Name);
                }

                targetCombo.DisplayMember = "DisplayName";
                targetCombo.ValueMember = "Value";
                targetCombo.DataSource = ComboItemList;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public struct ComboItemHelper
        {
            private string _display;
            public string DisplayName
            {
                get { return _display; }
                set { _display = value; }
            }

            private object _value;
            public object Value
            {
                get { return _value; }
                set { _value = value; }
            }
	
            public ComboItemHelper(string displayName, object value)
            {
                _display = displayName;
                _value = value;
            }
        }
    }
}
