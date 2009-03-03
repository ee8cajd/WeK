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
using System.Windows.Forms;

using Madcow.Network.Management;

#endregion

namespace Madcow.Wek.UI.Controls
{
    /// <summary>
    /// UI control for the display and/or entry of a Machine Physical Address. The behaviour 
    /// of the caret in this control is based on that seen in SysIPAddress32.
    /// </summary>
    public partial class PhysicalAddressControl : UserControl
    {
        #region Private Members

        private Keys _previousKey;

        private Color _backColour;
        private Color _foreColour;

        private TextBox[] _macOctetTextBoxes;
        private TextBox _octetInFocus;

        private OctetSeparator _separator;

        private int _lastMacTextBoxIndex;
        private int _lengthAtKeyDown;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the PhysicalAddress UI Control.
        /// </summary>
        public PhysicalAddressControl()
        {
            InitializeComponent();

            _macOctetTextBoxes = new TextBox[] { this.MacOctetOneTextBox,
                                                 this.MacOctetTwoTextBox,
                                                 this.MacOctetThreeTextBox,
                                                 this.MacOctetFourTextBox,
                                                 this.MacOctetFiveTextBox,
                                                 this.MacOctetSixTextBox };

            // The last octet will be referred to frequently, so make it easy to identify.
            _lastMacTextBoxIndex = _macOctetTextBoxes.GetUpperBound(0);

            _separator = OctetSeparator.Colon;

            _backColour = SystemColors.Window;
            _foreColour = SystemColors.ControlText;

            this.BackColor = _backColour;
            this.ForeColor = _foreColour;
        }

        #endregion

        #region Public Enumerations

