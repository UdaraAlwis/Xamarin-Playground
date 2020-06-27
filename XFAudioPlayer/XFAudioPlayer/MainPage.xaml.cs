using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using MediaManager;
using MediaManager.Library;
using MediaManager.Media;
using MediaManager.Playback;
using MediaManager.Player;
using MediaManager.Queue;
using Xamarin.Forms;
using PositionChangedEventArgs = MediaManager.Playback.PositionChangedEventArgs;

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

            CrossMediaManager.Current.StateChanged += Current_OnStateChanged;
            CrossMediaManager.Current.PositionChanged += Current_PositionChanged;
            CrossMediaManager.Current.MediaItemChanged += Current_MediaItemChanged;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (!CrossMediaManager.Current.IsPrepared())
            {
                await BeginPlay();

                // Set up Player Preferences
                CrossMediaManager.Current.ShuffleMode = ShuffleMode.All;
                CrossMediaManager.Current.PlayNextOnFailed = true;
                CrossMediaManager.Current.RepeatMode = RepeatMode.All;
                CrossMediaManager.Current.AutoPlay = true;
            }
            else
            {
                SetupCurrentMediaDetails(CrossMediaManager.Current.Queue.Current);
                SetupCurrentMediaPositionData(CrossMediaManager.Current.Position);
                SetupCurrentMediaPlayerState(CrossMediaManager.Current.State);
            }
        }

        private async Task BeginPlay()
        {
            var songList = new List<string>() {
                "https://www.youtube.com/audiolibrary_download?vid=a5cfdce9cccb6bee",
                "https://files.freemusicarchive.org/storage-freemusicarchive-org/music/no_curator/Yung_Kartz/July_2019/Yung_Kartz_-_02_-_Levels.mp3",
                "https://www.youtube.com/audiolibrary_download?vid=d912d6857fe2a2d3",
                "https://www.youtube.com/audiolibrary_download?vid=14d17c8a07ae2c51",
                "https://files.freemusicarchive.org/storage-freemusicarchive-org/music/Creative_Commons/Ketsa/Raising_Frequency/Ketsa_-_08_-_Multiverse.mp3",
                "https://files.freemusicarchive.org/storage-freemusicarchive-org/music/Oddio_Overplay/Carl_Phaser/End_Of_The_Dark/Carl_Phaser_-_02_-_Porcelain.mp3",
                "https://www.youtube.com/audiolibrary_download?vid=191194a6ae406279",
                "https://files.freemusicarchive.org/storage-freemusicarchive-org/music/blocSonic/Flex_Vector/Born_Ready/Flex_Vector_-_Born_Ready.mp3",
                "https://www.youtube.com/audiolibrary_download?vid=28fdb076e79a2214",
                "https://files.freemusicarchive.org/storage-freemusicarchive-org/music/no_curator/Elephant/The_Art_of_Living_Part_2/Elephant_-_09_-_The_Final_Crusade.mp3",
                "https://www.youtube.com/audiolibrary_download?vid=f373cf6d4c94f010",
            };

            var currentMediaItem = await CrossMediaManager.Current.Play(songList);
            SetupCurrentMediaDetails(currentMediaItem);
        }

        private void SetupCurrentMediaDetails(IMediaItem currentMediaItem)
        {
            // Set up Media item details in UI
            var displayDetails = string.Empty;
            if (!string.IsNullOrEmpty(currentMediaItem.DisplayTitle))
                displayDetails = currentMediaItem.DisplayTitle;

            if (!string.IsNullOrEmpty(currentMediaItem.Artist))
                displayDetails = $"{displayDetails} - {currentMediaItem.Artist}";

            LabelMediaDetails.Text = displayDetails.ToUpper();
        }

        private void SetupCurrentMediaPositionData(TimeSpan currentPlaybackPosition)
        {
            var formattingPattern = @"hh\:mm\:ss";
            if (CrossMediaManager.Current.Duration.Hours <= 0)
                formattingPattern = @"mm\:ss";

            var fullLengthString = CrossMediaManager.Current.Duration.ToString(formattingPattern);
            LabelPositionStatus.Text = $"{currentPlaybackPosition.ToString(formattingPattern)}/{fullLengthString}";

            SliderSongPlayDisplay.Value = currentPlaybackPosition.Ticks;
        }

        private void SetupCurrentMediaPlayerState(MediaPlayerState currentPlayerState)
        {
            LabelPlayerStatus.Text = $"{currentPlayerState.ToString().ToUpper()}";

            if (currentPlayerState == MediaManager.Player.MediaPlayerState.Loading)
            {
                SliderSongPlayDisplay.Value = 0;
            }
            else if (currentPlayerState == MediaManager.Player.MediaPlayerState.Playing
                    && CrossMediaManager.Current.Duration.Ticks > 0)
            {
                SliderSongPlayDisplay.Maximum = CrossMediaManager.Current.Duration.Ticks;
            }
        }

        private void Current_MediaItemChanged(object sender, MediaItemEventArgs e)
        {
            SetupCurrentMediaDetails(e.MediaItem);
        }

        private void Current_PositionChanged(object sender, PositionChangedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                SetupCurrentMediaPositionData(e.Position);
            });
        }

        private void Current_OnStateChanged(object sender, StateChangedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() => 
            {
                SetupCurrentMediaPlayerState(e.State); 
            });
        }

        private async void PlayPauseButton_Clicked(object sender, EventArgs e)
        {
            if (!CrossMediaManager.Current.IsPrepared())
            {
                await BeginPlay();
            }
            else
            {
                await CrossMediaManager.Current.PlayPause();
            }
        }

        private async void PreviousButton_Clicked(object sender, EventArgs e) 
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

        private async void GoToPlaylist_Clicked(object sender, EventArgs e) 
        {
            await Navigation.PushModalAsync(new MediaListPage());
        }
    }
}
