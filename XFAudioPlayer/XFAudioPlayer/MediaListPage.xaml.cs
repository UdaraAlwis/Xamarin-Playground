using MediaManager;
using MediaManager.Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

                ObservableCollection<AudioItem> list = new ObservableCollection<AudioItem>();
                for (int i = 0; i < queueList.Count; i++)
                {
                    IMediaItem item = queueList[i];

                    string title = "-"; string artist = "-";

                    if (!string.IsNullOrEmpty(item.DisplayTitle))
                        title = $"{item.DisplayTitle.ToUpper()}";

                    if (!string.IsNullOrEmpty(item.Artist))
                        artist = $"{item.Artist.ToUpper()}";

                    list.Add(new AudioItem()
                    {
                        Title = title,
                        Artist = artist,
                        Index = i + 1
                    });
                }

                CollectionView.ItemsSource = list;

            });

        }

        private async void CloseButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }

    public class AudioItem 
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public int Index { get; set; }
    }
}