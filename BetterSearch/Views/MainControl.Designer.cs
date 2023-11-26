namespace BetterSearch.Views
{
	partial class MainControl
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
            this.components = new System.ComponentModel.Container();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.listSearchResult = new System.Windows.Forms.ListBox();
            this.listItemPresets = new System.Windows.Forms.ListBox();
            this.cmsFavorites = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiAddToFavs = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiRemoveFromFavs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmisOnlyShowFavorites = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCreator = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmihAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFavorites.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.Location = new System.Drawing.Point(10, 34);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(10, 10, 10, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(256, 20);
            this.txtSearch.TabIndex = 14;
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // listSearchResult
            // 
            this.listSearchResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listSearchResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.listSearchResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listSearchResult.ForeColor = System.Drawing.Color.White;
            this.listSearchResult.FormattingEnabled = true;
            this.listSearchResult.Location = new System.Drawing.Point(10, 64);
            this.listSearchResult.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.listSearchResult.Name = "listSearchResult";
            this.listSearchResult.Size = new System.Drawing.Size(256, 223);
            this.listSearchResult.TabIndex = 13;
            this.listSearchResult.SelectedIndexChanged += new System.EventHandler(this.listSearchResult_SelectedIndexChanged);
            this.listSearchResult.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listSearchResult_KeyUp);
            this.listSearchResult.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listSearchResult_MouseDoubleClick);
            // 
            // listItemPresets
            // 
            this.listItemPresets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listItemPresets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.listItemPresets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listItemPresets.ForeColor = System.Drawing.Color.White;
            this.listItemPresets.FormattingEnabled = true;
            this.listItemPresets.Location = new System.Drawing.Point(10, 297);
            this.listItemPresets.Margin = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.listItemPresets.Name = "listItemPresets";
            this.listItemPresets.Size = new System.Drawing.Size(256, 106);
            this.listItemPresets.TabIndex = 13;
            this.listItemPresets.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listSearchResult_KeyUp);
            this.listItemPresets.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listSearchResult_MouseDoubleClick);
            // 
            // cmsFavorites
            // 
            this.cmsFavorites.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiAddToFavs,
            this.cmsiRemoveFromFavs});
            this.cmsFavorites.Name = "cmsFavorites";
            this.cmsFavorites.Size = new System.Drawing.Size(173, 48);
            this.cmsFavorites.MouseLeave += new System.EventHandler(this.cmsFavorites_MouseLeave);
            // 
            // cmsiAddToFavs
            // 
            this.cmsiAddToFavs.Name = "cmsiAddToFavs";
            this.cmsiAddToFavs.Size = new System.Drawing.Size(172, 22);
            this.cmsiAddToFavs.Text = "Add to Favs";
            this.cmsiAddToFavs.Click += new System.EventHandler(this.cmsiAddToFavs_Click);
            // 
            // cmsiRemoveFromFavs
            // 
            this.cmsiRemoveFromFavs.Name = "cmsiRemoveFromFavs";
            this.cmsiRemoveFromFavs.Size = new System.Drawing.Size(172, 22);
            this.cmsiRemoveFromFavs.Text = "Remove from Favs";
            this.cmsiRemoveFromFavs.Click += new System.EventHandler(this.cmsiRemoveFromFavs_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSettings,
            this.tsmiCreator,
            this.tsmiHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(276, 24);
            this.menuStrip.TabIndex = 19;
            this.menuStrip.Text = "menuStrip";
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmisOnlyShowFavorites});
            this.tsmiSettings.ForeColor = System.Drawing.Color.White;
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Size = new System.Drawing.Size(61, 20);
            this.tsmiSettings.Text = "Settings";
            // 
            // tsmisOnlyShowFavorites
            // 
            this.tsmisOnlyShowFavorites.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tsmisOnlyShowFavorites.CheckOnClick = true;
            this.tsmisOnlyShowFavorites.ForeColor = System.Drawing.Color.White;
            this.tsmisOnlyShowFavorites.Name = "tsmisOnlyShowFavorites";
            this.tsmisOnlyShowFavorites.Size = new System.Drawing.Size(215, 22);
            this.tsmisOnlyShowFavorites.Text = "Only Show Favorites";
            this.tsmisOnlyShowFavorites.Click += new System.EventHandler(this.tsmisOnlyShowFavorites_Click);
            // 
            // tsmiCreator
            // 
            this.tsmiCreator.ForeColor = System.Drawing.Color.White;
            this.tsmiCreator.Name = "tsmiCreator";
            this.tsmiCreator.Size = new System.Drawing.Size(58, 20);
            this.tsmiCreator.Text = "Creator";
            this.tsmiCreator.Click += new System.EventHandler(this.tsmiCreator_Click);
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmihAbout});
            this.tsmiHelp.ForeColor = System.Drawing.Color.White;
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(44, 20);
            this.tsmiHelp.Text = "Help";
            // 
            // tsmihAbout
            // 
            this.tsmihAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tsmihAbout.ForeColor = System.Drawing.Color.White;
            this.tsmihAbout.Name = "tsmihAbout";
            this.tsmihAbout.Size = new System.Drawing.Size(180, 22);
            this.tsmihAbout.Text = "About";
            this.tsmihAbout.Click += new System.EventHandler(this.tsmihAbout_Click);
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.listItemPresets);
            this.Controls.Add(this.listSearchResult);
            this.Controls.Add(this.txtSearch);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(276, 413);
            this.cmsFavorites.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ListBox listSearchResult;
        private System.Windows.Forms.ListBox listItemPresets;
        private System.Windows.Forms.ContextMenuStrip cmsFavorites;
        private System.Windows.Forms.ToolStripMenuItem cmsiAddToFavs;
        private System.Windows.Forms.ToolStripMenuItem cmsiRemoveFromFavs;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmisOnlyShowFavorites;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreator;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmihAbout;
    }
}
