namespace Madcow.Wek.UI
{
    partial class AmendHost
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AmendHost));
            this.AbortButton = new System.Windows.Forms.Button();
            this.CommitButton = new System.Windows.Forms.Button();
            this.HostDetailGroupBox = new System.Windows.Forms.GroupBox();
            this.HostPhysicalAddress = new Madcow.Wek.UI.Controls.PhysicalAddressControl();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.OwnerTextBox = new System.Windows.Forms.TextBox();
            this.OwnerLabel = new System.Windows.Forms.Label();
            this.NetworkAddressTextBox = new System.Windows.Forms.TextBox();
            this.NetworkAddressLabel = new System.Windows.Forms.Label();
            this.MachineAddressLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.DescriptiveNameTextBox = new System.Windows.Forms.TextBox();
            this.MachineNameLabel = new System.Windows.Forms.Label();
            this.SecureOnGroupBox = new System.Windows.Forms.GroupBox();
            this.SecureOnPromptCheckBox = new System.Windows.Forms.CheckBox();
            this.SecureOnPasswordControl = new Madcow.Wek.UI.Controls.PhysicalAddressControl();
            this.SecureOnpasswordLabel = new System.Windows.Forms.Label();
            this.SecureOnCheckBox = new System.Windows.Forms.CheckBox();
            this.HostDetailGroupBox.SuspendLayout();
            this.SecureOnGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // AbortButton
            // 
            resources.ApplyResources(this.AbortButton, "AbortButton");
            this.AbortButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.UseVisualStyleBackColor = true;
            // 
            // CommitButton
            // 
            resources.ApplyResources(this.CommitButton, "CommitButton");
            this.CommitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CommitButton.Name = "CommitButton";
            this.CommitButton.UseVisualStyleBackColor = true;
            // 
            // HostDetailGroupBox
            // 
            resources.ApplyResources(this.HostDetailGroupBox, "HostDetailGroupBox");
            this.HostDetailGroupBox.Controls.Add(this.HostPhysicalAddress);
            this.HostDetailGroupBox.Controls.Add(this.DescriptionTextBox);
            this.HostDetailGroupBox.Controls.Add(this.OwnerTextBox);
            this.HostDetailGroupBox.Controls.Add(this.OwnerLabel);
            this.HostDetailGroupBox.Controls.Add(this.NetworkAddressTextBox);
            this.HostDetailGroupBox.Controls.Add(this.NetworkAddressLabel);
            this.HostDetailGroupBox.Controls.Add(this.MachineAddressLabel);
            this.HostDetailGroupBox.Controls.Add(this.DescriptionLabel);
            this.HostDetailGroupBox.Controls.Add(this.DescriptiveNameTextBox);
            this.HostDetailGroupBox.Controls.Add(this.MachineNameLabel);
            this.HostDetailGroupBox.Name = "HostDetailGroupBox";
            this.HostDetailGroupBox.TabStop = false;
            // 
            // HostPhysicalAddress
            // 
            resources.ApplyResources(this.HostPhysicalAddress, "HostPhysicalAddress");
            this.HostPhysicalAddress.Name = "HostPhysicalAddress";
            // 
            // DescriptionTextBox
            // 
            resources.ApplyResources(this.DescriptionTextBox, "DescriptionTextBox");
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            // 
            // OwnerTextBox
            // 
            resources.ApplyResources(this.OwnerTextBox, "OwnerTextBox");
            this.OwnerTextBox.Name = "OwnerTextBox";
            // 
            // OwnerLabel
            // 
            resources.ApplyResources(this.OwnerLabel, "OwnerLabel");
            this.OwnerLabel.Name = "OwnerLabel";
            // 
            // NetworkAddressTextBox
            // 
            resources.ApplyResources(this.NetworkAddressTextBox, "NetworkAddressTextBox");
            this.NetworkAddressTextBox.Name = "NetworkAddressTextBox";
            // 
            // NetworkAddressLabel
            // 
            resources.ApplyResources(this.NetworkAddressLabel, "NetworkAddressLabel");
            this.NetworkAddressLabel.Name = "NetworkAddressLabel";
            // 
            // MachineAddressLabel
            // 
            resources.ApplyResources(this.MachineAddressLabel, "MachineAddressLabel");
            this.MachineAddressLabel.Name = "MachineAddressLabel";
            // 
            // DescriptionLabel
            // 
            resources.ApplyResources(this.DescriptionLabel, "DescriptionLabel");
            this.DescriptionLabel.Name = "DescriptionLabel";
            // 
            // DescriptiveNameTextBox
            // 
            resources.ApplyResources(this.DescriptiveNameTextBox, "DescriptiveNameTextBox");
            this.DescriptiveNameTextBox.Name = "DescriptiveNameTextBox";
            // 
            // MachineNameLabel
            // 
            resources.ApplyResources(this.MachineNameLabel, "MachineNameLabel");
            this.MachineNameLabel.Name = "MachineNameLabel";
            // 
            // SecureOnGroupBox
            // 
            resources.ApplyResources(this.SecureOnGroupBox, "SecureOnGroupBox");
            this.SecureOnGroupBox.Controls.Add(this.SecureOnPromptCheckBox);
            this.SecureOnGroupBox.Controls.Add(this.SecureOnPasswordControl);
            this.SecureOnGroupBox.Controls.Add(this.SecureOnpasswordLabel);
            this.SecureOnGroupBox.Controls.Add(this.SecureOnCheckBox);
            this.SecureOnGroupBox.Name = "SecureOnGroupBox";
            this.SecureOnGroupBox.TabStop = false;
            // 
            // SecureOnPromptCheckBox
            // 
            resources.ApplyResources(this.SecureOnPromptCheckBox, "SecureOnPromptCheckBox");
            this.SecureOnPromptCheckBox.Name = "SecureOnPromptCheckBox";
            this.SecureOnPromptCheckBox.UseVisualStyleBackColor = true;
            this.SecureOnPromptCheckBox.CheckedChanged += new System.EventHandler(this.SecureOnPromptCheckBox_CheckedChanged);
            // 
            // SecureOnPasswordControl
            // 
            resources.ApplyResources(this.SecureOnPasswordControl, "SecureOnPasswordControl");
            this.SecureOnPasswordControl.Name = "SecureOnPasswordControl";
            // 
            // SecureOnpasswordLabel
            // 
            resources.ApplyResources(this.SecureOnpasswordLabel, "SecureOnpasswordLabel");
            this.SecureOnpasswordLabel.Name = "SecureOnpasswordLabel";
            // 
            // SecureOnCheckBox
            // 
            resources.ApplyResources(this.SecureOnCheckBox, "SecureOnCheckBox");
            this.SecureOnCheckBox.Name = "SecureOnCheckBox";
            this.SecureOnCheckBox.UseVisualStyleBackColor = true;
            this.SecureOnCheckBox.CheckedChanged += new System.EventHandler(this.SecureOnCheckBox_CheckedChanged);
            // 
            // AmendHost
            // 
            this.AcceptButton = this.CommitButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this.AbortButton;
            this.Controls.Add(this.SecureOnGroupBox);
            this.Controls.Add(this.HostDetailGroupBox);
            this.Controls.Add(this.CommitButton);
            this.Controls.Add(this.AbortButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AmendHost";
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AmendHost_FormClosing);
            this.HostDetailGroupBox.ResumeLayout(false);
            this.HostDetailGroupBox.PerformLayout();
            this.SecureOnGroupBox.ResumeLayout(false);
            this.SecureOnGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AbortButton;
        private System.Windows.Forms.Button CommitButton;
        private System.Windows.Forms.GroupBox HostDetailGroupBox;
        private Madcow.Wek.UI.Controls.PhysicalAddressControl HostPhysicalAddress;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.TextBox OwnerTextBox;
        private System.Windows.Forms.Label OwnerLabel;
        private System.Windows.Forms.TextBox NetworkAddressTextBox;
        private System.Windows.Forms.Label NetworkAddressLabel;
        private System.Windows.Forms.Label MachineAddressLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.TextBox DescriptiveNameTextBox;
        private System.Windows.Forms.Label MachineNameLabel;
        private System.Windows.Forms.GroupBox SecureOnGroupBox;
        private System.Windows.Forms.CheckBox SecureOnCheckBox;
        private Madcow.Wek.UI.Controls.PhysicalAddressControl SecureOnPasswordControl;
        private System.Windows.Forms.Label SecureOnpasswordLabel;
        private System.Windows.Forms.CheckBox SecureOnPromptCheckBox;
    }
}