namespace Madcow.Wek.UI
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.HostsListViewDisplayGroupBox = new System.Windows.Forms.GroupBox();
            this.ShowSecureOnHintCheckBox = new System.Windows.Forms.CheckBox();
            this.listViewItemDisplay1 = new Madcow.Wek.UI.Controls.ListViewItemDisplay();
            this.DoubleClickBehaviourComboBox = new System.Windows.Forms.ComboBox();
            this.DoubleClickBehaviourLabel = new System.Windows.Forms.Label();
            this.CommitButton = new System.Windows.Forms.Button();
            this.AbortButton = new System.Windows.Forms.Button();
            this.HostsListViewDisplayGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // HostsListViewDisplayGroupBox
            // 
            resources.ApplyResources(this.HostsListViewDisplayGroupBox, "HostsListViewDisplayGroupBox");
            this.HostsListViewDisplayGroupBox.Controls.Add(this.ShowSecureOnHintCheckBox);
            this.HostsListViewDisplayGroupBox.Controls.Add(this.listViewItemDisplay1);
            this.HostsListViewDisplayGroupBox.Controls.Add(this.DoubleClickBehaviourComboBox);
            this.HostsListViewDisplayGroupBox.Controls.Add(this.DoubleClickBehaviourLabel);
            this.HostsListViewDisplayGroupBox.Name = "HostsListViewDisplayGroupBox";
            this.HostsListViewDisplayGroupBox.TabStop = false;
            // 
            // ShowSecureOnHintCheckBox
            // 
            resources.ApplyResources(this.ShowSecureOnHintCheckBox, "ShowSecureOnHintCheckBox");
            this.ShowSecureOnHintCheckBox.Name = "ShowSecureOnHintCheckBox";
            this.ShowSecureOnHintCheckBox.UseVisualStyleBackColor = true;
            // 
            // listViewItemDisplay1
            // 
            resources.ApplyResources(this.listViewItemDisplay1, "listViewItemDisplay1");
            this.listViewItemDisplay1.BackColor = System.Drawing.SystemColors.Window;
            this.listViewItemDisplay1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewItemDisplay1.BottomRowValue = null;
            this.listViewItemDisplay1.ItemImage = global::Madcow.Wek.UI.Properties.Resources.machine2;
            this.listViewItemDisplay1.ItemObjectType = null;
            this.listViewItemDisplay1.MaximumSize = new System.Drawing.Size(2, 96);
            this.listViewItemDisplay1.MiddleRowValue = null;
            this.listViewItemDisplay1.MinimumSize = new System.Drawing.Size(356, 96);
            this.listViewItemDisplay1.Name = "listViewItemDisplay1";
            this.listViewItemDisplay1.TopRowValue = null;
            // 
            // DoubleClickBehaviourComboBox
            // 
            resources.ApplyResources(this.DoubleClickBehaviourComboBox, "DoubleClickBehaviourComboBox");
            this.DoubleClickBehaviourComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DoubleClickBehaviourComboBox.FormattingEnabled = true;
            this.DoubleClickBehaviourComboBox.Name = "DoubleClickBehaviourComboBox";
            // 
            // DoubleClickBehaviourLabel
            // 
            resources.ApplyResources(this.DoubleClickBehaviourLabel, "DoubleClickBehaviourLabel");
            this.DoubleClickBehaviourLabel.Name = "DoubleClickBehaviourLabel";
            // 
            // CommitButton
            // 
            resources.ApplyResources(this.CommitButton, "CommitButton");
            this.CommitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CommitButton.Name = "CommitButton";
            this.CommitButton.UseVisualStyleBackColor = true;
            // 
            // AbortButton
            // 
            resources.ApplyResources(this.AbortButton, "AbortButton");
            this.AbortButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.CommitButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.AbortButton;
            this.Controls.Add(this.AbortButton);
            this.Controls.Add(this.CommitButton);
            this.Controls.Add(this.HostsListViewDisplayGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
            this.HostsListViewDisplayGroupBox.ResumeLayout(false);
            this.HostsListViewDisplayGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox HostsListViewDisplayGroupBox;
        private System.Windows.Forms.ComboBox DoubleClickBehaviourComboBox;
        private System.Windows.Forms.Label DoubleClickBehaviourLabel;
        private System.Windows.Forms.Button CommitButton;
        private Madcow.Wek.UI.Controls.ListViewItemDisplay listViewItemDisplay1;
        private System.Windows.Forms.CheckBox ShowSecureOnHintCheckBox;
        private System.Windows.Forms.Button AbortButton;
    }
}