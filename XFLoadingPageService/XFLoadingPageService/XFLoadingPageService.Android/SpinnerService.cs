using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Plugin.CurrentActivity;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFLoadingPageService.Droid;
using XFPlatform = Xamarin.Forms.Platform.Android.Platform;

[assembly: Xamarin.Forms.Dependency(typeof(LodingPageServiceDroid))]
namespace XFLoadingPageService.Droid
{
    public class LodingPageServiceDroid : ILodingPageService
    {
        private Android.Views.View _nativeView;

        private Dialog dialog;

        private bool _isInitialized;

        public void ShowLoadingPage()
        {

            if (!_isInitialized)
            {
                var loadingPageView = new LoadingIndicatorPage();

                loadingPageView.Parent = Xamarin.Forms.Application.Current.MainPage;

                loadingPageView.Layout(new Rectangle(0, 0,
                    Xamarin.Forms.Application.Current.MainPage.Width,
                    Xamarin.Forms.Application.Current.MainPage.Height));

                var renderer = loadingPageView.GetOrCreateRenderer();
                
                _nativeView = renderer.View;

                dialog = new Dialog(CrossCurrentActivity.Current.Activity);
                dialog.RequestWindowFeature((int)WindowFeatures.NoTitle);
                dialog.SetCancelable(false);
                dialog.SetContentView(_nativeView);
                Window window = dialog.Window;
                window.SetLayout(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
                window.ClearFlags(WindowManagerFlags.DimBehind);
                window.SetBackgroundDrawable(new ColorDrawable(Android.Graphics.Color.Transparent));
                
                _isInitialized = true;
            }
            
            dialog.Show();
        }

        private void XamFormsPage_Appearing(object sender, EventArgs e)
        {
            var animation = new Animation(callback: d => ((ContentPage)sender).Content.Rotation = d,
                                          start: ((ContentPage)sender).Content.Rotation,
                                          end: ((ContentPage)sender).Content.Rotation + 360,
                                          easing: Easing.Linear);
            animation.Commit(((ContentPage)sender).Content, "RotationLoopAnimation", 16, 800, null, null, () => true);
        }

        public void HideLoadingPage()
        {
            dialog.Hide();
        }
    }

    internal static class PlatformExtension
    {
        public static IVisualElementRenderer GetOrCreateRenderer(this VisualElement bindable)
        {
            var renderer = XFPlatform.GetRenderer(bindable);
            if (renderer == null)
            {
                renderer = XFPlatform.CreateRendererWithContext(bindable, CrossCurrentActivity.Current.Activity);
                XFPlatform.SetRenderer(bindable, renderer);
            }
            return renderer;
        }
    }
}