using System;
using System.Collections.Generic;
using System.Text;
using CoreAnimation;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFInnerShadowButton;
using XFInnerShadowButton.iOS;

[assembly:ExportRenderer(typeof(ButtonInnerShadow), typeof(ButtonInnerShadowRenderer))]
namespace XFInnerShadowButton.iOS
{
    public class ButtonInnerShadowRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            //CALayer innerShadowOwnerLayer = new CALayer();
            //innerShadowOwnerLayer.Frame = new CGRect(0, Control.Frame.Size.Height + 2, Control.Frame.Width, 2);
            //innerShadowOwnerLayer.BackgroundColor = UIColor.White.CGColor;

            //innerShadowOwnerLayer.ShadowColor = UIColor.Black.CGColor;
            //innerShadowOwnerLayer.ShadowOffset = new CGSize(0, 0);
            //innerShadowOwnerLayer.ShadowRadius = 10.0f;
            //innerShadowOwnerLayer.ShadowOpacity = 0.7f;

            //Control.Layer.AddSublayer(innerShadowOwnerLayer);

            /////////////////////////

            //UIImageView innerShadowOwnerLayer = new UIImageView();

            //innerShadowOwnerLayer.Layer.MasksToBounds = true;
            //innerShadowOwnerLayer.Layer.CornerRadius = 12.0f;
            //innerShadowOwnerLayer.Layer.BorderColor = UIColor.Blue.CGColor;
            //innerShadowOwnerLayer.Layer.BorderWidth = 1.0f;
            //innerShadowOwnerLayer.Layer.ShadowColor = UIColor.Blue.CGColor;
            //innerShadowOwnerLayer.Layer.ShadowOffset = new CGSize(0, 0);
            //innerShadowOwnerLayer.Layer.ShadowOpacity = 1;
            //innerShadowOwnerLayer.Layer.ShadowRadius = 2.0f;

            //Control.Layer.BorderColor = Color.Black.ToCGColor();

            //Control.AddSubview(innerShadowOwnerLayer);

            ///////////////////////////

            

        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            UIImageView innerShadowView = new UIImageView(Control.Bounds);

            innerShadowView.ContentMode = UIViewContentMode.ScaleToFill;
            innerShadowView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

            Control.AddSubview(innerShadowView);

            innerShadowView.Layer.MasksToBounds = true;

            innerShadowView.Layer.BorderColor = UIColor.LightGray.CGColor;
            innerShadowView.Layer.ShadowColor = UIColor.Black.CGColor;
            innerShadowView.Layer.BorderWidth = 1.0f;

            innerShadowView.Layer.ShadowOffset = new CGSize(0, 0);
            innerShadowView.Layer.ShadowOpacity = 1.0f;

            innerShadowView.Layer.ShadowRadius = 1.5f;

            Control.Layer.CornerRadius = 2f;




            //var gradientLayer = new CAGradientLayer();
            //gradientLayer.Frame = Control.Bounds;
            //gradientLayer.Colors = new CGColor[] { UIColor.White.CGColor, UIColor.Black.CGColor };
            //Control.Layer.InsertSublayer(gradientLayer, 0);


            //var gradientLayer2 = new CAGradientLayer();
            //gradientLayer2.Frame = Control.Bounds;
            //gradientLayer2.Colors = new CGColor[] { UIColor.Black.CGColor, UIColor.White.CGColor };
            //Control.Layer.InsertSublayer(gradientLayer2, 0);

        }
    }
}
