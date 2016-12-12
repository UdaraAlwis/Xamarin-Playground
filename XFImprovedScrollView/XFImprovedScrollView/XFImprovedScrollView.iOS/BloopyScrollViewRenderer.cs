using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
        private UIImage _uiImageImageBackground;

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
                    _uiImageImageBackground = await
                        IosImageHelper.GetUIImageFromImageSourceAsync(((BloopyScrollView)e.NewElement).BackgroundImage);
                }

                ((BloopyScrollView)e.NewElement).PropertyChanged += OnPropertyChanged;
            }

            this.UserInteractionEnabled = true; // Otherwise we children touch events won't work

        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == BloopyScrollView.HeightProperty.PropertyName)
            {
                if (((BloopyScrollView)sender).Height > 0)
                {
                    this.BackgroundColor = UIColor.FromPatternImage(
                        MaxResizeImage(_uiImageImageBackground, 
                        (float)((BloopyScrollView)sender).Width,
                        (float)((BloopyScrollView)sender).Height));
                }
            }
        }

        //https://forums.xamarin.com/discussion/comment/175585/#Comment_175585
        // resize the image to be contained within a maximum width and height, keeping aspect ratio
        public UIImage MaxResizeImage(UIImage sourceImage, float maxWidth, float maxHeight)
        {
            var sourceSize = sourceImage.Size;
            var maxResizeFactor = Math.Max(maxWidth / sourceSize.Width, maxHeight / sourceSize.Height);
            if (maxResizeFactor > 1) return sourceImage;
            var width = maxResizeFactor * sourceSize.Width;
            var height = maxResizeFactor * sourceSize.Height;
            UIGraphics.BeginImageContext(new CGSize(width, height));
            sourceImage.Draw(new CGRect(0, 0, width, height));
            var resultImage = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();
            return resultImage;
        }
    }
}