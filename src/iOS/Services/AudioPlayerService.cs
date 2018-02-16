using System;
using System.IO;
using AudioPlayer.iOS.Services;
using AudioPlayer.Services;
using AVFoundation;
using Foundation;
using MediaPlayer;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(AudioPlayerService))]
namespace AudioPlayer.iOS.Services
{
	public class AudioPlayerService : IAudioPlayerService
	{
		private AVAudioPlayer _audioPlayer = null;
		public Action OnFinishedPlaying { get; set; }

		public AudioPlayerService()
		{
		}

		public void Play(string pathToAudioFile)
		{
			if (_audioPlayer != null)
			{
				_audioPlayer.FinishedPlaying -= Player_FinishedPlaying;
				_audioPlayer.Stop();
			}

			string localUrl = pathToAudioFile;
			_audioPlayer = AVAudioPlayer.FromUrl(NSUrl.FromFilename(localUrl));
			_audioPlayer.FinishedPlaying += Player_FinishedPlaying;
			_audioPlayer.Play();
		}

		private void Player_FinishedPlaying(object sender, AVStatusEventArgs e)
		{
			OnFinishedPlaying?.Invoke();
		}

		public void Pause()
		{
			_audioPlayer?.Pause();
		}

		public void Play()
		{
			_audioPlayer?.Play();
		}
	}
}
