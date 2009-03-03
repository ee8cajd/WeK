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
using System.Windows.Forms;

using Madcow.ComponentModel;
using Madcow.Network.Management;
using Madcow.Wek.Components;
using Madcow.Wek.UI.Properties;

#endregion

namespace Madcow.Wek.UI
{
    /// <summary>
    /// Class implementing the main user interface of the WeK application.
    /// </summary>
    public partial class HostManagementForm : Form
    {
        #region Private Members

        private WolHostList _hostList;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the Host Management Form.
        /// </summary>
        public HostManagementForm()
        {
            InitializeComponent();

            this.HostMenuItem.DropDown = this.HostContextMenuStrip;

            InitialiseUI();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// DrawItem Event handler to handle custom drawing of ListViewItems in the Hosts ListView.
        /// </summary>
        /// <param name="sender">Reference to the HostsListView object.</param>
        /// <param name="e">Event specific data describing to the ListViewItem to be drawn.</param>
        private void HostsListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        /// <summary>
        /// Click Event handler for the Wake Selection button.
        /// </summary>
        /// <param name="sender">Reference to the WakeSelectionButton object.</param>
        /// <param name="e">Event specific data.</param>
        private void WakeSelectionButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem SelectedItem in this.HostsListView.SelectedItems)
            {
                WakeHost(SelectedItem.Tag as WolHost);
            }
        }

        /// <summary>
        /// Double Click Event handler for the Hosts ListView.
        /// </summary>
        /// <param name="sender">Reference to the HostsListView object.</param>
        /// <param name="e">Event specific data.</param>
        private void HostsListView_DoubleClick(object sender, EventArgs e)
        {
            if (this.HostsListView.SelectedItems.Count == 1)
            {
                WolHost SelectedHost = this.HostsListView.SelectedItems[0].Tag as WolHost;

                if (SelectedHost != null)
                {
                    switch ((HostDoubleClickAction)Enum.Parse(typeof(HostDoubleClickAction), Settings.Default.HostViewItemDoubleClickAction))
                    {
                        case HostDoubleClickAction.ShowProperties:
                            AmendWolHost(SelectedHost);
                            break;

                        case HostDoubleClickAction.Wake:
                            WakeHost(SelectedHost);
                            break;
                    }
                }
            }
        }


