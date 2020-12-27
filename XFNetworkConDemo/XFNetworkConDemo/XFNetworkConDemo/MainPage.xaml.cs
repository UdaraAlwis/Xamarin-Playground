using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XFNetworkConDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            UpdateNetworkInfo(
                Connectivity.NetworkAccess,
                Connectivity.ConnectionProfiles.Any()
                    ? Connectivity.ConnectionProfiles.First() : ConnectionProfile.Unknown);
            Connectivity.ConnectivityChanged += OnConnectivityChanged;
        }

        private void OnConnectivityChanged
            (object sender, ConnectivityChangedEventArgs e)
        {
            UpdateNetworkInfo(
                e.NetworkAccess,
                e.ConnectionProfiles.Any() 
                    ? e.ConnectionProfiles.First() : ConnectionProfile.Unknown);
        }

        private void UpdateNetworkInfo(
            NetworkAccess networkAccessState, 
            ConnectionProfile connectionProfileAvailable)
        {
            // Update the Connectivity Status in UI
            if (networkAccessState == NetworkAccess.Internet)
            {
                ConnectionStatusLabel.Text = "Internet Access Available!";
            }
            else if (networkAccessState == NetworkAccess.None)
            {
                ConnectionStatusLabel.Text = "Sorry! No Internet Access";
            }

            // Update the Connectivity Profile Available in the UI
            if (connectionProfileAvailable == ConnectionProfile.WiFi)
            {
                ConnectionProfileLabel.Text = "Wifi Connected!";
            }
            else if (connectionProfileAvailable == ConnectionProfile.Cellular)
            {
                ConnectionProfileLabel.Text = "Cellular Connected!";
            }
            else if (connectionProfileAvailable == ConnectionProfile.Ethernet)
            {
                ConnectionProfileLabel.Text = "Ethernet Connected!";
            }
            else if (connectionProfileAvailable == ConnectionProfile.Unknown)
            {
                ConnectionProfileLabel.Text = "Sorry! Not Connected!";
            }
        }
    }
}
