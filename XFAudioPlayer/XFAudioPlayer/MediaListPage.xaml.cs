using MediaManager;
using MediaManager.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFAudioPlayer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MediaListPage : ContentPage
    {
        public MediaListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Device.BeginInvokeOnMainThread(() => {


                List<IMediaItem> queueList = CrossMediaManager.Current.Queue.ToList();
                CollectionView.ItemsSource = queueList;

            });

        }

        private async void CloseButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}