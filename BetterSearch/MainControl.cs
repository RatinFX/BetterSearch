using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using VegasProData.Base;
using VegasProData.General;
using VegasProData.Favorites;
using VegasProData.Theme;
using VegasProData.Threading;

namespace BetterSearch.Views
{
    public partial class MainControl : UserControl
    {
        public Timecode BASE_LENGTH = Timecode.FromSeconds(10);
        public Vegas Vegas { get; set; }
        public ThemeConfig ThemeConfig { get; set; } = new ThemeConfig(true);
        public FavoriteConfig FavoriteConfig { get; set; } = new FavoriteConfig(true);

        /// <summary>
        /// Ignored Keys in the Search
        /// </summary>
        public List<Keys> IgnoredKeys { get; } = new List<Keys>() {
            Keys.ControlKey, Keys.ShiftKey, Keys.Menu, Keys.Alt, Keys.Tab, Keys.CapsLock
        };

        public MainControl(Vegas vegas)
        {
            try
            {
                Data.Vegas = vegas;

                InitializeComponent();

                // Bind items
                listSearchResult.ContextMenuStrip = cmsFavorites;
                listSearchResult.DataSource = BindedSearchResult;
                listItemPresets.DataSource = BindedItemPresets;

                // Add themes to the list
                foreach (var item in ThemeConfig.Themes)
                {
                    if (tsmiThemes.DropDownItems.ContainsKey(item.Name))
                        continue;

                    var tsmi = new ToolStripMenuItem(item.Name)
                    {
                        Name = "tsmit" + item.Name,
                    };

                    tsmi.Click += tsmiTheme_Click;

                    // Check CheckBox if it's selected
                    tsmi.Checked = ThemeConfig.CurrentTheme.Name == item.Name;

                    // Add to list
                    tsmiThemes.DropDownItems.Add(tsmi);
                }

                ChangeTheme();
            }
            catch (Exception e)
            {
                MessageBoxes.Error(e);
                throw;
            }
        }

        private void tsmiTheme_Click(object sender, EventArgs e)
        {
            var tsmit = sender as ToolStripMenuItem;

            ThemeConfig.CurrentTheme = ThemeConfig.Themes.FirstOrDefault(x => x.Name == tsmit.Text)
                ?? ThemeConfig.CurrentTheme
                ?? ThemeConfig.Themes.FirstOrDefault();

            ThemeConfig.Save();

            // Uncheck items
            foreach (ToolStripMenuItem item in tsmiThemes.DropDownItems)
            {
                item.Checked = ThemeConfig.CurrentTheme.Name == item.Text;
            }

            ChangeTheme();
        }

        void ChangeTheme()
        {
            ThemeController.ChangeThemeTo(
                ThemeConfig.CurrentTheme,
                userControl: this,
                menuStrip: menuStrip,
                controls: Controls
            );
        }

        /// <summary>
        /// Plugin list filtered by SearchText and Favorite, if checked
        /// </summary>
        public IEnumerable<FavoriteExtendedPlugInNode> SearchResult => FavoriteData.GetSearchResult(FavoriteConfig, txtSearch.Text, tsmisOnlyShowFavorites.Checked);

        /// <summary>
        /// Search results that get binded to the ListBox
        /// </summary>
        public BindingList<string> BindedSearchResult => new BindingList<string>(SearchResult.Select(x => x.Name).ToList());

        /// <summary>
        /// Selected PlugInNode on the list
        /// </summary>
        public FavoriteExtendedPlugInNode SelectedSearchItem => SearchResult.FirstOrDefault(x =>
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
        public EffectPreset SelectedItemPreset => SelectedSearchItem?.Plugin?.Presets.FirstOrDefault(x =>
            listItemPresets.SelectedItem != null && x.Name == listItemPresets.SelectedItem.ToString().Trim());

        private void listSearchResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetPreset();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            // cehck for ignored keys
            if (IgnoredKeys.Contains(e.KeyCode))
                return;

            // up -> Select the item Above
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
            {
                if (listSearchResult.SelectedIndex == 0)
                    return;

                listSearchResult.SelectedItem = listSearchResult.Items[listSearchResult.SelectedIndex - 1];
                ResetPreset();
                return;
            }

            // down -> Select the item Below
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
            {
                if (listSearchResult.SelectedIndex == listSearchResult.Items.Count - 1)
                    return;

                listSearchResult.SelectedItem = listSearchResult.Items[listSearchResult.SelectedIndex + 1];
                ResetPreset();
                return;
            }

            // enter -> Generate or Apply FX
            if (e.KeyCode == Keys.Enter)
            {

                if (SelectedSearchItem == null)
                    return;

                GenerateOrApplyFX();
                return;
            }

            // update visible ListBox
            DebounceDispatcher.Throttle(_ => SetBindedSearchResult());
        }

