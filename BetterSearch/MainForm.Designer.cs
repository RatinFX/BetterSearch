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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.listSearchResult = new System.Windows.Forms.ListBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.listItemPresets = new System.Windows.Forms.ListBox();
            this.grpPresets = new System.Windows.Forms.GroupBox();
            this.grpSearchResults = new System.Windows.Forms.GroupBox();
            this.grpPresets.SuspendLayout();
            this.grpSearchResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(64, 10);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(7, 10, 3, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(196, 20);
            this.txtSearch.TabIndex = 14;
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // listSearchResult
            // 
            this.listSearchResult.FormattingEnabled = true;
            this.listSearchResult.Location = new System.Drawing.Point(0, 23);
            this.listSearchResult.Margin = new System.Windows.Forms.Padding(10, 7, 10, 3);
            this.listSearchResult.Name = "listSearchResult";
            this.listSearchResult.Size = new System.Drawing.Size(270, 134);
            this.listSearchResult.TabIndex = 13;
            this.listSearchResult.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listSearchResult_KeyUp);
            this.listSearchResult.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listSearchResult_MouseDoubleClick);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(10, 13);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(44, 13);
            this.lblSearch.TabIndex = 15;
            this.lblSearch.Text = "Search:";
            // 
            // listItemPresets
            // 
            this.listItemPresets.FormattingEnabled = true;
            this.listItemPresets.Location = new System.Drawing.Point(0, 23);
            this.listItemPresets.Margin = new System.Windows.Forms.Padding(10, 7, 10, 10);
            this.listItemPresets.Name = "listItemPresets";
            this.listItemPresets.Size = new System.Drawing.Size(270, 134);
            this.listItemPresets.TabIndex = 13;
            this.listItemPresets.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listSearchResult_KeyUp);
            this.listItemPresets.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listSearchResult_MouseDoubleClick);
            // 
            // grpPresets
            // 
            this.grpPresets.Controls.Add(this.listItemPresets);
            this.grpPresets.Location = new System.Drawing.Point(0, 207);
            this.grpPresets.Margin = new System.Windows.Forms.Padding(0, 7, 0, 10);
            this.grpPresets.Name = "grpPresets";
            this.grpPresets.Size = new System.Drawing.Size(270, 159);
            this.grpPresets.TabIndex = 16;
            this.grpPresets.TabStop = false;
            this.grpPresets.Text = "Presets";
            // 
            // grpSearchResults
            // 
            this.grpSearchResults.Controls.Add(this.listSearchResult);
            this.grpSearchResults.Location = new System.Drawing.Point(0, 40);
            this.grpSearchResults.Margin = new System.Windows.Forms.Padding(0, 7, 0, 3);
            this.grpSearchResults.Name = "grpSearchResults";
            this.grpSearchResults.Size = new System.Drawing.Size(270, 159);
            this.grpSearchResults.TabIndex = 17;
            this.grpSearchResults.TabStop = false;
            this.grpSearchResults.Text = "Search results";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpSearchResults);
            this.Controls.Add(this.grpPresets);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Name = "MainForm";
            this.Size = new System.Drawing.Size(270, 409);
            this.grpPresets.ResumeLayout(false);
            this.grpSearchResults.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.ListBox listSearchResult;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ListBox listItemPresets;
        private System.Windows.Forms.GroupBox grpPresets;
        private System.Windows.Forms.GroupBox grpSearchResults;
    }
}
