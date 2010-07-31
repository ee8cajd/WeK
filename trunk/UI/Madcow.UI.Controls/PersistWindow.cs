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
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using FxConfig = System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Madcow.UI.Controls.Configuration;

using Microsoft.Win32;

#endregion

namespace Madcow.UI.Controls
{
    /// <summary>
    /// Class implementing a component that persists and retrieves ambient properties of a form.
    /// </summary>
	[ToolboxItem(true)]
	public partial class PersistWindow : Component
	{
		#region Private Members

		private bool _attached;
        private string _applicationName;
        private string _formName;

		private ContainerControl _container;
		private Form _containerForm;

        private const string RegistrySubKeyName = "PersistWindow";

		#endregion

        #region Internal Constants

        internal static readonly string SettingItemWindowX = "x";
        internal static readonly string SettingItemWindowY = "y";
        internal static readonly string SettingItemWindowWidth = "w";
        internal static readonly string SettingItemWindowHeight = "h";
        internal static readonly string SettingItemWindowName = "name";
        internal static readonly string SettingItemWindowState = "State";

        #endregion

        #region Constructors

        /// <summary>
		/// 
		/// </summary>
		public PersistWindow()
		{
            _applicationName = null;
            _formName = null;
			
			InitializeComponent();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="container"></param>
		public PersistWindow(IContainer container)
		{
			container.Add(this);

            _applicationName = null;
            _formName = null;
			
			InitializeComponent();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="parentContainer"></param>
		public PersistWindow(ContainerControl parentContainer)
			: this()
		{
			this.ContainerControl = parentContainer;
		}

		#endregion

		#region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public string ApplicationName
        {
            get { return _applicationName; }
            set { _applicationName = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Browsable(false)]
		public bool Attached
		{
			get { return _attached; }
			set { _attached = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		[Browsable(false)]
		public ContainerControl ContainerControl
		{
			get { return _container; }
			set
			{
				DetachFromContainerForm();

				_container = value;
				
				AttachToContainerForm();
			}
		}

        /// <summary>
        /// 
        /// </summary>
        public string FormName
        {
            get { return _formName; }
            set { _formName = value; }
        }
		
		/// <summary>
		/// 
		/// </summary>
		public override ISite Site
		{
			get { return base.Site; }
			set
			{
				// This code is run by the IDE and allows access to the container in which this
				// object is hosted.
				base.Site = value;

				if (value != null)
				{
					IDesignerHost DesignerHost = value.GetService(typeof(IDesignerHost)) as IDesignerHost;

					if (DesignerHost != null)
					{
						IComponent ComponentHost = DesignerHost.RootComponent;

						if (ComponentHost is ContainerControl)
						{
							this.ContainerControl = ComponentHost as ContainerControl;
						}
					}
				}
			}
		}

		#endregion

		#region Event Handlers

		/// <summary>
		/// Closing Event handler to receive event notifications raised by the component's container.
		/// </summary>
		/// <param name="sender">The Form object that is the container of this component.</param>
		/// <param name="e">Event specific data.</param>
        private void ContainerFormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Rectangle Bounds = (_containerForm.WindowState == FormWindowState.Normal) ? _containerForm.Bounds : _containerForm.RestoreBounds;

                // Attempt to persist the current form layout to a roaming configuration file.
                FxConfig.Configuration ConfigFile = FxConfig.ConfigurationManager.OpenExeConfiguration(FxConfig.ConfigurationUserLevel.PerUserRoamingAndLocal);
                if (ConfigFile != null)
                {
                    PersistWindowSection Section = ConfigFile.GetSection("persistWindow") as PersistWindowSection;
                    PersistWindowFormElement LayoutStorage = Section.Forms[this.FormName];

                    if (LayoutStorage != null)
                    {
                        LayoutStorage.X = Bounds.X;
                        LayoutStorage.Y = Bounds.Y;
                        LayoutStorage.Width = Bounds.Width;
                        LayoutStorage.Height = Bounds.Height;
                        LayoutStorage.State = _containerForm.WindowState;
                    }
                    else
                    {
                        PersistWindowFormElement FormElement = new PersistWindowFormElement();
                        FormElement.Name = this.FormName;
                        FormElement.X = Bounds.X;
                        FormElement.Y = Bounds.Y;
                        FormElement.Width = Bounds.Width;
                        FormElement.Height = Bounds.Height;
                        FormElement.State = _containerForm.WindowState;

                        FormElement.LockItem = false;

                        Section.Forms.Add(FormElement);
                    }

                    ConfigFile.Save(FxConfig.ConfigurationSaveMode.Modified);
                }
                else if (String.IsNullOrEmpty(this.ApplicationName) == false && String.IsNullOrEmpty(this.FormName) == false)
                {
                    // Attempt to persist to the registry if the configuration file cannot be updated.
                    string KeyName = Path.Combine(this.ApplicationName, Path.Combine(RegistrySubKeyName, this.FormName));
                    using (RegistryKey WekRegistry = Registry.CurrentUser.CreateSubKey(KeyName))
                    {
                        if (WekRegistry != null)
                        {
                            WekRegistry.SetValue(PersistWindow.SettingItemWindowX, Bounds.X, RegistryValueKind.DWord);
                            WekRegistry.SetValue(PersistWindow.SettingItemWindowY, Bounds.Y, RegistryValueKind.DWord);

                            WekRegistry.SetValue(PersistWindow.SettingItemWindowWidth, Bounds.Width, RegistryValueKind.DWord);
                            WekRegistry.SetValue(PersistWindow.SettingItemWindowHeight, Bounds.Height, RegistryValueKind.DWord);

                            WekRegistry.SetValue(PersistWindow.SettingItemWindowState, _containerForm.WindowState, RegistryValueKind.String);
                        }
                    }
                }
            }
            catch
            {
#if DEBUG
                throw;
#endif
            }
        }

		/// <summary>
		/// Load Event handler to receive event notifications raised by the component's container.
		/// </summary>
		/// <param name="sender">The Form object that is the container of this component.</param>
		/// <param name="e">Event specific data.</param>
		private void ContainerFormLoad(object sender, EventArgs e)
		{
			if (_containerForm != null && String.IsNullOrEmpty(_applicationName) == false && String.IsNullOrEmpty(_formName) == false)
			{
				try
				{
                    PersistWindowSection ConfigSection = PersistWindowSection.GetSection();
                    if (ConfigSection != null)
                    {
                        PersistWindowFormElement PersistedLayout = ConfigSection.Forms[this.FormName];
                        if (PersistedLayout != null)
                        {
                            UpdateFormPositionAndSize(PersistedLayout.X,
                                                      PersistedLayout.Y,
                                                      PersistedLayout.Width,
                                                      PersistedLayout.Height,
                                                      PersistedLayout.State);
                        }
                    }
                    else if (String.IsNullOrEmpty(this.ApplicationName) == false && String.IsNullOrEmpty(this.FormName) == false)
                    {
                        string KeyName = Path.Combine(this.ApplicationName, Path.Combine(RegistrySubKeyName, this.FormName));
                        using (RegistryKey WekRegistry = Registry.CurrentUser.CreateSubKey(KeyName))
                        {
                            if (WekRegistry != null)
                            {
                                UpdateFormPositionAndSize(Convert.ToInt32(WekRegistry.GetValue(PersistWindow.SettingItemWindowX, -1)),
                                                          Convert.ToInt32(WekRegistry.GetValue(PersistWindow.SettingItemWindowY, -1)),
                                                          Convert.ToInt32(WekRegistry.GetValue(PersistWindow.SettingItemWindowWidth, -1)),
                                                          Convert.ToInt32(WekRegistry.GetValue(PersistWindow.SettingItemWindowHeight, -1)),
                                                          ParseFormWindowStateString(WekRegistry.GetValue(PersistWindow.SettingItemWindowHeight, "Normal")));
                            }
                        }
                    }
				}
				catch
				{
#if DEBUG
                    throw;
#endif
				}
			}
		}

		#endregion

        #region Internal Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateString"></param>
        /// <returns></returns>
        internal static FormWindowState ParseFormWindowStateString(object stateString)
        {
            return ParseFormWindowStateString(stateString.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateString"></param>
        /// <returns></returns>
        internal static FormWindowState ParseFormWindowStateString(string stateString)
        {
            FormWindowState Result = FormWindowState.Normal;

            try
            {
                Result = (FormWindowState)Enum.Parse(typeof(FormWindowState), stateString, true);
            }
            catch
            {
            }

            return Result;
        }

        #endregion

        #region Private Methods

        /// <summary>
		/// Wire up event handlers to events raised by the containing Form object.
		/// </summary>
		private void AttachToContainerForm()
		{
			_containerForm = this.ContainerControl as Form;
			this.Attached = (_containerForm != null);

			if (this.Attached)
			{
				_containerForm.FormClosing += ContainerFormClosing;
				_containerForm.Load += ContainerFormLoad;
			}
		}

		/// <summary>
		/// Disconnect event handlers wired-up to the containing Form object.
		/// </summary>
		private void DetachFromContainerForm()
		{
			if (_containerForm != null)
			{
				_containerForm.Load -= ContainerFormLoad;
				_containerForm.FormClosing -= ContainerFormClosing;
			}
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private void UpdateFormPositionAndSize(int x, int y, int width, int height, FormWindowState state)
        {
            if (x > -1 && y > -1 && width > -1 && height > -1)
            {
                _containerForm.SuspendLayout();
                _containerForm.StartPosition = FormStartPosition.Manual;
                _containerForm.SetDesktopLocation(x, y);
                _containerForm.Size = new Size(width, height);
                _containerForm.WindowState = state;
                _containerForm.ResumeLayout();
            }
        }

		#endregion
    }
}
