using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using XFAdvThemeing.Dependencies;
using XFAdvThemeing.Droid.Dependencies;
using XFAdvThemeing.ThemeResources;

[assembly: Dependency(typeof(NativeServices))]
namespace XFAdvThemeing.Droid.Dependencies
{
    public class NativeServices : INativeServices
    {
        public void OnThemeChanged(ThemeManager.Themes theme)
        {
            //Some attempts to restart activity without loosing Fragments inside it.
            //currently all options restarts the app from Main DashboardPage.

            /*
            var f = GetVisibleFragment();
            f.Activity.Recreate();
            */

            /*
            Intent intent = new Intent(f.Context, typeof(MainActivity));
            intent.SetFlags(ActivityFlags.ClearTask);
            f.Context.StartActivity(intent);
            */

            /*
            Android.Support.V4.App.FragmentTransaction ft = MainActivity.Instance.SupportFragmentManager.BeginTransaction();
            ft.Detach(f);
            ft.Attach(f);
            ft.Commit();
            */

            MainActivity activity = MainActivity.Instance;
            var intent = MainActivity.Instance.Intent;
            activity.Finish();
            activity.StartActivity(intent);


            /*Bundle savedInstanceState = new Bundle();
            ////this is important to save all your open states/fragment states
            MainActivity.Instance.OnSaveInstanceState(savedInstanceState);
            MainActivity.Instance.Recreate();
            MainActivity.Instance.OnCreate(savedInstanceState, null);
            */

            /*Intent i = MainActivity.Instance.Intent;
            MainActivity.Instance.OverridePendingTransition(0, 0);
            i.AddFlags(ActivityFlags.NoAnimation);
            MainActivity.Instance.Finish();
            //restart the activity without animation
            MainActivity.Instance.OverridePendingTransition(0, 0);
            MainActivity.Instance.StartActivity(i);*/
        }


        public Android.Support.V4.App.Fragment GetVisibleFragment()
        {
            Android.Support.V4.App.FragmentManager fragmentManager = MainActivity.Instance.SupportFragmentManager;
            List<Android.Support.V4.App.Fragment> fragments = fragmentManager.Fragments.ToList();
            if (fragments != null)
            {
                foreach (var fragment in fragments)
                {
                    if (fragment != null && fragment.IsVisible)
                        return fragment;
                }
            }
            return null;
        }
    }
}