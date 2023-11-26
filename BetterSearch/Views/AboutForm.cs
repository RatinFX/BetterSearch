using BetterSearch.Models.Config;
using RatinFX.VP.General;
using System.Windows.Forms;

namespace BetterSearch.Views
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            lblVersion.Text = $"{Parameters.Name} {Parameters.CurrentVersion}";
        }

        private void linkGitHubIssue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Processes.OpenUrl("https://github.com/RatinFX/BetterSearch/issues");
        }
    }
}