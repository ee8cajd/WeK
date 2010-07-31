namespace Madcow.Wek.UI
{
    partial class HostManagementForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HostManagementForm));
            this.WakeSelectionButton = new System.Windows.Forms.Button();
            this.HostsListView = new System.Windows.Forms.ListView();
            this.MachineNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PhysicalAddressColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DescriptiveCommentColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HostContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AwakenHostMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AmendHostMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveHostMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddHostMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HostIconImageList = new System.Windows.Forms.ImageList(this.components);
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItemSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HostMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutWekMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WekMenuStrip = new System.Windows.Forms.MenuStrip();
            this.HostManagementPersistWindow = new Madcow.UI.Controls.PersistWindow(this.components);
            this.HostContextMenuStrip.SuspendLayout();
            this.WekMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // WakeSelectionButton
            // 
            this.WakeSelectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.WakeSelectionButton.Location = new System.Drawing.Point(539, 303);
            this.WakeSelectionButton.Name = "WakeSelectionButton";
            this.WakeSelectionButton.Size = new System.Drawing.Size(120, 25);
            this.WakeSelectionButton.TabIndex = 5;
            this.WakeSelectionButton.Text = "Wake Selection";
            this.WakeSelectionButton.UseVisualStyleBackColor = true;
            this.WakeSelectionButton.Click += new System.EventHandler(this.WakeSelectionButton_Click);
            // 
            // HostsListView
            // 
            this.HostsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HostsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MachineNameColumnHeader,
            this.PhysicalAddressColumnHeader,
            this.DescriptiveCommentColumnHeader});
            this.HostsListView.ContextMenuStrip = this.HostContextMenuStrip;
            this.HostsListView.HideSelection = false;
            this.HostsListView.LabelWrap = false;
            this.HostsListView.LargeImageList = this.HostIconImageList;
            this.HostsListView.Location = new System.Drawing.Point(12, 32);
            this.HostsListView.Name = "HostsListView";
            this.HostsListView.OwnerDraw = true;
            this.HostsListView.ShowGroups = false;
            this.HostsListView.Size = new System.Drawing.Size(647, 264);
            this.HostsListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.HostsListView.TabIndex = 1;
            this.HostsListView.TileSize = new System.Drawing.Size(200, 58);
            this.HostsListView.UseCompatibleStateImageBehavior = false;
            this.HostsListView.View = System.Windows.Forms.View.Tile;
            this.HostsListView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.HostsListView_DrawItem);
            this.HostsListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.HostsListView_ItemSelectionChanged);
            this.HostsListView.DoubleClick += new System.EventHandler(this.HostsListView_DoubleClick);
            // 
            // MachineNameColumnHeader
            // 
            this.MachineNameColumnHeader.Text = "Machine Name";
            // 
            // PhysicalAddressColumnHeader
            // 
            this.PhysicalAddressColumnHeader.Text = "Physical Address";
            // 
            // DescriptiveCommentColumnHeader
            // 
            this.DescriptiveCommentColumnHeader.Text = "Descriptive Comment";
            // 
            // HostContextMenuStrip
            // 
            this.HostContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AwakenHostMenuItem,
            this.AmendHostMenuItem,
            this.RemoveHostMenuItem,
            this.toolStripMenuItem1,
            this.AddHostMenuItem});
            this.HostContextMenuStrip.Name = "HostContextMenuStrip";
            this.HostContextMenuStrip.Size = new System.Drawing.Size(164, 98);
            this.HostContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.HostContextMenuStrip_Opening);
            // 
            // AwakenHostMenuItem
            // 
            this.AwakenHostMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AwakenHostMenuItem.Name = "AwakenHostMenuItem";
            this.AwakenHostMenuItem.Size = new System.Drawing.Size(163, 22);
            this.AwakenHostMenuItem.Text = "Awaken";
            this.AwakenHostMenuItem.Click += new System.EventHandler(this.AwakenHostMenuItem_Click);
            // 
            // AmendHostMenuItem
            // 
            this.AmendHostMenuItem.Name = "AmendHostMenuItem";
            this.AmendHostMenuItem.Size = new System.Drawing.Size(163, 22);
            this.AmendHostMenuItem.Text = "Properties...";
            this.AmendHostMenuItem.Click += new System.EventHandler(this.AmendHostMenuItem_Click);
            // 
            // RemoveHostMenuItem
            // 
            this.RemoveHostMenuItem.Name = "RemoveHostMenuItem";
            this.RemoveHostMenuItem.Size = new System.Drawing.Size(163, 22);
            this.RemoveHostMenuItem.Text = "Remove";
            this.RemoveHostMenuItem.Click += new System.EventHandler(this.RemoveHostMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 6);
            // 
            // AddHostMenuItem
            // 
            this.AddHostMenuItem.Name = "AddHostMenuItem";
            this.AddHostMenuItem.Size = new System.Drawing.Size(163, 22);
            this.AddHostMenuItem.Text = "Add new host...";
            this.AddHostMenuItem.Click += new System.EventHandler(this.AddHostMenuItem_Click);
            // 
            // HostIconImageList
            // 
            this.HostIconImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("HostIconImageList.ImageStream")));
            this.HostIconImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.HostIconImageList.Images.SetKeyName(0, "NormalWolHost");
            this.HostIconImageList.Images.SetKeyName(1, "SecureOnWolHost");
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveMenuItem,
            this.fileToolStripMenuItemSeparator,
            this.ExitMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // SaveMenuItem
            // 
            this.SaveMenuItem.Name = "SaveMenuItem";
            this.SaveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveMenuItem.Size = new System.Drawing.Size(147, 22);
            this.SaveMenuItem.Text = "&Save";
            this.SaveMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // fileToolStripMenuItemSeparator
            // 
            this.fileToolStripMenuItemSeparator.Name = "fileToolStripMenuItemSeparator";
            this.fileToolStripMenuItemSeparator.Size = new System.Drawing.Size(144, 6);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.ExitMenuItem.Size = new System.Drawing.Size(147, 22);
            this.ExitMenuItem.Text = "E&xit";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // HostMenuItem
            // 
            this.HostMenuItem.Name = "HostMenuItem";
            this.HostMenuItem.Size = new System.Drawing.Size(41, 20);
            this.HostMenuItem.Text = "Host";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionsMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // OptionsMenuItem
            // 
            this.OptionsMenuItem.Name = "OptionsMenuItem";
            this.OptionsMenuItem.Size = new System.Drawing.Size(134, 22);
            this.OptionsMenuItem.Text = "Options...";
            this.OptionsMenuItem.Click += new System.EventHandler(this.OptionsMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutWekMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // AboutWekMenuItem
            // 
            this.AboutWekMenuItem.Name = "AboutWekMenuItem";
            this.AboutWekMenuItem.Size = new System.Drawing.Size(151, 22);
            this.AboutWekMenuItem.Text = "About WeK...";
            this.AboutWekMenuItem.Click += new System.EventHandler(this.AboutWekMenuItem_Click);
            // 
            // WekMenuStrip
            // 
            this.WekMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.HostMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.WekMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.WekMenuStrip.Name = "WekMenuStrip";
            this.WekMenuStrip.Size = new System.Drawing.Size(671, 24);
            this.WekMenuStrip.TabIndex = 0;
            this.WekMenuStrip.Text = "WekMenuStrip";
            // 
            // HostManagementPersistWindow
            // 
            this.HostManagementPersistWindow.ApplicationName = "WeK";
            this.HostManagementPersistWindow.Attached = true;
            this.HostManagementPersistWindow.ContainerControl = this;
            this.HostManagementPersistWindow.FormName = "HostManagement";
            // 
            // HostManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 337);
            this.Controls.Add(this.WakeSelectionButton);
            this.Controls.Add(this.HostsListView);
            this.Controls.Add(this.WekMenuStrip);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.WekMenuStrip;
            this.Name = "HostManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WeK - Host Management";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HostManagementForm_FormClosing);
            this.HostContextMenuStrip.ResumeLayout(false);
            this.WekMenuStrip.ResumeLayout(false);
            this.WekMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button WakeSelectionButton;
        private System.Windows.Forms.ListView HostsListView;
        private System.Windows.Forms.ColumnHeader MachineNameColumnHeader;
        private System.Windows.Forms.ColumnHeader PhysicalAddressColumnHeader;
        private System.Windows.Forms.ColumnHeader DescriptiveCommentColumnHeader;
        private System.Windows.Forms.ImageList HostIconImageList;
        private System.Windows.Forms.ContextMenuStrip HostContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveMenuItem;
        private System.Windows.Forms.ToolStripSeparator fileToolStripMenuItemSeparator;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HostMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutWekMenuItem;
        private System.Windows.Forms.MenuStrip WekMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AddHostMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AmendHostMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveHostMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AwakenHostMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private Madcow.UI.Controls.PersistWindow HostManagementPersistWindow;
    }
}

