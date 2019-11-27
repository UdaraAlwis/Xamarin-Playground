using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFAdvThemeing.Services;
using XFAdvThemeing.ThemeResources;
using XFAdvThemeing.Views;

namespace XFAdvThemeing
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            ThemeManager.LoadTheme();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
