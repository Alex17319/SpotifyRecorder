using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec.SongEncoding
{
	public class SongTags
	{
		public string Title       { get; }
		public string Artist      { get; }
		public string Album       { get; }
		public string Year        { get; }
		public string Comment     { get; }
		public string Genre       { get; }
		public string Track       { get; }
		public string Subtitle    { get; }
		public string AlbumArtist { get; }
		public IEnumerable<byte> AlbumArt { get; }
		/// <summary>Album art - PNG, JPG or GIF file content</summary>
		public IEnumerable<string> UserDefinedTags { get; }

		public SongTags(
			string              title           = null,
			string              artist          = null,
			string              album           = null,
			string              year            = null,
			string              comment         = null,
			string              genre           = null,
			string              track           = null,
			string              subtitle        = null,
			string              albumArtist     = null,
			IEnumerable<byte>   albumArt        = null,
			IEnumerable<string> userDefinedTags = null
		) {
			this.Title           = title;
			this.Artist          = artist;
			this.Album           = album;
			this.Year            = year;
			this.Comment         = comment;
			this.Genre           = genre;
			this.Track           = track;
			this.Subtitle        = subtitle;
			this.AlbumArtist     = albumArtist;
			this.AlbumArt        = albumArt;
			this.UserDefinedTags = userDefinedTags;
		}
	}
}
