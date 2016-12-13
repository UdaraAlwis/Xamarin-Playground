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
    public class BloopyScrollViewRenderer : ScrollViewRenderer
    {
        private UIImage _uiImageImageBackground;

        protected override async void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            this.ShowsVerticalScrollIndicator = ((BloopyScrollView)e.NewElement).IsVerticalScrollbarEnabled;
            this.ShowsHorizontalScrollIndicator = ((BloopyScrollView)e.NewElement).IsHorizontalScrollbarEnabled;

            if (e.NewElement != null)
            {
                if (((BloopyScrollView)e.NewElement).IsNativeBouncyEffectEnabled)
                {
                    this.Bounces = true;
                    this.AlwaysBounceVertical = true;
                }

                if (((BloopyScrollView)e.NewElement).BackgroundImage != null)
                {
                    // retrieving the UIImage Image from the ImageSource by converting
                    _uiImageImageBackground = await
                        IosImageHelper.GetUIImageFromImageSourceAsync(((BloopyScrollView)e.NewElement).BackgroundImage);
                }

                ((BloopyScrollView)e.NewElement).PropertyChanged += OnPropertyChanged;
            }
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == BloopyScrollView.HeightProperty.PropertyName)
            {
                // check if the Width and Height are assigned
                if (((BloopyScrollView)sender).Width > 0 & ((BloopyScrollView)sender).Height > 0)
                {
                    // resize the UIImage to fit the current UIScrollView's width and height
                    _uiImageImageBackground = ResizeUIImage(_uiImageImageBackground, (float)((BloopyScrollView)sender).Width, (float)((BloopyScrollView)sender).Height);

                    // Set the background Image
                    this.BackgroundColor = UIColor.FromPatternImage(_uiImageImageBackground);
                }
            }
        }

        // We need to override this to have the background image to be fixed
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
        }

        // Resize the UIImage
        public UIImage ResizeUIImage(UIImage sourceImage, float widthToScale, float heightToScale)
        {
            var sourceSize = sourceImage.Size;
            var maxResizeFactor = Math.Max(widthToScale / sourceSize.Width, heightToScale / sourceSize.Height);
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