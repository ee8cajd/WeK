namespace Madcow.Wek.UI
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ApplicationNameLabel = new System.Windows.Forms.Label();
            this.ApplicationDescriptionLabel = new System.Windows.Forms.Label();
            this.CommitButton = new System.Windows.Forms.Button();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.LicenseLinkLabel = new System.Windows.Forms.LinkLabel();
            this.CopyrightLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(92, 273);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(22, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(22, 3, 22, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // ApplicationNameLabel
            // 
            this.ApplicationNameLabel.AutoSize = true;
            this.ApplicationNameLabel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplicationNameLabel.Location = new System.Drawing.Point(104, 12);
            this.ApplicationNameLabel.Margin = new System.Windows.Forms.Padding(12, 0, 3, 0);
            this.ApplicationNameLabel.Name = "ApplicationNameLabel";
            this.ApplicationNameLabel.Size = new System.Drawing.Size(92, 23);
            this.ApplicationNameLabel.TabIndex = 1;
            this.ApplicationNameLabel.Text = "AppName";
            // 
            // ApplicationDescriptionLabel
            // 
            this.ApplicationDescriptionLabel.AutoSize = true;
            this.ApplicationDescriptionLabel.Location = new System.Drawing.Point(105, 35);
            this.ApplicationDescriptionLabel.Name = "ApplicationDescriptionLabel";
            this.ApplicationDescriptionLabel.Size = new System.Drawing.Size(79, 13);
            this.ApplicationDescriptionLabel.TabIndex = 2;
            this.ApplicationDescriptionLabel.Text = "AppDescription";
            // 
            // CommitButton
            // 
            this.CommitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CommitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CommitButton.Location = new System.Drawing.Point(342, 239);
            this.CommitButton.Name = "CommitButton";
            this.CommitButton.Size = new System.Drawing.Size(80, 25);
            this.CommitButton.TabIndex = 3;
            this.CommitButton.Text = "OK";
            this.CommitButton.UseVisualStyleBackColor = true;
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(105, 64);
            this.VersionLabel.Margin = new System.Windows.Forms.Padding(3, 16, 3, 0);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(61, 13);
            this.VersionLabel.TabIndex = 4;
            this.VersionLabel.Text = "Version {0}";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(105, 109);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(3, 16, 3, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(132, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://wek.codeplex.com/";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
			//
			// LicenseLinkLabel
			//
			this.LicenseLinkLabel.AutoSize = true;
			this.LicenseLinkLabel.Location = new System.Drawing.Point(151, 144);
			this.LicenseLinkLabel.Margin = new System.Windows.Forms.Padding(3, 16, 3, 0);
			this.LicenseLinkLabel.Name = "LicenseLinkLabel";
			this.LicenseLinkLabel.Size = new System.Drawing.Size(200, 13);
			this.LicenseLinkLabel.TabIndex = 8;
			this.LicenseLinkLabel.TabStop = true;
			this.LicenseLinkLabel.Text = "http://wek.codeplex.com/license/";
			this.LicenseLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
            // 
            // CopyrightLabel
            // 
            this.CopyrightLabel.AutoSize = true;
            this.CopyrightLabel.Location = new System.Drawing.Point(105, 80);
            this.CopyrightLabel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.CopyrightLabel.Name = "CopyrightLabel";
            this.CopyrightLabel.Size = new System.Drawing.Size(54, 13);
            this.CopyrightLabel.TabIndex = 6;
            this.CopyrightLabel.Text = "Copyright";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "License:";
            // 
            // AboutForm
            // 
            this.AcceptButton = this.CommitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CommitButton;
            this.ClientSize = new System.Drawing.Size(434, 273);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CopyrightLabel);
            this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.LicenseLinkLabel);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.CommitButton);
            this.Controls.Add(this.ApplicationDescriptionLabel);
            this.Controls.Add(this.ApplicationNameLabel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About WeK";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label ApplicationNameLabel;
        private System.Windows.Forms.Label ApplicationDescriptionLabel;
        private System.Windows.Forms.Button CommitButton;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.LinkLabel LicenseLinkLabel;
        private System.Windows.Forms.Label CopyrightLabel;
        private System.Windows.Forms.Label label1;
    }
}
