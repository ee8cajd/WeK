namespace Madcow.Wek.UI
{
    partial class SecureOnPromptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecureOnPromptForm));
            this.SecureOnPasswordGroupBox = new System.Windows.Forms.GroupBox();
            this.SecureOnPasswordControl = new Madcow.Wek.UI.Controls.PhysicalAddressControl();
            this.SecureOnPasswordLabel = new System.Windows.Forms.Label();
            this.AbortButton = new System.Windows.Forms.Button();
            this.CommitButton = new System.Windows.Forms.Button();
            this.SecureOnPasswordGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SecureOnPasswordGroupBox
            // 
            resources.ApplyResources(this.SecureOnPasswordGroupBox, "SecureOnPasswordGroupBox");
            this.SecureOnPasswordGroupBox.Controls.Add(this.SecureOnPasswordControl);
            this.SecureOnPasswordGroupBox.Controls.Add(this.SecureOnPasswordLabel);
            this.SecureOnPasswordGroupBox.Name = "SecureOnPasswordGroupBox";
            this.SecureOnPasswordGroupBox.TabStop = false;
            // 
            // SecureOnPasswordControl
            // 
            resources.ApplyResources(this.SecureOnPasswordControl, "SecureOnPasswordControl");
            this.SecureOnPasswordControl.Name = "SecureOnPasswordControl";
            // 
            // SecureOnPasswordLabel
            // 
            resources.ApplyResources(this.SecureOnPasswordLabel, "SecureOnPasswordLabel");
            this.SecureOnPasswordLabel.Name = "SecureOnPasswordLabel";
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
            // SecureOnPromptForm
            // 
            this.AcceptButton = this.CommitButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.AbortButton;
            this.Controls.Add(this.CommitButton);
            this.Controls.Add(this.AbortButton);
            this.Controls.Add(this.SecureOnPasswordGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SecureOnPromptForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SecureOnPromptForm_FormClosing);
            this.SecureOnPasswordGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox SecureOnPasswordGroupBox;
        private Madcow.Wek.UI.Controls.PhysicalAddressControl SecureOnPasswordControl;
        private System.Windows.Forms.Label SecureOnPasswordLabel;
        private System.Windows.Forms.Button AbortButton;
        private System.Windows.Forms.Button CommitButton;
    }
}