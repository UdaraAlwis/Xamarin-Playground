using System;
using Microsoft.WindowsAzure.MobileServices;

namespace UdaraMyNotesApp
{
    public class App : Xamarin.Forms.Application
    {
        public static MobileServiceClient MobileService;

        public App()
        {
            MobileService =
                    new MobileServiceClient(
                    "https://udaramynotesapp.azurewebsites.net");

            MainPage = new MainPage();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }

        protected override void OnStart()
        {
            base.OnStart();
        }
    }
}
