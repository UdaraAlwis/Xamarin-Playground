using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using XFAdvThemeing.ThemeResources;

namespace XFAdvThemeing.Droid
{
    [Activity(Label = "XFAdvThemeing", Icon = "@mipmap/icon", Theme = "@style/lightAppTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        //Used to get the Toolbar and then themify the Toolbar icons from this
        public static MainActivity Instance = null;

        public static bool IsAppAlreadyInit = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            //Set Native Android theme as per the Current Theme selection.
            var theme = ThemeManager.CurrentTheme();
            switch (theme)
            {
                case ThemeManager.Themes.Light:
                {
                    SetTheme(Resource.Style.lightAppTheme);
                    break;
                }
                case ThemeManager.Themes.Dark:
                {
                    SetTheme(Resource.Style.darkAppTheme);
                    break;
                }
                case ThemeManager.Themes.Blue:
                {
                    SetTheme(Resource.Style.blueAppTheme);
                    break;
                }
                case ThemeManager.Themes.Orange:
                {
                    SetTheme(Resource.Style.orangeAppTheme);
                    break;
                }
                case ThemeManager.Themes.White:
                {
                    SetTheme(Resource.Style.whiteAppTheme);
                    break;
                }
                default:
                    SetTheme(Resource.Style.lightAppTheme);
                    break;
            }


            base.OnCreate(savedInstanceState);

            // detect whether XF is already init
            // this is handy when changing theme in runtime
            if (IsAppAlreadyInit)
                return;

            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new App());
            Instance = this;
            IsAppAlreadyInit = true;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}