        /// <summary>
        /// Enumeration describing the possible octet separators.
        /// </summary>
        public enum OctetSeparator
        {
            Colon = 1,
            Dash
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(typeof(Color), "Window")]
        public new Color BackColor
        {
            get { return _backColour; }
            set
            {
                _backColour = value;

                if (base.Enabled)
                {
                    this.SuspendLayout();

                    base.BackColor = value;

                    foreach (Control ChildControl in this.Controls)
                    {
                        ChildControl.BackColor = value;
                    }

                    this.ResumeLayout();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(BorderStyle.Fixed3D), Category("Appearance")]
        public new BorderStyle BorderStyle
        {
            get { return base.BorderStyle; }
            set { base.BorderStyle = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        //[DefaultValue(typeof(Cursor), "IBeam")]
        public new Cursor Cursor
        {
            get { return base.Cursor; }
            set
            {
                foreach (Control ChildControl in this.Controls)
                {
                    ChildControl.Cursor = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(true)]
        public new bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                base.Enabled = value;
                base.BackColor = value ? _backColour : SystemColors.Control;
                base.ForeColor = value ? _foreColour : SystemColors.GrayText;

                foreach (Control ChildControl in this.Controls)
                {
                    if (ChildControl is TextBox)
                    {
                        ChildControl.Enabled = value;
                    }

                    ChildControl.BackColor = value ? _backColour : SystemColors.Control;
                    ChildControl.ForeColor = value ? _foreColour : SystemColors.GrayText;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public new Font Font
        {
            get { return base.Font; }
            set
            {
                this.SuspendLayout();

                base.Font = value;

                foreach (Control ChildControl in this.Controls)
                {
                    ChildControl.Font = value;
                }

                this.ResumeLayout();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(typeof(Color), "ControlText")]
        public new Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                _foreColour = value;

                if (base.Enabled)
                {
                    base.ForeColor = value;

                    foreach (Control ChildControl in this.Controls)
                    {
                        ChildControl.ForeColor = value;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public override Size MinimumSize
        {
            get { return base.MinimumSize; }
            set {  }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(PhysicalAddressControl.OctetSeparator.Colon)]
        [Category("Appearance"), Browsable(true)]
        [Description("Gets or sets the separator type to display between the Physical Address octets.")]
        public OctetSeparator Separator
        {
            get { return _separator; }
            set
            {
                _separator = value;

                foreach (Control CurrentControl in this.Controls)
                {
                    if (CurrentControl is Label)
                    {
                        switch (_separator)
                        {
                            case OctetSeparator.Colon:
                                CurrentControl.Text = ":";
                                break;

                            case OctetSeparator.Dash:
                                CurrentControl.Text = "-";
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(typeof(PhysicalAddress), "None"), Browsable(false)]
        public PhysicalAddress Value
        {
            get
            {
                byte[] MacBytes = new byte[6];
                bool AllEmpty = true;

                try
                {
                    for (int i = 0; i < _macOctetTextBoxes.Length; i++)
                    {
                        if (String.IsNullOrEmpty(_macOctetTextBoxes[i].Text) == false)
                        {
                            AllEmpty = false;
                            MacBytes[i] = Convert.ToByte(_macOctetTextBoxes[i].Text, 16);
                        }
                    }
                }
                catch (FormatException)
                {
                    AllEmpty = true;
                }

                return (AllEmpty == false ? new PhysicalAddress(MacBytes) : PhysicalAddress.None);
            }

            set
            {
                this.Clear();

                if (value != null)
                {
                    for (int i = 0; i < value.GetAddressBytes().Length; i++)
                    {
                        _macOctetTextBoxes[i].Text = value.GetAddressBytes()[i].ToString("X2");
                    }
                }
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Clears the current Physical Address value.
        /// </summary> 
        public void Clear()
        {
            for (int i = 0; i < _macOctetTextBoxes.Length; i++)
            {
                _macOctetTextBoxes[i].Clear();
            }
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MacByteTextBox_Enter(object sender, EventArgs e)
        {
            _octetInFocus = sender as TextBox;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MacByteTextBox_Leave(object sender, EventArgs e)
        {
            TextBox MacByteTextBox = sender as TextBox;
            if (String.IsNullOrEmpty(MacByteTextBox.Text) == false)
            {
                MacByteTextBox.Text = Convert.ToInt32(MacByteTextBox.Text, 16).ToString("X2");
            }

            _octetInFocus = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MacByteTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox MacByteTextBox = sender as TextBox;

            switch (e.KeyCode)
            {
                default:
                    if (IsValidHexKey(e.KeyCode, e.Modifiers))
                    {
                        if (MacByteTextBox.Text.Length == 2 && _lengthAtKeyDown != 2)
                        {
                            SelectNextOctet(true);
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MacOctetTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox MacByteTextBox = sender as TextBox;
            int OctetInFocusIndex;

            _lengthAtKeyDown = MacByteTextBox.Text.Length;

            switch (e.KeyCode)
            {
                case Keys.Back:
                    if ((String.IsNullOrEmpty(MacByteTextBox.Text) && MacByteTextBox != _macOctetTextBoxes[0]) ||
                        MacByteTextBox.SelectionStart == 0 && 
                        MacByteTextBox.SelectionLength != MacByteTextBox.Text.Length)
                    {
                        OctetInFocusIndex = Convert.ToInt32(MacByteTextBox.Tag);
                        if (OctetInFocusIndex > 0)
                        {
                            TextBox NextOctet = _macOctetTextBoxes[OctetInFocusIndex - 1];

                            if (NextOctet.Text.Length > 0)
                            {
                                NextOctet.Text = NextOctet.Text.Substring(0, NextOctet.Text.Length - 1);
                            }

                            // Change the focus to the next octet and eat the keypress.
                            SelectOctet(NextOctet, true);
                            e.SuppressKeyPress = true;
                        }
                    }
                    break;

                case Keys.Delete:
                    if ((String.IsNullOrEmpty(MacByteTextBox.Text) && MacByteTextBox != _macOctetTextBoxes[_lastMacTextBoxIndex]) ||
                        MacByteTextBox.SelectionStart == MacByteTextBox.Text.Length && 
                        MacByteTextBox.SelectionLength != MacByteTextBox.Text.Length)
                    {
                        OctetInFocusIndex = Convert.ToInt32(MacByteTextBox.Tag);
                        if (OctetInFocusIndex < _lastMacTextBoxIndex)
                        {
                            TextBox NextOctet = _macOctetTextBoxes[OctetInFocusIndex + 1];

                            if (NextOctet.Text.Length > 0)
                            {
                                NextOctet.Text = NextOctet.Text.Substring(1);
                            }

                            // Change the focus to the next octet and eat the keypress.
                            SelectOctet(NextOctet, false);
                            e.SuppressKeyPress = true;
                        }
                    }
                    break;

                case Keys.Left:
                    if (MacByteTextBox.SelectionStart == 0)
                    {
                        SelectNextOctet(false);
                    }
                    break;

                case Keys.Right:
                    if (MacByteTextBox.SelectionStart == MacByteTextBox.Text.Length)
                    {
                        SelectNextOctet(true);
                    }
                    break;

                case Keys.End:
                    // Jump to the end of the current octet unless the last keypress was also
                    // the End key, in which case jump to the end of the last octet.
                    if (_previousKey == Keys.End)
                    {
                        SelectOctet(_macOctetTextBoxes[_lastMacTextBoxIndex], true);

                        e.SuppressKeyPress = true;
                    }
                    break;

                case Keys.Home:
                    // Jump to the start of the current octet unless the last keypress was also
                    // the Home key, in which case jump to the start of the first octet.
                    if (_previousKey == Keys.Home)
                    {
                        SelectOctet(_macOctetTextBoxes[0], false);
                     
                        e.SuppressKeyPress = true;
                    }
                    break;

                default:
                    e.SuppressKeyPress = (MacByteTextBox.Text.Length == 2) || (IsValidHexKey(e.KeyCode, e.Modifiers) == false);
                    break;
            }

            _previousKey = e.KeyCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhysicalAddressControl_NcClick(object sender, EventArgs e)
        {
            if (_octetInFocus == null)
            {
                _macOctetTextBoxes[0].Select();
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="forward"></param>
        /// <returns></returns>
        protected override bool ProcessTabKey(bool forward)
        {
            return base.SelectNextControl(_macOctetTextBoxes[(forward ? _lastMacTextBoxIndex : 0)], forward, true, true, false);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Determines whether the given key is a valid hexadecimal digit.
        /// </summary>
        /// <param name="keyValue">The key value to test.</param>
        /// <returns>True if the key is a valid hexadecimal digit.</returns>
        private bool IsValidHexKey(Keys keyValue, Keys modifiers)
        {
            return ((modifiers & Keys.Shift) == Keys.None && (keyValue >= Keys.D0 && keyValue <= Keys.D9) ||
                   (keyValue >= Keys.NumPad0 && keyValue <= Keys.NumPad9)) ||
                   ((modifiers & Keys.Control) == Keys.None && keyValue >= Keys.A && keyValue <= Keys.F);
        }

        /// <summary>
        /// Selects the next Octet TextBox starting at the Octet TextBox currently in focus 
        /// and moving in the specified direction.
        /// </summary>
        /// <param name="forward">The direction of movement. True indicates to move forward.</param>
        private void SelectNextOctet(bool forward)
        {
            SelectNextOctet(_octetInFocus, forward);
        }

        /// <summary>
        /// Selects the next Octet TextBox starting at the given Octet TextBox and moving in 
        /// the specified direction.
        /// </summary>
        /// <param name="currentOctet">The Octet TextBox to start from.</param>
        /// <param name="forward">The direction of movement. True indicates to move forward.</param>
        private void SelectNextOctet(TextBox currentOctet, bool forward)
        {
            int OctetInFocusIndex = Convert.ToInt32(currentOctet.Tag);
            bool NextControlAvailable = (forward ? OctetInFocusIndex < _lastMacTextBoxIndex : OctetInFocusIndex > 0);

            if (NextControlAvailable)
            {
                SelectOctet(_macOctetTextBoxes[OctetInFocusIndex + (forward ? 1 : -1)], !forward);
            }
        }

        /// <summary>
        /// Selects a specific Octet TextBox with control over the initial caret placement.
        /// </summary>
        /// <param name="octet">The TextBox to select.</param>
        /// <param name="caretToEnd">Flag to indicate that the caret should be positioned at the end of any current content.</param>
        private void SelectOctet(TextBox octet, bool caretToEnd)
        {
            octet.Select();
            octet.SelectionStart = (caretToEnd ? octet.Text.Length : 0);
            octet.SelectionLength = 0;
        }

        #endregion
    }
}
