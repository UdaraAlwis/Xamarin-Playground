using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFImprovedScrollView;
using XFImprovedScrollView.iOS;

[assembly: ExportRenderer(typeof(BloopyScrollView), typeof(BloopyScrollViewRenderer))]
namespace XFImprovedScrollView.iOS
{
    class BloopyScrollViewRenderer : ScrollViewRenderer
    {
        protected override async void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            this.ShowsVerticalScrollIndicator = !((BloopyScrollView)e.NewElement).IsVerticalScrollbarEnabled;
            this.ShowsHorizontalScrollIndicator = !((BloopyScrollView)e.NewElement).IsHorizontalScrollbarEnabled;

            if (e.NewElement != null)
            {
                if (((BloopyScrollView)e.NewElement).IsNativeBouncyEffectEnabled)
                {
                    this.Bounces = true;
                    this.AlwaysBounceVertical = true;
                }

                if (((BloopyScrollView)e.NewElement).BackgroundImage != null)
                {
                    //var uiImageBackground = await
                    //    IosImageHelpers.GetUIImageAsync(((BloopyScrollView)e.NewElement).BackgroundImage);

                    //// Scaling down the image hence Forms9Patch scales up the image for @2x
                    //uiImageBackground = new UIImage(uiImageBackground.CGImage, 2, uiImageBackground.Orientation);

                    //UIImageView scrollViewBackgroundImageView = new UIImageView(uiImageBackground.
                    //    CreateResizableImage(new UIEdgeInsets(200f, 0f, 0f, 0f), UIImageResizingMode.Stretch));

                    //CGRect rectForbackgroundImageView = new CGRect(
                    //    0, 30,
                    //    this.ContentSize.Width,
                    //    this.ContentSize.Height + 150);

                    //scrollViewBackgroundImageView.Frame = rectForbackgroundImageView;

                    //this.AddSubview(scrollViewBackgroundImageView);
                    //this.SendSubviewToBack(scrollViewBackgroundImageView);
                }
            }

            this.UserInteractionEnabled = true; // Otherwise we children touch events won't work

        }
    }
}