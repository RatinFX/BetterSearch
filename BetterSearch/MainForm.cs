using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScriptPortal.Vegas;
//using Sony.Vegas;

namespace BetterSearch
{
    public partial class MainForm : UserControl
    {
        public static Vegas Vegas { get; set; }
        public MainForm(Vegas vegas)
        {
            Vegas = vegas;
            InitializeComponent();
            listSearchResult.DataSource = _bindedSearchResult;
        }

        private List<TrackEvent> SelectedMedias => Vegas.Project.Tracks.SelectMany(x => x.Events.Where(y => y.Selected)).ToList();

        private IEnumerable<Track> VideoTracks => Vegas.Project.Tracks.Where(x => x.MediaType == MediaType.Video);
        private IEnumerable<Track> SelectedVideoTracks => VideoTracks.Where(x => x.Selected);
        private Track FirstSelectedVideoTrack => SelectedVideoTracks.FirstOrDefault();

        private IEnumerable<Track> AudioTracks => Vegas.Project.Tracks.Where(x => x.MediaType == MediaType.Audio);
        private IEnumerable<Track> SelectedAudioTracks => AudioTracks.Where(x => x.Selected);
        private Track FirstSelectedAudioTrack => SelectedAudioTracks.FirstOrDefault();

        private List<ExpandedPlugInNode> _videoFx => SearchIn(Vegas.VideoFX, isVideoFX: true);
        private List<ExpandedPlugInNode> _audioFX => SearchIn(Vegas.AudioFX, isAudioFX: true);
        private List<ExpandedPlugInNode> _transitions => SearchIn(Vegas.Transitions, isTransition: true);
        private List<ExpandedPlugInNode> _generators => SearchIn(Vegas.Generators, isGenerator: true);
        public List<ExpandedPlugInNode> SearchIn(PlugInNode list, bool isVideoFX = false, bool isAudioFX = false, bool isTransition = false, bool isGenerator = false)
        {
            return (
                from p in list.Where(x => x.Name.ToLower().Contains(txtSearch.Text.ToLower()) && !x.IsContainer).ToList()
                select new ExpandedPlugInNode
                {
                    Plugin = p,
                    IsVideoFX = isVideoFX,
                    IsAudioFX = isAudioFX,
                    IsTransition = isTransition,
                    IsGenerator = isGenerator
                }).ToList();
        }
        // check which PlugInNode group is it coming from with index number: _videoFx.count -> + _audioFx.count ... 
        // -> else if (indexNumber > totalcounts .. )
        // {
        //   search in _plugingroup -> AddGenerator() / AddTransition() / ...
        // }
        private List<ExpandedPlugInNode> _searchResult => _videoFx.Concat(_audioFX).Concat(_generators).Concat(_transitions).ToList();
        BindingList<string> _bindedSearchResult => new BindingList<string>(_searchResult.Select(x => x.Plugin.Name).ToList());
        private List<string> _searchResultNames => _searchResult.Select(x => x.Plugin.Name).ToList();
        public ExpandedPlugInNode SelectedSearchItem => _searchResult.Find(x => listSearchResult.SelectedItem != null && x.Plugin.Name == listSearchResult.SelectedItem.ToString().Split(' ').Last());
        public EffectPreset SelectedItemPreset => SelectedSearchItem.Plugin.Presets.FirstOrDefault(x => listItemPresets.SelectedItem != null && x.Name == listItemPresets.SelectedItem.ToString().Trim());

        // maybe transition from "Enter -> search" to "Auto search"
        /// <summary>
        /// INITIATE DEEP SEARCH
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (listSearchResult.SelectedIndex == 0) return;
                listSearchResult.SelectedItem = listSearchResult.Items[listSearchResult.SelectedIndex - 1];
                return;
            }

            else if (e.KeyCode == Keys.Down)
            {
                if (listSearchResult.SelectedIndex == listSearchResult.Items.Count - 1) return;
                listSearchResult.SelectedItem = listSearchResult.Items[listSearchResult.SelectedIndex + 1];
                return;
            }

            else if (e.KeyCode == Keys.Enter)
            {
                if (SelectedSearchItem == null) return;
                using (UndoBlock undo = new UndoBlock($"Add fx: {SelectedSearchItem.Plugin.Name}"))
                {
                    UseSelectedItem();
                }
                return;
            }

