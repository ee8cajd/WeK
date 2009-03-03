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
using System.Text;
using System.Windows.Forms;

using Madcow.Network.Management;
using Madcow.Wek.Components;

#endregion

namespace Madcow.Wek.UI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class AmendHost : Form
    {
        #region Private Members

        private ActionMode _action;
        private WolHost _host;

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SecureOnCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.SecureOnPromptCheckBox.Enabled = this.SecureOnCheckBox.Checked;
            this.SecureOnPasswordControl.Enabled = this.SecureOnCheckBox.Checked &&
                                                   (this.SecureOnPromptCheckBox.Checked == false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// 
        /// </summary>
        private void InitialiseUI()
        {
            SetTitle();

            if (_action == ActionMode.View)
            {
                SetReadOnly();
            }
            else
            {
                LockUnlockControls();
            }

            PopulateControlsFromObject();
        }

        /// <summary>
        /// 
        /// </summary>
        private void LockUnlockControls()
        {
            this.SecureOnPromptCheckBox.Enabled = _host.RequireSecureOn;
            this.SecureOnPasswordControl.Enabled = _host.RequireSecureOn;
        }

        /// <summary>
        /// 
        /// </summary>
        private void PopulateControlsFromObject()
        {
            this.DescriptionTextBox.Text = _host.Description;
            this.DescriptiveNameTextBox.Text = _host.Name;
            this.HostPhysicalAddress.Value = _host.MachineAddress;
            this.OwnerTextBox.Text = _host.Owner;
            this.NetworkAddressTextBox.Text = _host.HostAddress;

            this.SecureOnCheckBox.Checked = _host.RequireSecureOn;
            this.SecureOnPromptCheckBox.Checked = _host.RequireSecureOn &&
                                                  (_host.SecureOnPassword == null || _host.SecureOnPassword == PhysicalAddress.None);
            this.SecureOnPasswordControl.Value = _host.SecureOnPassword;
        }

        /// <summary>
        /// 
        /// </summary>
        private void PopulateObjectFromControls()
        {
            _host.Description = String.IsNullOrEmpty(this.DescriptionTextBox.Text) ? null : this.DescriptionTextBox.Text;
            _host.Name = String.IsNullOrEmpty(this.DescriptiveNameTextBox.Text) ? null : this.DescriptiveNameTextBox.Text;
            _host.MachineAddress = this.HostPhysicalAddress.Value;
            _host.Owner = String.IsNullOrEmpty(this.OwnerTextBox.Text) ? null : this.OwnerTextBox.Text;
            _host.HostAddress = String.IsNullOrEmpty(this.NetworkAddressTextBox.Text) ? null : this.NetworkAddressTextBox.Text;

            _host.RequireSecureOn = this.SecureOnCheckBox.Checked;
            if (_host.RequireSecureOn)
            {
                _host.SecureOnPassword = this.SecureOnPasswordControl.Value;
            }
            else
            {
                _host.SecureOnPassword = null;
            }
        }

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        private void SetTitle()
        {
            switch (_action)
            {
                case ActionMode.Add:
                    this.Text = "New " + this.Text;
                    break;

                case ActionMode.Amend:
                case ActionMode.View:
                    this.Text = this.Text + " Properties";
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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

            if (IsValid == false)
            {
                MessageBox.Show(ErrorMessages.ToString(), "Amend Host Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return IsValid;
        }

        #endregion
    }
}