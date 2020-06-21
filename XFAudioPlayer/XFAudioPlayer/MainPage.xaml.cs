using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaManager;
using MediaManager.Playback;
using MediaManager.Queue;
using Xamarin.Forms;

namespace XFAudioPlayer
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            CrossMediaManager.Current.StateChanged += CurrentOnStateChanged;
            CrossMediaManager.Current.PositionChanged += Current_PositionChanged;
            CrossMediaManager.Current.MediaItemChanged += Current_MediaItemChanged;
        }

        private void Current_MediaItemChanged(object sender, MediaManager.Media.MediaItemEventArgs e)
        {
            // Media item details
            var displayDetails = string.Empty;
            if (!string.IsNullOrEmpty(e.MediaItem.DisplayTitle))
                displayDetails = e.MediaItem.DisplayTitle;

            if (!string.IsNullOrEmpty(e.MediaItem.Artist))
                displayDetails = $"{displayDetails} - {e.MediaItem.Artist}";

            LabelMediaDetails.Text = displayDetails.ToUpper();
        }

        private void Current_PositionChanged(object sender, MediaManager.Playback.PositionChangedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var formattingPattern = @"hh\:mm\:ss";
                if (CrossMediaManager.Current.Duration.Hours <= 0)
                    formattingPattern = @"mm\:ss";
                
                var fullLengthString = CrossMediaManager.Current.Duration.ToString(formattingPattern);
                LabelPositionStatus.Text = $"{e.Position.ToString(formattingPattern)}/{fullLengthString}";

                if (CrossMediaManager.Current.Duration.Ticks >= 0)
                {
                    SliderSongPlayDisplay.Value = e.Position.Ticks;
                }
            });
        }

        private void CurrentOnStateChanged(object sender, StateChangedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                LabelPlayerStatus.Text = $"{e.State.ToString().ToUpper()}";

                if (e.State == MediaManager.Player.MediaPlayerState.Loading)
                {
                    SliderSongPlayDisplay.Value = 0;
                }
                else if(e.State == MediaManager.Player.MediaPlayerState.Playing)
                {
                    SliderSongPlayDisplay.Maximum = CrossMediaManager.Current.Duration.Ticks;
                }
            });
        }

        private async void PlayPauseButton_Clicked(object sender, EventArgs e)
        {
            if (!CrossMediaManager.Current.IsPrepared())
            {
                var songList = new List<string>() {
                    "https://www.youtube.com/audiolibrary_download?vid=a5cfdce9cccb6bee",
                    "https://www.youtube.com/audiolibrary_download?vid=d912d6857fe2a2d3",
                    "https://www.youtube.com/audiolibrary_download?vid=14d17c8a07ae2c51",
                    "https://www.youtube.com/audiolibrary_download?vid=191194a6ae406279",
                    "https://www.youtube.com/audiolibrary_download?vid=28fdb076e79a2214",
                    "https://www.youtube.com/audiolibrary_download?vid=f373cf6d4c94f010",
                };

                await CrossMediaManager.Current.Play(songList);
                CrossMediaManager.Current.ShuffleMode = ShuffleMode.All;
                CrossMediaManager.Current.PlayNextOnFailed = true;
                CrossMediaManager.Current.RepeatMode = RepeatMode.All;
                CrossMediaManager.Current.AutoPlay = true;
            }
            else
            {
                await CrossMediaManager.Current.PlayPause();
            }
        }

        private async void PreviusButton_Clicked(object sender, EventArgs e) 
        {
            await CrossMediaManager.Current.PlayPrevious();            
        }

        private async void NextButton_Clicked(object sender, EventArgs e) 
        {
            await CrossMediaManager.Current.PlayNext();            
        }

        private async void ForwardButton_Clicked(object sender, EventArgs e)
        {
            await CrossMediaManager.Current.StepForward();
        }

        private async void RewindButton_Clicked(object sender, EventArgs e)
        {
            await CrossMediaManager.Current.StepBackward();
        }
    }
}
