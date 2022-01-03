using ScriptPortal.Vegas;
//using Sony.Vegas;

namespace BetterSearch
{
    public class ExpandedPlugInNode
    {
        public PlugInNode Plugin { get; set; }
        public bool IsVideoFX { get; set; } = false;
        public bool IsAudioFX { get; set; } = false;
        public bool IsTransition { get; set; } = false;
        public bool IsGenerator { get; set; } = false;

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
