using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XFShellBackButtonOverride.Views;

namespace XFShellBackButtonOverride
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(FirstPage), typeof(FirstPage));
            Routing.RegisterRoute(nameof(SecondPage), typeof(SecondPage));
            Routing.RegisterRoute(nameof(ThirdPage), typeof(ThirdPage));
        }

        // This also works for overriding Android on-screen back button
        //protected override bool OnBackButtonPressed()
        //{
        //    // true or false to disable or enable the action
        //    return base.OnBackButtonPressed();
        //}
    }
}
