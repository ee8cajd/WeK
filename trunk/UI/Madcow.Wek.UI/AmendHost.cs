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
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

using Madcow.Network.Management;
using Madcow.Wek.Components;
using Madcow.Wek.UI.Properties;

#endregion

namespace Madcow.Wek.UI
{
    /// <summary>
    /// Class implementing the form for amending the properties of a WolHost object.
    /// </summary>
    public partial class AmendHost : Form
    {
        #region Private Members

        private WolHost _host;
        private ActionMode _action;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the form for amending the properties of a given WolHost object.
        /// </summary>
        /// <param name="action">The amendment mode in which the form will be operating.</param>
        /// <param name="host"></param>
        public AmendHost(ActionMode action, WolHost host)
        {
            InitializeComponent();

            _action = action;
            _host = host;

            InitialiseUI();
        }

        #endregion

        #region Event Handlers
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">A reference to the SecureOnPromptCheckBox form object.</param>
        /// <param name="e">Event specific data.</param>
        private void SecureOnCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.SecureOnPromptCheckBox.Enabled = this.SecureOnCheckBox.Checked;
            this.SecureOnPasswordControl.Enabled = this.SecureOnCheckBox.Checked &&
                                                   (this.SecureOnPromptCheckBox.Checked == false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">A reference to the SecureOnPromptCheckBox form object.</param>
        /// <param name="e">Event specific data.</param>
        private void SecureOnPromptCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.SecureOnPasswordControl.Enabled = this.SecureOnCheckBox.Checked &&
                                                   (this.SecureOnPromptCheckBox.Checked == false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNetworkButton_Click(object sender, EventArgs e)
        {
            WolHostNetwork NewNetwork = new WolHostNetwork();

            using (AmendNetwork AddNetworkForm = new AmendNetwork(ActionMode.Add, NewNetwork))
            {
                if (AddNetworkForm.ShowDialog() == DialogResult.OK)
                {
                    ListViewItem NewListItem = new ListViewItem(new string[] {
                                                                        NewNetwork.Name,
                                                                        NewNetwork.Address
                                                                    });

                    NewListItem.Tag = NewNetwork;

                    this.NetworksListView.Items.Add(NewListItem);
                    this.NetworksListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AmendNetworkButton_Click(object sender, EventArgs e)
        {
            if (this.NetworksListView.SelectedItems.Count == 1)
            {
                ListViewItem SelectedItem = this.NetworksListView.SelectedItems[0];
                
                WolHostNetwork SelectedNetwork = SelectedItem.Tag as WolHostNetwork;
                WolHostNetwork ClonedNetwork = SelectedNetwork.Clone();
                
                if (SelectedNetwork != null)
                {
                    using (AmendNetwork AmendNetworkForm = new AmendNetwork(ActionMode.Amend, ClonedNetwork))
                    {
                        if (AmendNetworkForm.ShowDialog() == DialogResult.OK)
                        {
                            SelectedItem.SubItems[0].Text = ClonedNetwork.Name;
                            SelectedItem.SubItems[1].Text = ClonedNetwork.Address;

                            SelectedItem.Tag = ClonedNetwork;

                            this.NetworksListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveNetworkButton_Click(object sender, EventArgs e)
        {
            if (this.NetworksListView.SelectedItems.Count == 1)
            {
                this.NetworksListView.SelectedItems[0].Remove();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetDefaultButton_Click(object sender, EventArgs e)
        {
            if (this.NetworksListView.SelectedItems.Count == 1)
            {
                for (int i = 0; i < this.NetworksListView.Items.Count; i++)
                {
                    if (i == this.NetworksListView.SelectedItems[0].Index)
                    {
                        WolHostNetwork SelectedNetwork = this.NetworksListView.SelectedItems[0].Tag as WolHostNetwork;
                        _host.DefaultNetwork = SelectedNetwork.NetworkId;

                        this.NetworksListView.Items[i].Font = new Font(this.NetworksListView.Font, FontStyle.Bold);
                    }
                    else
                    {
                        this.NetworksListView.Items[i].Font = this.NetworksListView.Font;
                    }
                }

                this.NetworksListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        /// <summary>
        /// Selected Index Changed Event handler for the Networks List View.
        /// </summary>
        /// <param name="sender">A reference to the NetworksListView object.</param>
        /// <param name="e">Event specific data.</param>
        private void NetworksListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            LockUnlockNetworkControls();
        }

        /// <summary>
        /// Form Closing Event handler for the AmendHost form.
        /// </summary>
        /// <param name="sender">A reference to the AmendHost form object.</param>
        /// <param name="e">Event specific data.</param>
        private void AmendHost_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                e.Cancel = (ValidateData() == false);
                if (e.Cancel == false)
                {
                    PopulateObjectFromControls();
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initialises control state, static data and read-only state.
        /// </summary>
        private void InitialiseUI()
        {
            GuiHelper.SetTitle(this, _action);

            PopulateControlsFromObject();
            
            if (_action == ActionMode.View)
            {
                SetReadOnly();
            }
            else
            {
                LockUnlockControls();
                LockUnlockNetworkControls();
            }
        }

        /// <summary>
        /// Method to set the locking state of controls based on the current context.
        /// </summary>
        private void LockUnlockControls()
        {
            this.SecureOnPromptCheckBox.Enabled = _host.RequireSecureOn;
            this.SecureOnPasswordControl.Enabled = _host.RequireSecureOn;
        }

        /// <summary>
        /// Sets the locking state of network modification buttons based on the current context.
        /// </summary>
        private void LockUnlockNetworkControls()
        {
            this.AmendNetworkButton.Enabled = this.NetworksListView.SelectedItems.Count == 1;
            this.RemoveNetworkButton.Enabled = this.NetworksListView.SelectedItems.Count > 0;
            this.SetDefaultButton.Enabled = (this.NetworksListView.SelectedItems.Count == 1 &&
                                             this.NetworksListView.SelectedItems[0].Font.Bold == false);
        }

        /// <summary>
        /// Sets the values in the form controls from the Host object to be amended.
        /// </summary>
        private void PopulateControlsFromObject()
        {
            this.DescriptionTextBox.Text = _host.Description;
            this.DescriptiveNameTextBox.Text = _host.Name;
            this.HostPhysicalAddress.Value = _host.MachineAddress;
            this.OwnerTextBox.Text = _host.Owner;

            this.SecureOnCheckBox.Checked = _host.RequireSecureOn;
            this.SecureOnPromptCheckBox.Checked = _host.RequireSecureOn &&
                                                  (_host.SecureOnPassword == null || _host.SecureOnPassword == PhysicalAddress.None);
            this.SecureOnPasswordControl.Value = _host.SecureOnPassword;

            foreach (WolHostNetwork CurrentNetwork in _host.Networks)
            {
                ListViewItem NetworkItem = new ListViewItem(new string[] {
                                                                    CurrentNetwork.Name,
                                                                    CurrentNetwork.Address,
                                                                });
                NetworkItem.Tag = CurrentNetwork;

                // Mark the default network with boldface. If there is only one network
                // defined then it is, by definition, the default.
                if ((CurrentNetwork.NetworkId == _host.DefaultNetwork) || (_host.Networks.Count == 1))
                {
                    NetworkItem.Font = new Font(this.NetworksListView.Font, FontStyle.Bold);
                }

                this.NetworksListView.Items.Add(NetworkItem);
            }

            this.NetworksListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        /// <summary>
        /// Populates the Host object with the values retrieved from the form controls.
        /// </summary>
        private void PopulateObjectFromControls()
        {
            _host.Description = String.IsNullOrEmpty(this.DescriptionTextBox.Text) ? null : this.DescriptionTextBox.Text;
            _host.Name = String.IsNullOrEmpty(this.DescriptiveNameTextBox.Text) ? null : this.DescriptiveNameTextBox.Text;
            _host.MachineAddress = this.HostPhysicalAddress.Value;
            _host.Owner = String.IsNullOrEmpty(this.OwnerTextBox.Text) ? null : this.OwnerTextBox.Text;

            _host.RequireSecureOn = this.SecureOnCheckBox.Checked;
            if (_host.RequireSecureOn)
            {
                _host.SecureOnPassword = this.SecureOnPasswordControl.Value;
            }
            else
            {
                _host.SecureOnPassword = null;
            }

            // Re-build the list of networks from the data in the list view.
            _host.Networks.Clear();
            foreach (ListViewItem CurrentNetwork in this.NetworksListView.Items)
            {
                _host.Networks.Add(CurrentNetwork.Tag as WolHostNetwork);
            }
        }

        /// <summary>
        /// Updates controls to set the form into a read-only state.
        /// </summary>
        private void SetReadOnly()
        {
            foreach (Control ChildControl in this.Controls)
            {
                if (ChildControl != AbortButton && (ChildControl is GroupBox == false))
                {
                    ChildControl.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Validation of the data supplied in the form controls to ensure that all required information
        /// has been provided for the options selected by the user.
        /// </summary>
        /// <returns>True if the data is valid.</returns>
        private bool ValidateData()
        {
            bool IsValid = true;
            StringBuilder ErrorMessages = new StringBuilder();

            if ((this.SecureOnPasswordControl.Value == null || this.SecureOnPasswordControl.Value == PhysicalAddress.None) &&
                this.SecureOnCheckBox.Checked &&
                this.SecureOnPromptCheckBox.Checked == false)
            {
                IsValid = false;
                ErrorMessages.AppendLine("SecureOn password must be supplied.");
            }

            if (this.NetworksListView.Items.Count < 1)
            {
                IsValid = false;
                ErrorMessages.AppendLine("At least one network must be defined.");
            }
                        
            if (IsValid == false)
            {
                MessageBox.Show(ErrorMessages.ToString(), "Host Properties Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return IsValid;
        }

        #endregion
    }
}