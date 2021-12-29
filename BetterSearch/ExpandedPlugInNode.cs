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

        public ExpandedPlugInNode() { }
        public ExpandedPlugInNode(PlugInNode plugin, bool isVideoFX, bool isAudioFX, bool isTransition, bool isGenerator)
        {
            Plugin = plugin;
            IsVideoFX = isVideoFX;
            IsAudioFX = isAudioFX;
            IsTransition = isTransition;
            IsGenerator = isGenerator;
        }
    }
}