            else if (e.KeyCode == Keys.Back)
            {
            }

            var betweenAZ = e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z;
            var between09 = e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9;
            var allowedKeys = new List<Keys>() { Keys.Back, Keys.Delete, Keys.Space };

            if (!betweenAZ && !between09 && !allowedKeys.Contains(e.KeyCode)) return;

            Search();
            listSearchResult.DataSource = _bindedSearchResult;
        }

        private void ClearSearchResults()
        {
            // smth else instead of clearing the while list
            if (listSearchResult.Items.Count > 0) listSearchResult.Items.Clear();
        }

        private void Search()
        {
            //ClearSearchResults();
            //AddItemsToSearchResults("Video FX", _videoFx);
            //AddItemsToSearchResults("Audio FX", _audioFX);
            //AddItemsToSearchResults("Generators", _generators);
            //AddItemsToSearchResults("Transitions", _transitions);
            if (listSearchResult.Items.Count > 0) listSearchResult.SelectedIndex = 0;
        }

        private void AddItemsToSearchResults(string sectionName, IEnumerable<PlugInNode> list)
        {
            if (list.Count() < 1) return;

            listSearchResult.Items.Add($"> {sectionName}");
            foreach (var item in list)
            {
                listSearchResult.Items.Add($"   {item.Name}");
            }
        }

        private void listSearchResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SelectedSearchItem == null) return;
            using (UndoBlock undo = new UndoBlock($"Add fx: {SelectedSearchItem.Plugin.Name}"))
            {
                UseSelectedItem();
            }
        }

        private void listSearchResult_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (SelectedSearchItem == null) return;
            using (UndoBlock undo = new UndoBlock($"Add fx: {SelectedSearchItem.Plugin.Name}"))
            {
                UseSelectedItem();
            }
        }

        /// <summary>
        /// Either Generate the Generator or Apply the FX to the selected media(s)
        /// </summary>
        private void UseSelectedItem()
        {
            // dumb check
            if (listSearchResult.Items.Count < 1 || SelectedSearchItem == null) return;

            // !IsOFX -> apply default fx
            // IsAudio -> audio fx route

            // if it's a generator, generate it
            if (SelectedSearchItem.Plugin.IsOFX && SelectedSearchItem.Plugin.OFXPlugIn.EffectType == OFXEffectType.Generator)
            {
                GenerateGenerator();
                return;
            }

            ApplyToSelectedMedias();
        }

        private void GenerateGenerator()
        {
            var media = new Media(SelectedSearchItem.Plugin);
            var stream = media.Streams.GetItemByMediaType(MediaType.Video, 0);
            var newEvent = new VideoEvent(Vegas.Transport.CursorPosition);

            if (FirstSelectedVideoTrack == null)
            {
                if (VideoTracks.Count() == 0)
                {
                    Track videoTrack = new VideoTrack(0, "");
                    Vegas.Project.Tracks.Add(videoTrack);
                    VideoTracks.FirstOrDefault().Selected = true;
                }
                foreach (var track in SelectedAudioTracks) track.Selected = false;
            }

            FirstSelectedVideoTrack.Events.Add(newEvent);

            var take = new Take(stream);
            newEvent.Takes.Add(take);
        }

        /// <summary>
        /// Apply the FX to the selected media(s)
        /// </summary>
        private void ApplyToSelectedMedias()
        {
            foreach (var trackEvent in SelectedMedias)
            {
                if (trackEvent.IsAudio()) continue;
                var videoEvent = (VideoEvent)trackEvent;

                if (SelectedSearchItem.Plugin.IsOFX && SelectedSearchItem.Plugin.OFXPlugIn.EffectType == OFXEffectType.Transition)
                {
                    // do transition stuff ??
                    // first media ->> second media
                    continue;
                }

                Effect effect = new Effect(SelectedSearchItem.Plugin);
                videoEvent.Effects.Add(effect);

                effect.Preset = effect.Presets.FirstOrDefault(x => (SelectedItemPreset != null && x.Index == SelectedItemPreset.Index) || x.Index == 0).Name;
            }
        }
    }
}
