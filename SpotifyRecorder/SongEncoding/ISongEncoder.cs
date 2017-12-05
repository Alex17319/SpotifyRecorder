using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;
using System.IO;

namespace SpotifyRec.SongEncoding
{
	public interface ISongEncoder
	{
		/// <summary>
		/// The extension that should be used for the destination file, including the preceding dot (".")
		/// </summary>
		string Extension { get; }

		/// <summary>
		/// Takes a wave file, converts the audio to the format for the current type,
		/// and saves the result in another file
		/// </summary>
		/// <param name="source">The source wave file</param>
		/// <param name="outputPath">
		/// The path of the destination file. Should include the extension (use <see cref="Extension"/>).
		/// </param>
		/// <param name="tags">The tags embedded into the resulting file (if supported).</param>
		/// <param name="reusedBuffer">
		/// The buffer used when copying. Should be passed in and reused to avoid excess memory use/garbage collection.
		/// </param>
		/// Note: MediaFoundationEncoder.EncodeTo___() requires that the destination be a path string, not a Stream
		void Encode(Stream source, string outputPath, SongTags tags, byte[] reusedBuffer);
	}
}
