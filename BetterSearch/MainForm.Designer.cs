namespace BetterSearch
{
	partial class MainForm
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
            this.cbxDarkTheme = new System.Windows.Forms.CheckBox();
            this.cmsFavorites = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiAddToFavs = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiRemoveFromFavs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.smiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.smiThemes = new System.Windows.Forms.ToolStripMenuItem();
            this.smiDark = new System.Windows.Forms.ToolStripMenuItem();
            this.smiLight = new System.Windows.Forms.ToolStripMenuItem();
            this.smiOnlyShowFavorites = new System.Windows.Forms.ToolStripMenuItem();
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
            this.txtSearch.Size = new System.Drawing.Size(145, 20);
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
            this.listSearchResult.Margin = new System.Windows.Forms.Padding(10, 7, 10, 3);
            this.listSearchResult.Name = "listSearchResult";
            this.listSearchResult.Size = new System.Drawing.Size(200, 199);
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
            this.listItemPresets.Location = new System.Drawing.Point(10, 271);
            this.listItemPresets.Margin = new System.Windows.Forms.Padding(10, 7, 10, 0);
            this.listItemPresets.Name = "listItemPresets";
            this.listItemPresets.Size = new System.Drawing.Size(200, 134);
            this.listItemPresets.TabIndex = 13;
            this.listItemPresets.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listSearchResult_KeyUp);
            this.listItemPresets.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listSearchResult_MouseDoubleClick);
            // 
            // cbxDarkTheme
            // 
            this.cbxDarkTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxDarkTheme.AutoSize = true;
            this.cbxDarkTheme.Checked = true;
            this.cbxDarkTheme.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxDarkTheme.Location = new System.Drawing.Point(161, 36);
            this.cbxDarkTheme.Name = "cbxDarkTheme";
            this.cbxDarkTheme.Size = new System.Drawing.Size(49, 17);
            this.cbxDarkTheme.TabIndex = 18;
            this.cbxDarkTheme.Text = "Dark";
            this.cbxDarkTheme.UseVisualStyleBackColor = true;
            this.cbxDarkTheme.CheckedChanged += new System.EventHandler(this.cbxDarkTheme_CheckedChanged);
            // 
            // cmsFavorites
            // 
            this.cmsFavorites.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiAddToFavs,
            this.cmsiRemoveFromFavs});
            this.cmsFavorites.Name = "cmsFavorites";
            this.cmsFavorites.Size = new System.Drawing.Size(181, 70);
            this.cmsFavorites.MouseLeave += new System.EventHandler(this.cmsFavorites_MouseLeave);
            // 
            // cmsiAddToFavs
            // 
            this.cmsiAddToFavs.Name = "cmsiAddToFavs";
            this.cmsiAddToFavs.Size = new System.Drawing.Size(180, 22);
            this.cmsiAddToFavs.Text = "Add to Favs";
            this.cmsiAddToFavs.Click += new System.EventHandler(this.cmsiAddToFavs_Click);
            // 
            // cmsiRemoveFromFavs
            // 
            this.cmsiRemoveFromFavs.Name = "cmsiRemoveFromFavs";
            this.cmsiRemoveFromFavs.Size = new System.Drawing.Size(180, 22);
            this.cmsiRemoveFromFavs.Text = "Remove from Favs";
            this.cmsiRemoveFromFavs.Click += new System.EventHandler(this.cmsiRemoveFromFavs_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiSettings,
            this.smiThemes});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(220, 24);
            this.menuStrip.TabIndex = 19;
            this.menuStrip.Text = "menuStrip";
            // 
            // smiSettings
            // 
            this.smiSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiOnlyShowFavorites});
            this.smiSettings.Name = "smiSettings";
            this.smiSettings.Size = new System.Drawing.Size(61, 20);
            this.smiSettings.Text = "Settings";
            // 
            // smiOnlyShowFavorites
            // 
            this.smiOnlyShowFavorites.CheckOnClick = true;
            this.smiOnlyShowFavorites.Name = "smiOnlyShowFavorites";
            this.smiOnlyShowFavorites.Size = new System.Drawing.Size(181, 22);
            this.smiOnlyShowFavorites.Text = "Only Show Favorites";
            this.smiOnlyShowFavorites.Click += new System.EventHandler(this.smiOnlyShowFavorites_Click);
            // 
            // smiThemes
            // 
            this.smiThemes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiDark,
            this.smiLight});
            this.smiThemes.Name = "smiThemes";
            this.smiThemes.Size = new System.Drawing.Size(60, 20);
            this.smiThemes.Text = "Themes";
            // 
            // smiDark
            // 
            this.smiDark.Name = "smiDark";
            this.smiDark.Size = new System.Drawing.Size(101, 22);
            this.smiDark.Text = "Dark";
            // 
            // smiLight
            // 
            this.smiLight.Name = "smiLight";
            this.smiLight.Size = new System.Drawing.Size(101, 22);
            this.smiLight.Text = "Light";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.listItemPresets);
            this.Controls.Add(this.listSearchResult);
            this.Controls.Add(this.cbxDarkTheme);
            this.Controls.Add(this.txtSearch);
            this.Name = "MainForm";
            this.Size = new System.Drawing.Size(220, 415);
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
        private System.Windows.Forms.CheckBox cbxDarkTheme;
        private System.Windows.Forms.ContextMenuStrip cmsFavorites;
        private System.Windows.Forms.ToolStripMenuItem cmsiAddToFavs;
        private System.Windows.Forms.ToolStripMenuItem cmsiRemoveFromFavs;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem smiSettings;
        private System.Windows.Forms.ToolStripMenuItem smiThemes;
        private System.Windows.Forms.ToolStripMenuItem smiDark;
        private System.Windows.Forms.ToolStripMenuItem smiLight;
        private System.Windows.Forms.ToolStripMenuItem smiOnlyShowFavorites;
    }
}
