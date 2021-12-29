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
        public Timecode BASE_LENGTH = Timecode.FromSeconds(10);
        public MainForm(Vegas vegas)
        {
            Data.Vegas = vegas;
            InitializeComponent();
            listSearchResult.DataSource = _bindedSearchResult;
        }

        /// <summary>
        /// Filtered VideoFX
        /// </summary>
        private List<ExpandedPlugInNode> _videoFX => SearchIn(Data.Vegas.VideoFX, isVideoFX: true);

        /// <summary>
        /// Filtered AudioFX
        /// </summary>
        private List<ExpandedPlugInNode> _audioFX => SearchIn(Data.Vegas.AudioFX, isAudioFX: true);

        /// <summary>
        /// Filtered Transitions
        /// </summary>
        //private List<ExpandedPlugInNode> _transitions => SearchIn(Data.Vegas.Transitions, isTransition: true);

        /// <summary>
        /// Filtered Generators
        /// </summary>
        private List<ExpandedPlugInNode> _generators => SearchIn(Data.Vegas.Generators, isGenerator: true);

        /// <summary>
        /// Filter the given PlugInNode list by Search text
        /// </summary>
        /// <returns>Filtered PlugInNode list</returns>
        public List<ExpandedPlugInNode> SearchIn(PlugInNode list, bool isVideoFX = false, bool isAudioFX = false, bool isTransition = false, bool isGenerator = false)
        {
            return (
                from plugin in list.Where(x => x.Name.ToLower().Contains(txtSearch.Text.ToLower()) && !x.IsContainer).ToList()
                select new ExpandedPlugInNode(plugin, isVideoFX, isAudioFX, isTransition, isGenerator)
                ).ToList();
        }

        /// <summary>
        /// Concat the result of the lists
        /// </summary>
        private List<ExpandedPlugInNode> _searchResult => _videoFX
                                                  .Concat(_audioFX)
                                                  .Concat(_generators)
                                                          //.Concat(_transitions)
                                                          .ToList();

        /// <summary>
        /// Search result list that gets binded to the ListBox
        /// </summary>
        BindingList<string> _bindedSearchResult => new BindingList<string>(_searchResult.Select(x => x.Plugin.Name).ToList());

        /// <summary>
        /// Selected PlugInNode on the list
        /// </summary>
        public ExpandedPlugInNode SelectedSearchItem => _searchResult.Find(x => listSearchResult.SelectedItem != null &&
                                                                                x.Plugin.Name == listSearchResult.SelectedItem.ToString());

        /// <summary>
        /// Selected Preset on the list
        /// </summary>
        public EffectPreset SelectedItemPreset => SelectedSearchItem.Plugin.Presets.FirstOrDefault(x => listItemPresets.SelectedItem != null &&
                                                                                                        x.Name == listItemPresets.SelectedItem.ToString().Trim());

        /// <summary>
        /// INITIATE DEEP SEARCH
        /// </summary>
        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            // e.KeyCode: up -> select the item above
            if (e.KeyCode == Keys.Up)
            {
                if (listSearchResult.SelectedIndex == 0) return;
                listSearchResult.SelectedItem = listSearchResult.Items[listSearchResult.SelectedIndex - 1];
                return;
            }

            // e.KeyCode: down -> select the item below
            else if (e.KeyCode == Keys.Down)
            {
                if (listSearchResult.SelectedIndex == listSearchResult.Items.Count - 1) return;
                listSearchResult.SelectedItem = listSearchResult.Items[listSearchResult.SelectedIndex + 1];
                return;
            }

            // e.KeyCode: enter -> GenerateOrApplyFX()
            else if (e.KeyCode == Keys.Enter)
            {
                if (SelectedSearchItem == null) return;
                using (UndoBlock undo = new UndoBlock($"Add fx: {SelectedSearchItem.Plugin.Name}"))
                {
                    GenerateOrApplyFX();
                }
                return;
            }

            // disable List update if e.KeyCode is not any of the Keys below
            var betweenAZ = e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z;
            var between09 = e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9;
            var allowedKeys = new List<Keys>() { Keys.Back, Keys.Delete, Keys.Space };
            if (!betweenAZ && !between09 && !allowedKeys.Contains(e.KeyCode)) return;

            // update visible ListBox
            listSearchResult.DataSource = _bindedSearchResult;

            // reset SelectedItem index
            if (listSearchResult.Items.Count > 0) listSearchResult.SelectedIndex = 0;
        }

        /// <summary>
        /// Double clicking on an item in the ListBox -> GenerateOrApplyFX()
        /// </summary>
        private void listSearchResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            using (UndoBlock undo = new UndoBlock($"Add fx: {SelectedSearchItem.Plugin.Name}"))
            {
                GenerateOrApplyFX();
            }
        }

        /// <summary>
        /// Smashing Enter -> GenerateOrApplyFX()
        /// </summary>
        private void listSearchResult_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            using (UndoBlock undo = new UndoBlock($"Add fx: {SelectedSearchItem.Plugin.Name}"))
            {
                GenerateOrApplyFX();
            }
        }

        /// <summary>
        /// Either Generate the Generator or Apply the FX to the selected media(s)
        /// </summary>
        private void GenerateOrApplyFX()
        {
            // dumbass check
            if (listSearchResult.Items.Count < 1 || SelectedSearchItem == null) return;

            // if:   it's a generator, generate it
            if (SelectedSearchItem.IsGenerator) GenerateGenerator();

            // else: apply the video / audio FX
            else ApplyFXToSelectedMedias();
        }

        /// <summary>
        /// Generate the selected Generator at current CursorPosition
        /// </summary>
        private void GenerateGenerator()
        {
            // yup, no idea
            var media = new Media(SelectedSearchItem.Plugin);
            var stream = media.Streams.GetItemByMediaType(MediaType.Video, 0);

            // create new VideoEvent at CursorPosition with BASE_LENGTH length
            var newEvent = new VideoEvent(Data.Vegas.Transport.CursorPosition, BASE_LENGTH);

            // if there's no selected VideoTrack
            if (Data.FirstSelectedVideoTrack == null)
            {
                // if there's not a single VideoTrack in the project
                if (Data.VideoTracks.Count() == 0)
                {
                    // we create an empty VideoTrack and select it
                    Track videoTrack = new VideoTrack(0, "");
                    Data.Vegas.Project.Tracks.Add(videoTrack);
                    Data.VideoTracks.FirstOrDefault().Selected = true;
                }

                // deselect all the AudioTracks
                foreach (var track in Data.SelectedAudioTracks) track.Selected = false;
            }

            // add the Generator to the VideoTrack.Events list
            Data.FirstSelectedVideoTrack.Events.Add(newEvent);

            // honestly no idea what's a Take but i guess we can Take those
            var take = new Take(stream);
            newEvent.Takes.Add(take);
        }

        /// <summary>
        /// Apply the FX to the selected media(s)
        /// </summary>
        private void ApplyFXToSelectedMedias()
        {
            foreach (var trackEvent in Data.SelectedMedias)
            {
                //if (trackEvent.IsAudio()) continue;
                var videoEvent = (VideoEvent)trackEvent;

                if (SelectedSearchItem.IsTransition)
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
