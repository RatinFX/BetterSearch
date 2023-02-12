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
            this.tsmiThemes = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFavorites.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(10, 34);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(7, 10, 3, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(226, 20);
            this.txtSearch.TabIndex = 14;
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // listSearchResult
            // 
            this.listSearchResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listSearchResult.FormattingEnabled = true;
            this.listSearchResult.Location = new System.Drawing.Point(10, 63);
            this.listSearchResult.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.listSearchResult.Name = "listSearchResult";
            this.listSearchResult.Size = new System.Drawing.Size(226, 225);
            this.listSearchResult.TabIndex = 13;
            this.listSearchResult.SelectedIndexChanged += new System.EventHandler(this.listSearchResult_SelectedIndexChanged);
            this.listSearchResult.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listSearchResult_KeyUp);
            this.listSearchResult.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listSearchResult_MouseDoubleClick);
            // 
            // listItemPresets
            // 
            this.listItemPresets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listItemPresets.FormattingEnabled = true;
            this.listItemPresets.Location = new System.Drawing.Point(10, 298);
            this.listItemPresets.Margin = new System.Windows.Forms.Padding(10, 7, 10, 0);
            this.listItemPresets.Name = "listItemPresets";
            this.listItemPresets.Size = new System.Drawing.Size(226, 108);
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
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSettings,
            this.tsmiThemes});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(248, 24);
            this.menuStrip.TabIndex = 19;
            this.menuStrip.Text = "menuStrip";
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmisOnlyShowFavorites});
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Size = new System.Drawing.Size(61, 20);
            this.tsmiSettings.Text = "Settings";
            // 
            // tsmisOnlyShowFavorites
            // 
            this.tsmisOnlyShowFavorites.CheckOnClick = true;
            this.tsmisOnlyShowFavorites.Name = "tsmisOnlyShowFavorites";
            this.tsmisOnlyShowFavorites.Size = new System.Drawing.Size(181, 22);
            this.tsmisOnlyShowFavorites.Text = "Only Show Favorites";
            this.tsmisOnlyShowFavorites.Click += new System.EventHandler(this.smiOnlyShowFavorites_Click);
            // 
            // tsmiThemes
            // 
            this.tsmiThemes.Name = "tsmiThemes";
            this.tsmiThemes.Size = new System.Drawing.Size(60, 20);
            this.tsmiThemes.Text = "Themes";
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.listItemPresets);
            this.Controls.Add(this.listSearchResult);
            this.Controls.Add(this.txtSearch);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(248, 415);
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
        private System.Windows.Forms.ToolStripMenuItem tsmiThemes;
        private System.Windows.Forms.ToolStripMenuItem tsmisOnlyShowFavorites;
    }
}
