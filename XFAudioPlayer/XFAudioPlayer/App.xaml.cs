using System;
using MediaManager;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFAudioPlayer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            CrossMediaManager.Current.Init();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