        /// <summary>
        /// FormClosing Event handler for the Host Management Form.
        /// </summary>
        /// <param name="sender">Reference to the HostManagementForm object.</param>
        /// <param name="e">Event specific data.</param>
        private void HostManagementForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_hostList.Modified)
            {
                DialogResult SavePrompt = MessageBox.Show("Configuration has been modified. Do you want to save the updates?",
                                                          "WakeUp Question",
                                                          MessageBoxButtons.YesNoCancel,
                                                          MessageBoxIcon.Exclamation,
                                                          MessageBoxDefaultButton.Button3);

                switch (SavePrompt)
                {
                    case DialogResult.Yes:
                        _hostList.Save();
                        break;

                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        /// <summary>
        /// ItemSelctionChanged Event handler for the Hosts ListView.
        /// </summary>
        /// <param name="sender">Reference to the HostsListView object.</param>
        /// <param name="e">Event specific data.</param>
        private void HostsListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            LockUnlockControls();
        }

        /// <summary>
        /// Click Event handler for the About This Application Menu Item.
        /// </summary>
        /// <param name="sender">Reference to the AboutWekMenuItem object.</param>
        /// <param name="e">Event specific data.</param>
        private void AboutWekMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutForm AboutBox = new AboutForm())
            {
                AboutBox.ShowDialog();
            }
        }

        /// <summary>
        /// Click Event handler for the Add Host Menu Item.
        /// </summary>
        /// <param name="sender">Reference to the AddHostMenuItem object.</param>
        /// <param name="e">Event specific data.</param>
        private void AddHostMenuItem_Click(object sender, EventArgs e)
        {
            WolHost NewHost = new WolHost();

            using (AmendHost AmendHostForm = new AmendHost(ActionMode.Add, NewHost))
            {
                if (AmendHostForm.ShowDialog(this) == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;

                    _hostList.Items.Add(NewHost);
                    AddHostListViewItem(NewHost);

                    this.Cursor = null;
                }
            }
        }

        /// <summary>
        /// Click Event handler for the Amend Host Menu Item.
        /// </summary>
        /// <param name="sender">Reference to the AmendHostMenuItem object.</param>
        /// <param name="e">Event specific data.</param>
        private void AmendHostMenuItem_Click(object sender, EventArgs e)
        {
            if (HostsListView.SelectedItems.Count > 0)
            {
                WolHost SelectedHost = this.HostsListView.SelectedItems[0].Tag as WolHost;

                if (SelectedHost != null)
                {
                    AmendWolHost(SelectedHost);
                }
            }
        }

        /// <summary>
        /// Click Event handler for the Awaken Host Menu Item.
        /// </summary>
        /// <param name="sender">Reference to the AwakenHostMenuItem object.</param>
        /// <param name="e">Event specific data.</param>
        private void AwakenHostMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            foreach (ListViewItem SelectedItem in this.HostsListView.SelectedItems)
            {
                WakeHost(SelectedItem.Tag as WolHost);
            }

            this.Cursor = null;
        }

        /// <summary>
        /// Click Event handler for the Exit Menu Item.
        /// </summary>
        /// <param name="sender">Reference to the ExitMenuItem object.</param>
        /// <param name="e">Event specific data.</param>
        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Click Event handler for the Options Menu Item.
        /// </summary>
        /// <param name="sender">Reference to the OptionsMenuItem object.</param>
        /// <param name="e">Event specific data.</param>
        private void OptionsMenuItem_Click(object sender, EventArgs e)
        {
            using (OptionsForm Options = new OptionsForm())
            {
                if (Options.ShowDialog() == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    this.HostsListView.SuspendLayout();

                    foreach (ListViewItem CurrentItem in this.HostsListView.Items)
                    {
                        UpdateHostListViewItem(CurrentItem, CurrentItem.Tag as WolHost);
                    }

                    this.HostsListView.ResumeLayout();
                    this.Cursor = null;
                }
            }
        }

        /// <summary>
        /// Click Event handler for the Remove Host Menu Item.
        /// </summary>
        /// <param name="sender">Reference to the RemoveHostMenuItem object.</param>
        /// <param name="e">Event specific data.</param>
        private void RemoveHostMenuItem_Click(object sender, EventArgs e)
        {
            if (this.HostsListView.SelectedItems.Count > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                this.HostsListView.BeginUpdate();

                foreach (ListViewItem CurrentItem in this.HostsListView.SelectedItems)
                {
                    _hostList.Items.Remove(CurrentItem.Tag as WolHost);
                    this.HostsListView.Items.Remove(CurrentItem);
                }

                this.HostsListView.EndUpdate();
                this.Cursor = null;
            }
        }

        /// <summary>
        /// Click Event handler for the Save Menu Item.
        /// </summary>
        /// <param name="sender">Reference to the SaveMenuItem object.</param>
        /// <param name="e">Event specific data.</param>
        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _hostList.Save();
            this.Cursor = null;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Private method to handle then atomic amendment of a Wake on LAN host.
        /// </summary>
        /// <param name="hostToAmend">The Wake on LAN which is to be amended.</param>
        private void AmendWolHost(WolHost hostToAmend)
        {
            WolHost ClonedHost = hostToAmend.Clone();

            using (AmendHost AmendHostForm = new AmendHost(ActionMode.Amend, ClonedHost))
            {
                if (AmendHostForm.ShowDialog(this) == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;

                    _hostList.Items.Remove(hostToAmend);
                    _hostList.Items.Add(ClonedHost);

                    UpdateHostListViewItem(this.HostsListView.SelectedItems[0], ClonedHost);

                    this.Cursor = null;
                }
            }
        }

        /// <summary>
        /// Helper method to return the index of an image in the Large Image List bound to
        /// the HostsListView based on whether a WoL host requires SecureOn Authentication.
        /// </summary>
        /// <param name="secureOnRequired">Flag to indicate whether the host requires SecureOn Authentication.</param>
        /// <returns>The integer index of the icon to display for the host in the HostsListView.</returns>
        private int GetMachineIconIndex(bool secureOnRequired)
        {
            string IconKey = (secureOnRequired && Settings.Default.ShowSecureOnHostHint ? "SecureOnWolHost" : "NormalWolHost");

            return this.HostsListView.LargeImageList.Images.IndexOfKey(IconKey);
        }

        /// <summary>
        /// Method handling all initialisation of the UI.
        /// </summary>
        private void InitialiseUI()
        {
            this.Cursor = Cursors.WaitCursor;
            this.HostsListView.BeginUpdate();

            try
            {
                _hostList = new WolHostList();
                if (_hostList.Load())
                {
                    foreach (WolHost CurrentHost in _hostList.Items)
                    {
                        AddHostListViewItem(CurrentHost);
                    }
                }

                this.HostsListView.View = View.Tile;
            }
            finally
            {
                this.HostsListView.EndUpdate();
            }

            LockUnlockControls();

            this.Cursor = null;
        }

        /// <summary>
        /// Method to update the availability of UI controls based on the current context.
        /// </summary>
        private void LockUnlockControls()
        {
            this.AmendHostMenuItem.Enabled = (this.HostsListView.SelectedItems.Count == 1);

            if (this.HostsListView.SelectedItems.Count > 0)
            {
                this.RemoveHostMenuItem.Enabled = true;
                this.WakeSelectionButton.Enabled = true;
                this.AwakenHostMenuItem.Enabled = true;
            }
            else
            {
                this.RemoveHostMenuItem.Enabled = false;
                this.WakeSelectionButton.Enabled = false;
                this.AwakenHostMenuItem.Enabled = false;
            }
        }

        /// <summary>
        /// Adds a new host to the Host ListView using the property options configured in the config file.
        /// </summary>
        /// <param name="host">The host to add.</param>
        /// <returns>The ListViewItem added.</returns>
        private ListViewItem AddHostListViewItem(WolHost host)
        {
            ListViewItem NewHostItem = new ListViewItem();
            NewHostItem.Text = GetProperty<WolHost, string>(host, Settings.Default.HostViewItemFirstLineProperty);
            NewHostItem.SubItems.AddRange(new string[] { 
                                            GetProperty<WolHost, string>(host, Settings.Default.HostViewItemSecondLineProperty),
                                            GetProperty<WolHost, string>(host, Settings.Default.HostViewItemThirdLineProperty)
                                          });
            NewHostItem.ImageIndex = GetMachineIconIndex(host.RequireSecureOn);
            NewHostItem.Tag = host;

            return this.HostsListView.Items.Add(NewHostItem);
        }

        /// <summary>
        /// Updates an item in the Hosts ListView with the details for the given WolHost using the
        /// property options configured in the config file.
        /// </summary>
        /// <param name="item">The ListViewItem to update.</param>
        /// <param name="host">The host details used to refresh the ListViewItem.</param>
        private void UpdateHostListViewItem(ListViewItem item, WolHost host)
        {
            item.ImageIndex = GetMachineIconIndex(host.RequireSecureOn);
            item.SubItems[0].Text = GetProperty<WolHost, string>(host, Settings.Default.HostViewItemFirstLineProperty);
            item.SubItems[1].Text = GetProperty<WolHost, string>(host, Settings.Default.HostViewItemSecondLineProperty);
            item.SubItems[2].Text = GetProperty<WolHost, string>(host, Settings.Default.HostViewItemThirdLineProperty);
            item.Tag = host;
        }

        /// <summary>
        /// Helper function to retrieve the value of a property on a given object.
        /// </summary>
        /// <typeparam name="TSource">The type of the source object whose properties are to be enumerated.</typeparam>
        /// <typeparam name="TReturn">The type of the property being retrieved.</typeparam>
        /// <param name="source">The source object whose properties are to be enumerated.</param>
        /// <param name="propertyName">The name of the property on the source object for which to return the value.</param>
        /// <returns>The value of the property of interest.</returns>
        private static TReturn GetProperty<TSource, TReturn>(TSource source, string propertyName)
        {
            object Result = null;

            Type SourceType = typeof(TSource);
            DefaultFormatStringAttribute SourceFormatAttribute = null;

            // Get the PropertyInfo for the property of interest on the source type.
            PropertyInfo SourcePropertyInfo = SourceType.GetProperty(propertyName);

            // Check for Custom Attributes.
            foreach (object SourcePropertyAttribute in SourcePropertyInfo.GetCustomAttributes(false))
            {
                if (SourcePropertyAttribute is DefaultFormatStringAttribute)
                {
                    // The property has beenn marked with a Default Format String attribute which
                    // should be used to return the value.
                    SourceFormatAttribute = SourcePropertyAttribute as DefaultFormatStringAttribute;
                }
            }

            if(SourceFormatAttribute != null)
            {
                // The type of the property of interest on the source type must implement IFormattable
                // for the DefaultFormatStringAttribute to make any sense. The following will therefore
                // raise an exception if the type of the property of interest doesn't meet this requirement.
                IFormattable FormattableValue = (IFormattable)SourcePropertyInfo.GetValue(source, null);
                Result = FormattableValue.ToString(SourceFormatAttribute.FormatString, null);
            }
            else
            {
                Result = SourcePropertyInfo.GetValue(source, null);
            }

            return (TReturn)Result;
        }

        /// <summary>
        /// Wakes a host, handling any required SecureOn password prompting.
        /// </summary>
        /// <param name="hostToWake">The WolHost object describing the host to wake.</param>
        private void WakeHost(WolHost hostToWake)
        {
            if (hostToWake != null)
            {
                if (hostToWake.RequireSecureOn == false)
                {
                    hostToWake.Weight++;
                    WakeOnLan.WakeMachine(hostToWake.MachineAddress);
                }
                else
                {
                    // Check to see whether the SecureOn Password needs to be prompted.
                    if (hostToWake.SecureOnPassword == null || hostToWake.SecureOnPassword == PhysicalAddress.None)
                    {
                        using (SecureOnPromptForm SecureOnPrompt = new SecureOnPromptForm(hostToWake))
                        {
                            if (SecureOnPrompt.ShowDialog() == DialogResult.OK)
                            {
                                // Use the supplied SecureOn Password.
                                hostToWake.Weight++;
                                WakeOnLan.WakeMachine(hostToWake.MachineAddress, SecureOnPrompt.SecureOnPassword);
                            }
                        }
                    }
                    else
                    {
                        // Use the stored SecureOn Password.
                        hostToWake.Weight++;
                        WakeOnLan.WakeMachine(hostToWake.MachineAddress, hostToWake.SecureOnPassword);
                    }
                }
            }
        }

        #endregion
    }
}