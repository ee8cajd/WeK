namespace Madcow.Wek.UI.Controls
{
    partial class ListViewItemDisplay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BottomRowComboBox = new System.Windows.Forms.ComboBox();
            this.MiddleRowComboBox = new System.Windows.Forms.ComboBox();
            this.TopRowComboBox = new System.Windows.Forms.ComboBox();
            this.ListItemImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ListItemImage)).BeginInit();
            this.SuspendLayout();
            // 
            // BottomRowComboBox
            // 
            this.BottomRowComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BottomRowComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BottomRowComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BottomRowComboBox.FormattingEnabled = true;
            this.BottomRowComboBox.Location = new System.Drawing.Point(84, 63);
            this.BottomRowComboBox.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.BottomRowComboBox.Name = "BottomRowComboBox";
            this.BottomRowComboBox.Size = new System.Drawing.Size(260, 21);
            this.BottomRowComboBox.TabIndex = 2;
            // 
            // MiddleRowComboBox
            // 
            this.MiddleRowComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MiddleRowComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MiddleRowComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MiddleRowComboBox.FormattingEnabled = true;
            this.MiddleRowComboBox.Location = new System.Drawing.Point(84, 36);
            this.MiddleRowComboBox.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.MiddleRowComboBox.Name = "MiddleRowComboBox";
            this.MiddleRowComboBox.Size = new System.Drawing.Size(260, 21);
            this.MiddleRowComboBox.TabIndex = 1;
            // 
            // TopRowComboBox
            // 
            this.TopRowComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TopRowComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TopRowComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TopRowComboBox.FormattingEnabled = true;
            this.TopRowComboBox.Location = new System.Drawing.Point(84, 9);
            this.TopRowComboBox.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.TopRowComboBox.Name = "TopRowComboBox";
            this.TopRowComboBox.Size = new System.Drawing.Size(260, 21);
            this.TopRowComboBox.TabIndex = 0;
            // 
            // ListItemImage
            // 
            this.ListItemImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ListItemImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.ListItemImage.Location = new System.Drawing.Point(0, 0);
            this.ListItemImage.Margin = new System.Windows.Forms.Padding(10, 3, 5, 3);
            this.ListItemImage.Name = "ListItemImage";
            this.ListItemImage.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.ListItemImage.Size = new System.Drawing.Size(76, 94);
            this.ListItemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ListItemImage.TabIndex = 4;
            this.ListItemImage.TabStop = false;
            // 
            // ListViewItemDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.BottomRowComboBox);
            this.Controls.Add(this.MiddleRowComboBox);
            this.Controls.Add(this.TopRowComboBox);
            this.Controls.Add(this.ListItemImage);
            this.MaximumSize = new System.Drawing.Size(2, 96);
            this.MinimumSize = new System.Drawing.Size(356, 96);
            this.Name = "ListViewItemDisplay";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.Size = new System.Drawing.Size(354, 94);
            ((System.ComponentModel.ISupportInitialize)(this.ListItemImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox BottomRowComboBox;
        private System.Windows.Forms.ComboBox MiddleRowComboBox;
        private System.Windows.Forms.ComboBox TopRowComboBox;
        private System.Windows.Forms.PictureBox ListItemImage;
    }
}
