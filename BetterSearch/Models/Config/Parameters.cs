using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace BetterSearch.Models.Config
{
    public static class Parameters
    {
        public static string MainFolder(string subFolder = "") => @"BetterSearch\" + subFolder;
        public static string Name => "Better Search";
        public static Version Version => Assembly.GetExecutingAssembly().GetName().Version;
        public static string CurrentVersion => $"{Version.Major}.{Version.Minor}.{Version.Build}.";

        public static List<Keys> IgnoredKeys => new List<Keys>() {
            Keys.ControlKey, Keys.ShiftKey, Keys.Menu, Keys.Alt, Keys.Tab, Keys.CapsLock,
        };
    }
}
