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
using System.Reflection;
using System.Windows.Forms;

using Madcow.Wek.Components;
using Madcow.Wek.UI.Properties;

#endregion

namespace Madcow.Wek.UI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class OptionsForm : Form
    {
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public OptionsForm()
        {
            InitializeComponent();

            listViewItemDisplay1.ItemObjectType = typeof(WolHost);

            GuiHelper.PopulateComboFromEnum(this.DoubleClickBehaviourComboBox,
                                            typeof(HostDoubleClickAction), 
                                            Resources.ResourceManager);

            listViewItemDisplay1.TopRowValue = Settings.Default.HostViewItemFirstLineProperty ?? String.Empty;
            listViewItemDisplay1.MiddleRowValue = Settings.Default.HostViewItemSecondLineProperty ?? String.Empty;
            listViewItemDisplay1.BottomRowValue = Settings.Default.HostViewItemThirdLineProperty ?? String.Empty;

            this.DoubleClickBehaviourComboBox.SelectedValue = Enum.Parse(typeof(HostDoubleClickAction), 
                                                                         Settings.Default.HostViewItemDoubleClickAction,
                                                                         true);

            this.ShowSecureOnHintCheckBox.Checked = Settings.Default.ShowSecureOnHostHint;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                Settings.Default.HostViewItemFirstLineProperty = this.listViewItemDisplay1.TopRowValue;
                Settings.Default.HostViewItemSecondLineProperty = this.listViewItemDisplay1.MiddleRowValue;
                Settings.Default.HostViewItemThirdLineProperty = this.listViewItemDisplay1.BottomRowValue;

                Settings.Default.HostViewItemDoubleClickAction = ((GuiHelper.ComboItemHelper)this.DoubleClickBehaviourComboBox.SelectedItem).Value.ToString();
                Settings.Default.ShowSecureOnHostHint = this.ShowSecureOnHintCheckBox.Checked;

                Settings.Default.Save();
            }
        }

        #endregion
    }
}