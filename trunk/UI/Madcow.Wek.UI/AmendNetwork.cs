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
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

using Madcow.ComponentModel;
using Madcow.Wek.Components;
using Madcow.Wek.UI.Properties;

#endregion

namespace Madcow.Wek.UI
{
    /// <summary>
    /// Class implementing the form for amending the properties of a WolHostNetwork object.
    /// </summary>
    public partial class AmendNetwork : Form
    {
        #region Private Members

        private WolHostNetwork _network;
        private ActionMode _action;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates and initialises a new instance of the AmendNetwork form.
        /// </summary>
        /// <param name="action">The <see cref="ActionMode">amendment mode</see> in which the form will be operating.</param>
        /// <param name="network">The data object representing the network to be amended.</param>
        public AmendNetwork(ActionMode action, WolHostNetwork network)
        {
            InitializeComponent();

            _action = action;
            _network = network;

            InitialiseUI();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Form Closing event handler for the Amend Network form.
        /// </summary>
        /// <param name="sender">Reference to the AmendNetwork form.</param>
        /// <param name="e">Event specific data.</param>
        private void AmendNetwork_FormClosing(object sender, FormClosingEventArgs e)
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

        /// <summary>
        /// Selection Change Committed event handler for the Network Locality combo box.
        /// </summary>
        /// <param name="sender">Reference to the NetworkLocality combo box control.</param>
        /// <param name="e">Event specific data.</param>
        private void NetworkLocalityComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LockUnlockControls();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initialise the form before it is shown.
        /// </summary>
        private void InitialiseUI()
        {
            GuiHelper.SetTitle(this, _action);

            GuiHelper.PopulateComboFromEnum(this.NetworkLocalityComboBox,
                                            typeof(WolHostNetwork.NetworkLocality),
                                            Resources.ResourceManager);

            PopulateControlsFromObject();
            LockUnlockControls();
        }

        /// <summary>
        /// Enables or disables controls on the form according to view rules.
        /// </summary>
        private void LockUnlockControls()
        {
            // Subnet Mask is not required unless the network is a Remote Network.
            WolHostNetwork.NetworkLocality SelectedLocation = (WolHostNetwork.NetworkLocality)Enum.Parse(typeof(WolHostNetwork.NetworkLocality),
                                                                                                         this.NetworkLocalityComboBox.SelectedValue.ToString());
            this.HostSubnetMaskTextBox.Enabled = (SelectedLocation == WolHostNetwork.NetworkLocality.Remote);
        }

        /// <summary>
        /// Set the values of the controls on the form from the relevant data objects.
        /// </summary>
        private void PopulateControlsFromObject()
        {
            GuiHelper.SetControlText(this.NetworkNameTextBox, _network.Name);
            this.NetworkLocalityComboBox.SelectedValue = _network.Locality;
            GuiHelper.SetControlText(this.NetworkAddressTextBox, _network.Address);
            this.HostSubnetMaskTextBox.Text = (_network.SubnetMask != null) ? _network.SubnetMask.ToString() : null;
            this.HostPortNumericUpDown.Value = _network.Port;
        }

        /// <summary>
        /// Retrieve the values from the controls on the form and update the relevant data objects.
        /// </summary>
        private void PopulateObjectFromControls()
        {
            _network.Name = GuiHelper.GetControlText(this.NetworkNameTextBox);
            _network.Locality = (WolHostNetwork.NetworkLocality)this.NetworkLocalityComboBox.SelectedValue;
            _network.Address = GuiHelper.GetControlText(this.NetworkAddressTextBox);
            _network.Port = Convert.ToInt32(this.HostPortNumericUpDown.Value);

            IPAddress ParsedAddress;
            if (IPAddress.TryParse(this.HostSubnetMaskTextBox.Text, out ParsedAddress))
            {
                _network.SubnetMask = ParsedAddress;
            }
            else
            {
                _network.SubnetMask = IPAddress.None;
            }
        }

        /// <summary>
        /// Check that the data supplied via the controls on the form satisfies validation rules.
        /// </summary>
        /// <returns>True if the data passes validation.</returns>
        private bool ValidateData()
        {
            bool IsValid = true;
            StringBuilder ErrorMessages = new StringBuilder();

            if (String.IsNullOrEmpty(this.NetworkNameTextBox.Text))
            {
                IsValid = false;
                ErrorMessages.AppendLine("A Network Name must be provded.");
            }

            if (String.IsNullOrEmpty(this.NetworkAddressTextBox.Text))
            {
                IsValid = false;
                ErrorMessages.AppendLine("An Address must be provided.");
            }

            WolHostNetwork.NetworkLocality SelectedLocality = (WolHostNetwork.NetworkLocality)Enum.Parse(typeof(WolHostNetwork.NetworkLocality),
                                                                                                         this.NetworkLocalityComboBox.SelectedValue.ToString());
            if (SelectedLocality == WolHostNetwork.NetworkLocality.Remote && String.IsNullOrEmpty(this.HostSubnetMaskTextBox.Text))
            {
                IsValid = false;
                ErrorMessages.AppendLine("A subnet mask is required for remote networks.");
            }

            if (IsValid == false)
            {
                MessageBox.Show(ErrorMessages.ToString(), "Network Properties Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return IsValid;
        }

        #endregion
    }
}
