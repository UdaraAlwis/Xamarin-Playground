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
            if (item.ItemId == 16908332)
            {
               var currentpage = (CoolContentPage)Xamarin.Forms.Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();

                if (currentpage?.CustomBackButtonAction != null)
                {
                    currentpage?.CustomBackButtonAction.Invoke();
                    return false;
                }
                
                return base.OnOptionsItemSelected(item);
            }
            else
            {
                return base.OnOptionsItemSelected(item);
            }
        }

        public override void OnBackPressed()
        {
            var currentpage = (CoolContentPage)Xamarin.Forms.Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();

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

