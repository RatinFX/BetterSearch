namespace BetterSearch.Views
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.linkUpdate = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 177);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 10, 3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "- Only Show Favorites";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 149);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 10, 3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Toggle options in the Settings menu such as:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 121);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(311, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Add or Remove from your Favorite list by right clicking on an item";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 93);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Quickly search and find VideoFX, AudioFX and Generators";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(12, 19);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(155, 17);
            this.lblVersion.TabIndex = 36;
            this.lblVersion.Text = "Better Search 0.0.0.";
            // 
            // linkUpdate
            // 
            this.linkUpdate.ActiveLinkColor = System.Drawing.Color.MediumTurquoise;
            this.linkUpdate.AutoSize = true;
            this.linkUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkUpdate.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkUpdate.LinkColor = System.Drawing.Color.PaleTurquoise;
            this.linkUpdate.Location = new System.Drawing.Point(12, 56);
            this.linkUpdate.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.linkUpdate.Name = "linkUpdate";
            this.linkUpdate.Size = new System.Drawing.Size(230, 17);
            this.linkUpdate.TabIndex = 41;
            this.linkUpdate.TabStop = true;
            this.linkUpdate.Text = "You\'re using the latest version";
            this.linkUpdate.VisitedLinkColor = System.Drawing.Color.PaleTurquoise;
            this.linkUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUpdate_LinkClicked);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(349, 209);
            this.Controls.Add(this.linkUpdate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblVersion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.LinkLabel linkUpdate;
    }
}