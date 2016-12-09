using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;

namespace DemystifyXFNav.Droid
{
    [Activity(Label = "DemystifyXFNav", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            
            MessagingCenter.Subscribe<HomePage, NativeNavigationArgs>(
                this,
                "THISISAMESSAGE",
                HandleNativeNavigationMessage);
        }

        private void HandleNativeNavigationMessage(HomePage sender, NativeNavigationArgs args)
        {
            Bundle translateBundle = ActivityOptions.MakeCustomAnimation(this, Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out).ToBundle();
            this.StartActivity(new Intent(this, typeof(MyThirdActivity)), translateBundle);
        }
    }
}

