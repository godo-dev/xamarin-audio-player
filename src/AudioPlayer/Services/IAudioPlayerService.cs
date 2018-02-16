using System;
namespace AudioPlayer.Services
{
	public interface IAudioPlayerService
	{
		void Play(string pathToAudioFile);
		void Play();
		void Pause();
		Action OnFinishedPlaying { get; set; }
	}
}
