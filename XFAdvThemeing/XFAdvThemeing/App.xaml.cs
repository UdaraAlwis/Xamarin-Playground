using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFAdvThemeing.Services;
using XFAdvThemeing.Views;

namespace XFAdvThemeing
{
    /// <summary>
    /// Based on: https://docs.microsoft.com/en-us/samples/xamarin/xamarin-forms-samples/userinterface-theming/
    /// This is an optimization for Xamarin.Forms Shell apps
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
