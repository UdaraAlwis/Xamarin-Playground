using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFLoadingPageService.iOS;
using XFPlatform = Xamarin.Forms.Platform.iOS.Platform;

[assembly: Xamarin.Forms.Dependency(typeof(LodingPageServiceiOS))]
namespace XFLoadingPageService.iOS
{
    public class LodingPageServiceiOS : ILodingPageService
    {
        private UIView _nativeView;

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

                _nativeView = renderer.NativeView;

                _isInitialized = true;
            }

            UIApplication.SharedApplication.KeyWindow.AddSubview(_nativeView);
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
            _nativeView.RemoveFromSuperview();
        }
    }

    internal static class PlatformExtension
    {
        public static IVisualElementRenderer GetOrCreateRenderer(this VisualElement bindable)
        {
            var renderer = XFPlatform.GetRenderer(bindable);
            if (renderer == null)
            {
                renderer = XFPlatform.CreateRenderer(bindable);
                XFPlatform.SetRenderer(bindable, renderer);
            }
            return renderer;
        }
    }
}