using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFAwesomeSpinnerView.iOS;
using XFPlatform = Xamarin.Forms.Platform.iOS.Platform;

[assembly: Xamarin.Forms.Dependency(typeof(SpinnerService))]
namespace XFAwesomeSpinnerView.iOS
{
    // useful https://www.google.com.sg/search?q=xamarin.forms+page+to+UIView+convert&oq=xamarin.forms+page+to+UIView+convert&aqs=chrome..69i57.7998j0j4&sourceid=chrome&ie=UTF-8


    public class SpinnerService : ISpinnerService
    {
        private UIView nativeView;

        private bool isInitialized;

        public void OpenSpinner()
        {
            if (!isInitialized)
            {
                var xamFormsPage = new ContentPage()
                {
                    BackgroundColor = new Color(0, 0, 0, 0.5),
                    Content =
                        new StackLayout()
                        {
                            Padding = 30,
                            BackgroundColor = Color.Black,
                            Children =
                            {
                                new Xamarin.Forms.ActivityIndicator()
                                {
                                    IsRunning = true,
                                    Color = Color.White,
                                },
                                new Xamarin.Forms.Label()
                                {
                                    Text = "Loading...",
                                    FontAttributes = FontAttributes.Bold,
                                    TextColor = Color.White,
                                },
                            },
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                        }
                };

                xamFormsPage.Parent = Xamarin.Forms.Application.Current.MainPage;

                xamFormsPage.Layout(new Rectangle(0, 0,
                    Xamarin.Forms.Application.Current.MainPage.Width,
                    Xamarin.Forms.Application.Current.MainPage.Height));

                var renderer = xamFormsPage.GetOrCreateRenderer();

                nativeView = renderer.NativeView;

                //splash1.SizeToFit();
                //splash1.Alpha = 0.7f;

                isInitialized = true;
            }

            UIApplication.SharedApplication.KeyWindow.AddSubview(nativeView);
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
            nativeView.RemoveFromSuperview();
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