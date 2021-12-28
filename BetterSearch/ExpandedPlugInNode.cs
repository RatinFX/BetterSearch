using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterSearch
{
    public class ExpandedPlugInNode
    {
        public PlugInNode Plugin { get; set; }
        public bool IsVideoFX { get; set; }
        public bool IsAudioFX { get; set; }
        public bool IsTransition { get; set; }
        public bool IsGenerator { get; set; }
    }
}