        /// <summary>
        /// Reset (rebind) the visible Search Result list
        /// </summary>
        private void SetBindedSearchResult()
        {
            listSearchResult.DataSource = BindedSearchResult;
            ResetPreset();

            // reset SelectedItem index
            if (listSearchResult.Items.Count > 0)
                listSearchResult.SelectedIndex = 0;
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
            if (!CanApplyPlugin)
                return;

            GenerateOrApplyFX();
        }

        /// <summary>
        /// Pressing Enter -> GenerateOrApplyFX()
        /// </summary>
        private void listSearchResult_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || !CanApplyPlugin)
                return;

            GenerateOrApplyFX();
        }

        /// <summary>
        /// Either Generate the Generator or Apply the FX to the selected media(s)
        /// </summary>
        private void GenerateOrApplyFX()
        {
            using (var undo = new UndoBlock($"Add fx: {SelectedSearchItem.Name}"))
            {
                if (listSearchResult.Items.Count < 1 || !CanApplyPlugin)
                    return;

                // Generator -> Generate it
                if (SelectedSearchItem.IsGenerator)
                {
                    GenerateGenerator();
                }
                // Apply FX
                else
                {
                    ApplyFXToSelectedMedias();
                }
            }
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

            // No selected VideoTrack
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
                foreach (var track in Data.SelectedAudioTracks)
                    track.Selected = false;
            }

            var presetName = SelectedItemPreset?.Name
                ?? stream.Parent.Generator.Presets.FirstOrDefault().Name;

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
                // Transition
                if (SelectedSearchItem.IsTransition)
                {
                    /// TODO: Transition
                    // first media ->> second media
                    // ...
                    continue;
                }

                // Audio FX
                if (trackEvent.IsAudio())
                {
                    // Non-AudioFX on Audio Event
                    if (!SelectedSearchItem.Plugin.IsAudio)
                    {
                        MessageBoxes.Error("You cannot apply a non AudioFX on an Audio Event.");
                        continue;
                    }

                    var audioEvent = trackEvent as AudioEvent;
                    var afx = new Effect(SelectedSearchItem.Plugin);
                    audioEvent.Effects.Add(afx);
                    afx.Preset = SelectedItemPreset?.Name ?? afx.Presets.FirstOrDefault().Name;
                    continue;
                }

                // Video FX
                if (trackEvent.IsVideo())
                {
                    // Non-VideoFX on Video Event
                    if (!SelectedSearchItem.Plugin.IsVideo)
                    {
                        MessageBoxes.Error("You cannot apply a non VideoFX on a Video Event.");
                        continue;
                    }

                    var videoEvent = trackEvent as VideoEvent;
                    var vfx = new Effect(SelectedSearchItem.Plugin);
                    videoEvent.Effects.Add(vfx);
                    vfx.Preset = SelectedItemPreset?.Name ?? vfx.Presets.FirstOrDefault().Name;
                }
            }
        }

        private void cmsFavorites_MouseLeave(object sender, EventArgs e)
        {
            cmsFavorites.Close();
        }

        private void cmsiAddToFavs_Click(object sender, EventArgs e)
        {
            if (SelectedSearchItem == null || SelectedSearchItem.Plugin == null)
                return;

            FavoriteConfig.Add(SelectedSearchItem);

            if (tsmisOnlyShowFavorites.Checked)
                SetBindedSearchResult();
        }

        private void cmsiRemoveFromFavs_Click(object sender, EventArgs e)
        {
            if (SelectedSearchItem == null || SelectedSearchItem.Plugin == null)
                return;

            FavoriteConfig.Remove(SelectedSearchItem);

            if (tsmisOnlyShowFavorites.Checked)
                SetBindedSearchResult();
        }

        private void smiOnlyShowFavorites_Click(object sender, EventArgs e)
        {
            SetBindedSearchResult();
        }
    }
}
