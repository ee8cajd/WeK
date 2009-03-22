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
using System.Drawing;
using System.Windows.Forms;

using Madcow.Network.Management;
using Madcow.Wek.Components;

#endregion

namespace Madcow.Wek.UI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SecureOnPromptForm : Form
    {
        #region Private Members

        private WolHost _host;

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public SecureOnPromptForm(WolHost host)
        {
            InitializeComponent();

            _host = host;

            InitialiseUI();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public PhysicalAddress SecureOnPassword
        {
            get { return this.SecureOnPasswordControl.Value; }
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SecureOnPromptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK && 
                (this.SecureOnPasswordControl.Value == null || this.SecureOnPasswordControl.Value == PhysicalAddress.None))
            {
                MessageBox.Show("SecureOn Password must be provided for this host.", 
                                "SecureOn Password",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        private void InitialiseUI()
        {
            this.SecureOnPasswordLabel.Text = String.Format(this.SecureOnPasswordLabel.Text, _host.Name);
        }

        #endregion
    }
}