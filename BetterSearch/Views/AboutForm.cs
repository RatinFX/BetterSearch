using BetterSearch.Models.Config;
using System.Windows.Forms;
using VegasProData.General;

namespace BetterSearch.Views
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            lblVersion.Text = $"{Parameters.Name} {Parameters.CurrentVersion}";

            if (!string.IsNullOrEmpty(Parameters.LatestVersion))
            {
                lblVersion.Text += " -> " + Parameters.LatestVersion;
                linkUpdate.Text = "New version available!";
            }
        }

        private void linkUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Processes.OpenUrl("https://ratinfx.github.io/better-search#latest-version");
        }
    }
}