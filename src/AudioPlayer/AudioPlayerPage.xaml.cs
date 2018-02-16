using AudioPlayer.Services;
using AudioPlayer.ViewModels;
using Xamarin.Forms;

namespace AudioPlayer
{
	public partial class AudioPlayerPage : ContentPage
	{
		public AudioPlayerPage()
		{
			InitializeComponent();
			BindingContext = new AudioPlayerViewModel(DependencyService.Get<IAudioPlayerService>());
		}
	}
}
