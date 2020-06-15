using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaManager;
using MediaManager.Playback;
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

            CrossMediaManager.Current.BufferedChanged += CurrentOnBufferedChanged;
            CrossMediaManager.Current.StateChanged += CurrentOnStateChanged;
        }

        private void CurrentOnStateChanged(object sender, StateChangedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                playerStatus.Text = $"{e.State}";
            });
        }

        private void CurrentOnBufferedChanged(object sender, BufferedChangedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                bufferStatus.Text = $"buffered: {e.Buffered.ToString()}";
            });
        }

        private bool isAudioLoaded;

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!isAudioLoaded)
            {
                isAudioLoaded = true;
                await CrossMediaManager.Current.Play("https://ia800806.us.archive.org/15/items/Mp3Playlist_555/AaronNeville-CrazyLove.mp3");
            }
            else
            {
                await CrossMediaManager.Current.PlayPause();
            }
        }
    }
}
