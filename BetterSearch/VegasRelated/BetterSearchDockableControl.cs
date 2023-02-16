using BetterSearch.VegasRelated;
using BetterSearch.Views;
using ScriptPortal.Vegas;
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace BetterSearch.VegasRelated
{
    public class BetterSearchDockableControl : DockableControl
    {
        private MainControl _mainControl = null;
        public BetterSearchDockableControl(CustomCommand cc) : base("IBetterSearch")
        {
            DisplayName = "Better Search";
            AutoLoadCommand = cc;
            PersistDockWindowState = true;
        }
        public override DockWindowStyle DefaultDockWindowStyle => DockWindowStyle.Floating;
        public override Size DefaultFloatingSize => new Size(270, 367);
        protected override void OnLoad(EventArgs e)
        {
            _mainControl = new MainControl(myVegas) { Dock = DockStyle.Fill };
            Controls.Add(_mainControl);
        }
        protected override void OnClosed(EventArgs args)
        {
            base.OnClosed(args);
        }
    }

    public class CustomCommandModule : ICustomCommandModule
    {
        Vegas myVegas = null;
        CustomCommand _cc = new CustomCommand(CommandCategory.View, "Better Search");
        public void InitializeModule(Vegas vegas)
        {
            myVegas = vegas;
            _cc.MenuItemName = "Better Search";
        }
        public ICollection GetCustomCommands()
        {
            _cc.MenuPopup += HandleMenuPopup;
            _cc.Invoked += HandleInvoked;
            return new CustomCommand[] { _cc };
        }
        private void HandleMenuPopup(object sender, EventArgs e)
        {
            _cc.Checked = myVegas.FindDockView("IBetterSearch");
        }
        private void HandleInvoked(object sender, EventArgs e)
        {
            if (myVegas.ActivateDockView("IBetterSearch"))
                return;

            var dock = new BetterSearchDockableControl(_cc);
            myVegas.LoadDockView(dock);
        }
    }
}
