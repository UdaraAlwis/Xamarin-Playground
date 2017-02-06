using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFTextShadowButtonControl;
using XFTextShadowButtonControl.iOS;

[assembly: ExportRenderer(typeof(TextShadowButton), typeof(TextShadowButtonRenderer))]
namespace XFTextShadowButtonControl.iOS
{
    public class TextShadowButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            var view = (TextShadowButton) Element;
            if (view == null) return;
            
            // Adding the Button text shadow effect
            Control.TitleLabel.ShadowOffset = new CGSize(0, 0.25);
            Control.SetTitleShadowColor(((TextShadowButton)Element).TextShadowColor.ToUIColor(), UIControlState.Normal);
        }
    }
}