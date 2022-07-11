using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using VegasProData;

namespace BetterSearch
{
    public partial class MainForm : UserControl
    {
        public Timecode BASE_LENGTH = Timecode.FromSeconds(10);
        public MainForm(Vegas vegas)
        {
            Data.Vegas = vegas;
            Methods.ReadConfig();
            InitializeComponent();
            listSearchResult.DataSource = BindedSearchResult;
            listItemPresets.DataSource = BindedItemPresets;
        }

        /// <summary>
        /// Concat the result of the lists
        /// </summary>
        public IEnumerable<ExtendedPlugInNode> SearchResult =>
                    new List<ExtendedPlugInNode> { new ExtendedPlugInNode("- - - VIDEO FX - - -") }.Concat(Data.SearchIn(Data.VideoFX, txtSearch.Text))
            .Concat(new List<ExtendedPlugInNode> { new ExtendedPlugInNode("- - - AUDIO FX - - -") }).Concat(Data.SearchIn(Data.AudioFX, txtSearch.Text))
            .Concat(new List<ExtendedPlugInNode> { new ExtendedPlugInNode("- - - GENERATORS - - -") }).Concat(Data.SearchIn(Data.Generators, txtSearch.Text))
            //.Concat(new List<ExtendedPlugInNode> { new ExtendedPlugInNode("- - - TRANSITIONS - - -") }).Concat(Data.SearchIn(Data.Transitions, txtSearch.Text))
            ;

        /// <summary>
        /// Search results that get binded to the ListBox
        /// </summary>
        public BindingList<string> BindedSearchResult => new BindingList<string>(SearchResult.Select(x => x.Name).ToList());

        /// <summary>
        /// Selected PlugInNode on the list
        /// </summary>
        public ExtendedPlugInNode SelectedSearchItem => SearchResult.FirstOrDefault(x =>
            listSearchResult.SelectedItem != null && x.Name == listSearchResult.SelectedItem.ToString());

        /// <summary>
        /// Selected Item null checks
        /// </summary>
        public bool CanApplyPlugin => SelectedSearchItem != null && SelectedSearchItem.Plugin != null;

        /// <summary>
        /// Item Presets that get binded to the ListBox
        /// </summary>
        public BindingList<string> BindedItemPresets => SelectedSearchItem != null && SelectedSearchItem.Plugin != null
            ? new BindingList<string>(SelectedSearchItem.Plugin.Presets.Select(x => x.Name).ToList())
            : new BindingList<string>();

        /// <summary>
        /// Selected Preset on the list
        /// </summary>
        public EffectPreset SelectedItemPreset => SelectedSearchItem.Plugin.Presets.FirstOrDefault(x =>
            listItemPresets.SelectedItem != null && x.Name == listItemPresets.SelectedItem.ToString().Trim());

        /// <summary>
        /// Selected item index changed
        /// </summary>
        private void listSearchResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetPreset();
        }

        /// <summary>
        /// Search on tip taps
        /// </summary>
        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            // ignore the following list of keys
            var ignoredKeys = new List<Keys>() { Keys.ControlKey, Keys.ShiftKey, Keys.Menu, Keys.Alt, Keys.Tab, Keys.CapsLock };
            if (ignoredKeys.Contains(e.KeyCode)) return;

            // up -> Select the item Above
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
            {
                if (listSearchResult.SelectedIndex == 0) return;

                listSearchResult.SelectedItem = listSearchResult.Items[listSearchResult.SelectedIndex - 1];
                ResetPreset();
                return;
            }

            // down -> Select the item Below
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
            {
                if (listSearchResult.SelectedIndex == listSearchResult.Items.Count - 1) return;

                listSearchResult.SelectedItem = listSearchResult.Items[listSearchResult.SelectedIndex + 1];
                ResetPreset();
                return;
            }

            // enter -> Generate or Apply FX
            if (e.KeyCode == Keys.Enter)
            {
                if (SelectedSearchItem == null) return;

                using (UndoBlock undo = new UndoBlock($"Add fx: {SelectedSearchItem.Name}"))
                {
                    GenerateOrApplyFX();
                }
                return;
            }

            // update visible ListBox
            DebounceDispatcher.Throttle((x) =>
            {
                listSearchResult.DataSource = BindedSearchResult;
                ResetPreset();

                // reset SelectedItem index
                if (listSearchResult.Items.Count > 0) listSearchResult.SelectedIndex = 0;
            });
        }

        /// <summary>
        /// Reset (rebind) the visible preset list
        /// </summary>
        private void ResetPreset()
        {
            listItemPresets.DataSource = BindedItemPresets;
        }

        /// <summary>
        /// Double clicking on an item in the ListBox -> GenerateOrApplyFX()
        /// </summary>
        private void listSearchResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!CanApplyPlugin) return;

            using (UndoBlock undo = new UndoBlock($"Add fx: {SelectedSearchItem.Name}"))
            {
                GenerateOrApplyFX();
            }
        }

        /// <summary>
        /// Smashing Enter -> GenerateOrApplyFX()
        /// </summary>
        private void listSearchResult_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || !CanApplyPlugin) return;

            using (UndoBlock undo = new UndoBlock($"Add fx: {SelectedSearchItem.Name}"))
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
            if (listSearchResult.Items.Count < 1 || !CanApplyPlugin) return;

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
            // what's this
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

            var presetName = SelectedItemPreset?.Name ?? stream.Parent.Generator.Presets.FirstOrDefault().Name;
            stream.Parent.Generator.Preset = presetName;

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

                var presetName = SelectedItemPreset?.Name ?? effect.Presets.FirstOrDefault().Name;
                effect.Preset = presetName;
            }
        }
    }
}
