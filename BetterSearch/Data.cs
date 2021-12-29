using ScriptPortal.Vegas;
//using Sony.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterSearch
{
    public class Data
    {
        /// <summary>
        /// Vegas Vegas -> VEGAS
        /// </summary>
        public static Vegas Vegas { get; set; }

        /// <summary>
        /// Current cursor position on the timeline
        /// </summary>
        public static Timecode CursorPosition => Vegas.Transport.CursorPosition;

        /// <summary>
        /// List of currently Selected Medias
        /// </summary>
        public static List<TrackEvent> SelectedMedias => Vegas.Project.Tracks.SelectMany(x => x.Events.Where(y => y.Selected)).ToList();

        #region Tracks
        /// <summary>
        /// Video Tracks
        /// </summary>
        public static IEnumerable<Track> VideoTracks => Vegas.Project.Tracks.Where(x => x.MediaType == MediaType.Video);

        /// <summary>
        /// Selected Video Tracks
        /// </summary>
        public static IEnumerable<Track> SelectedVideoTracks => VideoTracks.Where(x => x.Selected);

        /// <summary>
        /// First Selected Video Track
        /// </summary>
        public static Track FirstSelectedVideoTrack => SelectedVideoTracks.FirstOrDefault();

        /// <summary>
        /// Audio Tracks
        /// </summary>
        public static IEnumerable<Track> AudioTracks => Vegas.Project.Tracks.Where(x => x.MediaType == MediaType.Audio);

        /// <summary>
        /// Selected Audio Tracks
        /// </summary>
        public static IEnumerable<Track> SelectedAudioTracks => AudioTracks.Where(x => x.Selected);

        /// <summary>
        /// First Selected Audio Tracks
        /// </summary>
        public static Track FirstSelectedAudioTrack => SelectedAudioTracks.FirstOrDefault();
        #endregion
    }
}
