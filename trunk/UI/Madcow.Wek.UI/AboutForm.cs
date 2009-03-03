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
        }
    }
}