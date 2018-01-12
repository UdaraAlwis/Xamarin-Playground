using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFAwesomeSpinnerView.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(SpinnerService))]
namespace XFAwesomeSpinnerView.iOS
{
    // useful https://www.google.com.sg/search?q=xamarin.forms+page+to+UIView+convert&oq=xamarin.forms+page+to+UIView+convert&aqs=chrome..69i57.7998j0j4&sourceid=chrome&ie=UTF-8


    public class SpinnerService : ISpinnerService
    {
        private UIView splash1;

        private bool isInitialized;

        public void OpenSpinner()
        {
            if (!isInitialized)
            {
                var xamFormsPage = new Grid()
                {
                    Opacity = 0.7,
                    Children =
                    {
                        new Xamarin.Forms.ActivityIndicator(){ IsRunning = true, },
                    },
                    BackgroundColor = Color.DeepSkyBlue,
                };

                splash1 = ConvertFormsToNative(xamFormsPage, UIScreen.MainScreen.Bounds);
                
                //splash1.SizeToFit();
                //splash1.Alpha = 0.7f;
                
                isInitialized = true;
            }

            UIApplication.SharedApplication.KeyWindow.AddSubview(splash1);
        }

        // Credits: https://michaelridland.com/xamarin/creating-native-view-xamarin-forms-viewpage/
        public static UIView ConvertFormsToNative(Xamarin.Forms.View view, CGRect size)
        {
            var renderer = Platform.CreateRenderer(view);

            //var renderer = RendererFactory.GetRenderer(view);

            renderer.NativeView.Frame = size;

            renderer.NativeView.AutoresizingMask = UIViewAutoresizing.All;
            renderer.NativeView.ContentMode = UIViewContentMode.ScaleToFill;

            renderer.Element.Layout(size.ToRectangle());

            var nativeView = renderer.NativeView;

            nativeView.SetNeedsLayout();

            return nativeView;
        }

        public void CloseSpinner()
        {
            splash1.RemoveFromSuperview();
        }
    }
}