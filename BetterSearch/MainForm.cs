using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
            try
            {
                Data.Vegas = vegas;
                Methods.ReadConfig();

                InitializeComponent();

                cbxDarkTheme.Checked = Data.Config.DarkMode;
                ChangeTheme(cbxDarkTheme.Checked ? ColorScheme.Dark : ColorScheme.Light);

                listSearchResult.ContextMenuStrip = cmsFavorites;

                // Bind items
                listSearchResult.DataSource = BindedSearchResult;
                listItemPresets.DataSource = BindedItemPresets;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
                throw new Exception("Error: " + e.Message);
            }
        }

        /// <summary>
        /// Ignored Keys in the Search
        /// </summary>
        public List<Keys> _ignoredKeys => new List<Keys>() {
            Keys.ControlKey, Keys.ShiftKey, Keys.Menu, Keys.Alt, Keys.Tab, Keys.CapsLock
        };

        /// <summary>
        /// Concat the result of the lists
        /// </summary>
        public IEnumerable<ExtendedPlugInNode> SearchResult =>
                   (new List<ExtendedPlugInNode> { new ExtendedPlugInNode("- - - - VIDEO FX - - - -") }).Concat(Data.SearchIn(Data.VideoFX, txtSearch.Text))
            .Concat(new List<ExtendedPlugInNode> { new ExtendedPlugInNode("- - - - AUDIO FX - - - -") }).Concat(Data.SearchIn(Data.AudioFX, txtSearch.Text))
            .Concat(new List<ExtendedPlugInNode> { new ExtendedPlugInNode("- - - - GENERATORS - - - -") }).Concat(Data.SearchIn(Data.Generators, txtSearch.Text))
            .Concat(new List<ExtendedPlugInNode> { new ExtendedPlugInNode("- - - - TRANSITIONS - - - -") }).Concat(Data.SearchIn(Data.Transitions, txtSearch.Text))
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
        /// Color Scheme
        /// </summary>
        public class ColorScheme
        {
            public Color PanelBG { get; set; }
            public Color BoxBG { get; set; }
            public Color Text { get; set; }
            public static ColorScheme Dark { get; } = new ColorScheme
            {
                PanelBG = Color.FromArgb(45, 45, 45),
                BoxBG = Color.FromArgb(70, 70, 70),
                Text = Color.White,
            };
            public static ColorScheme Light { get; } = new ColorScheme
            {
                PanelBG = Color.WhiteSmoke,
                BoxBG = Color.White,
                Text = Color.Black,
            };
        }

        public void ChangeTheme(ColorScheme scheme, ControlCollection controls = null)
        {
            BackColor = scheme.PanelBG;
            ForeColor = scheme.Text;
            foreach (Control component in controls ?? Controls)
            {
                if (component.Controls.Count > 0)
                    ChangeTheme(scheme, component.Controls);

                component.ForeColor = scheme.Text;

                component.BackColor = component is CheckBox || component is GroupBox
                    ? scheme.PanelBG
                    : scheme.BoxBG;
            }
        }

        private void cbxDarkTheme_CheckedChanged(object sender, EventArgs e)
        {
            Data.Config.DarkMode = cbxDarkTheme.Checked;
            ChangeTheme(cbxDarkTheme.Checked ? ColorScheme.Dark : ColorScheme.Light);
            Methods.SaveConfig();
        }

        /// <summary>
        /// Selected item index changed
        /// </summary>
        private void listSearchResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetPreset();

            // if right click
            // open ContextMenuStrip
            //listSearchResult.ContextMenuStrip = cmsFavorites;
        }

        /// <summary>
        /// Search on tip taps
        /// </summary>
        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            // cehck for ignored keys
            if (_ignoredKeys.Contains(e.KeyCode)) return;

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
                if (SelectedSearchItem.IsTransition)
                {
                    /// TODO: Transition
                    // first media ->> second media
                    // ...
                    continue;
                }

                if (trackEvent.IsAudio())
                {
                    if (!SelectedSearchItem.Plugin.IsAudio)
                    {
                        MessageBox.Show("You cannot apply a non AudioFX on an Audio Event.");
                        continue;
                    }
                    var audioEvent = (AudioEvent)trackEvent;
                    var afx = new Effect(SelectedSearchItem.Plugin);
                    audioEvent.Effects.Add(afx);
                    afx.Preset = SelectedItemPreset?.Name ?? afx.Presets.FirstOrDefault().Name;
                    continue;
                }

                if (!SelectedSearchItem.Plugin.IsVideo)
                {
                    MessageBox.Show("You cannot apply a non VideoFX on a Video Event.");
                    continue;
                }
                var videoEvent = (VideoEvent)trackEvent;
                var vfx = new Effect(SelectedSearchItem.Plugin);
                videoEvent.Effects.Add(vfx);
                vfx.Preset = SelectedItemPreset?.Name ?? vfx.Presets.FirstOrDefault().Name;
            }
        }

        private void cmsiAddToFavs_Click(object sender, EventArgs e)
        {
            if (SelectedSearchItem == null || SelectedSearchItem.Plugin == null) return;

            var id = SelectedSearchItem.UniqueID;
            var type = SelectedSearchItem.GetFavType();

            if (Data.Config.Favorites.Any(x => x.UniqueIDs.Contains(id) && x.Type == type)) return;

            Methods.AddToFavorites(id, type);
        }

        private void cmsiRemoveFromFavs_Click(object sender, EventArgs e)
        {
            if (SelectedSearchItem == null || SelectedSearchItem.Plugin == null) return;

            var id = SelectedSearchItem.UniqueID;
            var type = SelectedSearchItem.GetFavType();

            if (Data.Config.Favorites.Any(x => x.UniqueIDs.Contains(id) && x.Type == type)) return;

            Methods.RemoveFromFavorites(id, type);
        }

        private void cmsFavorites_MouseLeave(object sender, EventArgs e)
        {
            cmsFavorites.Close();
        }
    }
}
