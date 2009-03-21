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

#endregion

namespace Madcow.Wek.UI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class AboutForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public AboutForm()
        {
            InitializeComponent();

            InitialiseUI();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ExecutingAssembly"></param>
        private void InitialiseUI()
        {
            foreach (object CustomAttribute in Assembly.GetExecutingAssembly().GetCustomAttributes(false))
            {
                if (CustomAttribute is AssemblyTitleAttribute)
                {
                    this.ApplicationDescriptionLabel.Text = ((AssemblyTitleAttribute)CustomAttribute).Title;
                }
                else if (CustomAttribute is AssemblyCopyrightAttribute)
                {
                    this.CopyrightLabel.Text = ((AssemblyCopyrightAttribute)CustomAttribute).Copyright;
                }
                else if (CustomAttribute is AssemblyProductAttribute)
                {
                    this.ApplicationNameLabel.Text = ((AssemblyProductAttribute)CustomAttribute).Product;
                }
                else if (CustomAttribute is AssemblyFileVersionAttribute)
                {
                    this.VersionLabel.Text = String.Format(this.VersionLabel.Text, ((AssemblyFileVersionAttribute)CustomAttribute).Version);
                }
            }

			this.linkLabel1.Links.Add(new LinkLabel.Link(0, this.linkLabel1.Text.Length, this.linkLabel1.Text));
			this.LicenseLinkLabel.Links.Add(new LinkLabel.Link(0, this.LicenseLinkLabel.Text.Length, this.LicenseLinkLabel.Text));
        }

		#region Event Handlers

		/// <summary>
		/// Click event handler for LinkLabel controls.
		/// </summary>
		/// <param name="sender">The LinkLabel control raising the event.</param>
		/// <param name="e">Event specific data.</param>
		protected void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string LinkTarget = e.Link.LinkData as string;

			if(LinkTarget != null)
			{
				try
				{
					System.Diagnostics.Process.Start(LinkTarget);
				}
				catch
				{
					MessageBox.Show(String.Format("Unable to launch '{0}'.", LinkTarget), 
									"About WeK",
									MessageBoxButtons.OK,
									MessageBoxIcon.Error);
				}
			}
		}

		#endregion
    }
}
