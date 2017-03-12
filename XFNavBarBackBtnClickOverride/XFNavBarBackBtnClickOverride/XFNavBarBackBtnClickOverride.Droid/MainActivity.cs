using System;
using System.Linq;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

namespace XFNavBarBackBtnClickOverride.Droid
{
    [Activity(Label = "XFNavBarBackBtnClickOverride", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            
            Android.Support.V7.Widget.Toolbar toolbar 
                = this.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
        }
        
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            // check if the current item id 
            // is equals to the back button id
            if (item.ItemId == 16908332) // xam forms nav bar back button id
            {
                // retrieve the current xamarin 
                // forms page instance
               var currentpage = (CoolContentPage)Xamarin.Forms.Application.Current.
                    MainPage.Navigation.NavigationStack.LastOrDefault();

                // check if the page has subscribed to the custom back button event
                if (currentpage?.CustomBackButtonAction != null)
                {
                    // invoke the Custom back button action
                    currentpage?.CustomBackButtonAction.Invoke();
                    // and disable the default back button action
                    return false;
                }

                // if its not subscribed then go ahead 
                // with the default back button action
                return base.OnOptionsItemSelected(item);
            }
            else
            {
                // since its not the back button 
                //click, pass the event to the base
                return base.OnOptionsItemSelected(item);
            }
        }

        public override void OnBackPressed()
        {
            // this is really not necessary, but in Android user has both Nav bar back button 
            // and physical back button, so its safe to cover the both events

            var currentpage = (CoolContentPage)Xamarin.Forms.Application.Current.
                MainPage.Navigation.NavigationStack.LastOrDefault();

            if (currentpage?.CustomBackButtonAction != null)
            {
                currentpage?.CustomBackButtonAction.Invoke();
            }
            else
            {
                base.OnBackPressed();
            }
        }
    }
}

