namespace Madcow.Wek.UI
{
    partial class AmendNetwork
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.HostPortNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.HostPortLabel = new System.Windows.Forms.Label();
            this.HostSubnetMaskTextBox = new System.Windows.Forms.TextBox();
            this.HostSubnetMaskLabel = new System.Windows.Forms.Label();
            this.NetworkAddressTextBox = new System.Windows.Forms.TextBox();
            this.NetworkAddressLabel = new System.Windows.Forms.Label();
            this.CommitButton = new System.Windows.Forms.Button();
            this.AbortButton = new System.Windows.Forms.Button();
            this.NetworkNameLabel = new System.Windows.Forms.Label();
            this.NetworkNameTextBox = new System.Windows.Forms.TextBox();
            this.NetworkLocalityLabel = new System.Windows.Forms.Label();
            this.NetworkLocalityComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.HostPortNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // HostPortNumericUpDown
            // 
            this.HostPortNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HostPortNumericUpDown.Location = new System.Drawing.Point(15, 147);
            this.HostPortNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.HostPortNumericUpDown.Name = "HostPortNumericUpDown";
            this.HostPortNumericUpDown.Size = new System.Drawing.Size(70, 21);
            this.HostPortNumericUpDown.TabIndex = 7;
            // 
            // HostPortLabel
            // 
            this.HostPortLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HostPortLabel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.HostPortLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.HostPortLabel.Location = new System.Drawing.Point(12, 131);
            this.HostPortLabel.Name = "HostPortLabel";
            this.HostPortLabel.Size = new System.Drawing.Size(254, 13);
            this.HostPortLabel.TabIndex = 6;
            this.HostPortLabel.Text = "Port:";
            // 
            // HostSubnetMaskTextBox
            // 
            this.HostSubnetMaskTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HostSubnetMaskTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.HostSubnetMaskTextBox.Location = new System.Drawing.Point(15, 186);
            this.HostSubnetMaskTextBox.Name = "HostSubnetMaskTextBox";
            this.HostSubnetMaskTextBox.Size = new System.Drawing.Size(155, 21);
            this.HostSubnetMaskTextBox.TabIndex = 9;
            // 
            // HostSubnetMaskLabel
            // 
            this.HostSubnetMaskLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HostSubnetMaskLabel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.HostSubnetMaskLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.HostSubnetMaskLabel.Location = new System.Drawing.Point(12, 170);
            this.HostSubnetMaskLabel.Name = "HostSubnetMaskLabel";
            this.HostSubnetMaskLabel.Size = new System.Drawing.Size(254, 13);
            this.HostSubnetMaskLabel.TabIndex = 8;
            this.HostSubnetMaskLabel.Text = "Host Subnet Mask:";
            // 
            // NetworkAddressTextBox
            // 
            this.NetworkAddressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NetworkAddressTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.NetworkAddressTextBox.Location = new System.Drawing.Point(15, 107);
            this.NetworkAddressTextBox.Name = "NetworkAddressTextBox";
            this.NetworkAddressTextBox.Size = new System.Drawing.Size(251, 21);
            this.NetworkAddressTextBox.TabIndex = 5;
            // 
            // NetworkAddressLabel
            // 
            this.NetworkAddressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NetworkAddressLabel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.NetworkAddressLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.NetworkAddressLabel.Location = new System.Drawing.Point(12, 91);
            this.NetworkAddressLabel.Name = "NetworkAddressLabel";
            this.NetworkAddressLabel.Size = new System.Drawing.Size(254, 13);
            this.NetworkAddressLabel.TabIndex = 4;
            this.NetworkAddressLabel.Text = "Host Name or IP Address:";
            // 
            // CommitButton
            // 
            this.CommitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CommitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CommitButton.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.CommitButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CommitButton.Location = new System.Drawing.Point(101, 217);
            this.CommitButton.Name = "CommitButton";
            this.CommitButton.Size = new System.Drawing.Size(80, 25);
            this.CommitButton.TabIndex = 10;
            this.CommitButton.Text = "OK";
            this.CommitButton.UseVisualStyleBackColor = true;
            // 
            // AbortButton
            // 
            this.AbortButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AbortButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.AbortButton.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.AbortButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AbortButton.Location = new System.Drawing.Point(187, 217);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(80, 25);
            this.AbortButton.TabIndex = 11;
            this.AbortButton.Text = "Cancel";
            this.AbortButton.UseVisualStyleBackColor = true;
            // 
            // NetworkNameLabel
            // 
            this.NetworkNameLabel.Location = new System.Drawing.Point(12, 10);
            this.NetworkNameLabel.Name = "NetworkNameLabel";
            this.NetworkNameLabel.Size = new System.Drawing.Size(254, 13);
            this.NetworkNameLabel.TabIndex = 0;
            this.NetworkNameLabel.Text = "Network Name:";
            // 
            // NetworkNameTextBox
            // 
            this.NetworkNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NetworkNameTextBox.Location = new System.Drawing.Point(15, 26);
            this.NetworkNameTextBox.Name = "NetworkNameTextBox";
            this.NetworkNameTextBox.Size = new System.Drawing.Size(251, 21);
            this.NetworkNameTextBox.TabIndex = 1;
            // 
            // NetworkLocalityLabel
            // 
            this.NetworkLocalityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NetworkLocalityLabel.Location = new System.Drawing.Point(12, 50);
            this.NetworkLocalityLabel.Name = "NetworkLocalityLabel";
            this.NetworkLocalityLabel.Size = new System.Drawing.Size(254, 13);
            this.NetworkLocalityLabel.TabIndex = 2;
            this.NetworkLocalityLabel.Text = "Network Locality:";
            // 
            // NetworkLocalityComboBox
            // 
            this.NetworkLocalityComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NetworkLocalityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NetworkLocalityComboBox.FormattingEnabled = true;
            this.NetworkLocalityComboBox.Location = new System.Drawing.Point(15, 67);
            this.NetworkLocalityComboBox.Name = "NetworkLocalityComboBox";
            this.NetworkLocalityComboBox.Size = new System.Drawing.Size(251, 21);
            this.NetworkLocalityComboBox.TabIndex = 3;
            this.NetworkLocalityComboBox.SelectionChangeCommitted += new System.EventHandler(this.NetworkLocalityComboBox_SelectionChangeCommitted);
            // 
            // AmendNetwork
            // 
            this.AcceptButton = this.CommitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.AbortButton;
            this.ClientSize = new System.Drawing.Size(279, 254);
            this.Controls.Add(this.NetworkLocalityComboBox);
            this.Controls.Add(this.NetworkLocalityLabel);
            this.Controls.Add(this.NetworkNameTextBox);
            this.Controls.Add(this.NetworkNameLabel);
            this.Controls.Add(this.CommitButton);
            this.Controls.Add(this.AbortButton);
            this.Controls.Add(this.HostPortNumericUpDown);
            this.Controls.Add(this.HostPortLabel);
            this.Controls.Add(this.HostSubnetMaskTextBox);
            this.Controls.Add(this.HostSubnetMaskLabel);
            this.Controls.Add(this.NetworkAddressTextBox);
            this.Controls.Add(this.NetworkAddressLabel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AmendNetwork";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Network";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AmendNetwork_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.HostPortNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown HostPortNumericUpDown;
        private System.Windows.Forms.Label HostPortLabel;
        private System.Windows.Forms.TextBox HostSubnetMaskTextBox;
        private System.Windows.Forms.Label HostSubnetMaskLabel;
        private System.Windows.Forms.TextBox NetworkAddressTextBox;
        private System.Windows.Forms.Label NetworkAddressLabel;
        private System.Windows.Forms.Button CommitButton;
        private System.Windows.Forms.Button AbortButton;
        private System.Windows.Forms.Label NetworkNameLabel;
        private System.Windows.Forms.TextBox NetworkNameTextBox;
        private System.Windows.Forms.Label NetworkLocalityLabel;
        private System.Windows.Forms.ComboBox NetworkLocalityComboBox;
    }
}