using ScriptPortal.Vegas;
//using Sony.Vegas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
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
			InitializeComponent();
			listSearchResult.DataSource = _bindedSearchResult;
		}

		/// <summary>
		/// Concat the result of the lists
		/// </summary>
		private IEnumerable<ExtendedPlugInNode> _searchResult =>
					new List<ExtendedPlugInNode> { new ExtendedPlugInNode { Name = "- - - VIDEO FX - - -" } }.Concat(Data.VideoFX)
			.Concat(new List<ExtendedPlugInNode> { new ExtendedPlugInNode { Name = "- - - AUDIO FX - - -" } }).Concat(Data.AudioFX)
			.Concat(new List<ExtendedPlugInNode> { new ExtendedPlugInNode { Name = "- - - GENERATORS - - -" } }).Concat(Data.Generators)
			//.Concat(new List<ExtendedPlugInNode> { new ExtendedPlugInNode { Name = "- - - TRANSITIONS - - -" } }).Concat(Data.Transitions)
			;

		/// <summary>
		/// Search results that get binded to the ListBox
		/// </summary>
		BindingList<string> _bindedSearchResult => new BindingList<string>(_searchResult.Select(x => x.Name).ToList());

		/// <summary>
		/// Selected PlugInNode on the list
		/// </summary>
		public ExtendedPlugInNode SelectedSearchItem => _searchResult.FirstOrDefault(x => listSearchResult.SelectedItem != null &&
																						  x.Name == listSearchResult.SelectedItem.ToString());

		/// <summary>
		/// Item Presets that get binded to the ListBox
		/// </summary>
		BindingList<string> _bindedItemPresets => SelectedSearchItem != null && SelectedSearchItem.Plugin != null
			? new BindingList<string>(SelectedSearchItem.Plugin.Presets.Select(x => x.Name).ToList())
			: new BindingList<string>();

		/// <summary>
		/// Selected Preset on the list
		/// </summary>
		public EffectPreset SelectedItemPreset => SelectedSearchItem.Plugin.Presets.FirstOrDefault(x => listItemPresets.SelectedItem != null &&
																										x.Name == listItemPresets.SelectedItem.ToString().Trim());

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
			if (e.KeyCode == Keys.Up)
			{
				if (listSearchResult.SelectedIndex == 0) return;

				listSearchResult.SelectedItem = listSearchResult.Items[listSearchResult.SelectedIndex - 1];
				ResetPreset();
				return;
			}

			// down -> Select the item Below
			else if (e.KeyCode == Keys.Down)
			{
				if (listSearchResult.SelectedIndex == listSearchResult.Items.Count - 1) return;

				listSearchResult.SelectedItem = listSearchResult.Items[listSearchResult.SelectedIndex + 1];
				ResetPreset();
				return;
			}

			// enter -> Generate or Apply FX
			else if (e.KeyCode == Keys.Enter)
			{
				if (SelectedSearchItem == null) return;

				using (UndoBlock undo = new UndoBlock($"Add fx: {SelectedSearchItem.Plugin.Name}"))
				{
					GenerateOrApplyFX();
				}
				return;
			}

			// update visible ListBox
			listSearchResult.DataSource = _bindedSearchResult;
			ResetPreset();

			// reset SelectedItem index
			if (listSearchResult.Items.Count > 0) listSearchResult.SelectedIndex = 0;
		}

		/// <summary>
		/// Reset (rebind) the visible preset list
		/// </summary>
		private void ResetPreset()
		{
			listItemPresets.DataSource = _bindedItemPresets;
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
