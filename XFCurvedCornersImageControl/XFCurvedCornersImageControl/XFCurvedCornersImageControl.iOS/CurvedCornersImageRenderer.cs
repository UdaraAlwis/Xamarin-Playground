using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using CoreGraphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFCurvedCornersImageControl;
using XFCurvedCornersImageControl.iOS;

[assembly: ExportRenderer(typeof(CurvedCornersImage), typeof(CurvedCornersImageRenderer))]
namespace XFCurvedCornersImageControl.iOS
{
    public class CurvedCornersImageRenderer : ImageRenderer
    {
        // Special Thanks to @jamesmontemagno for 
        // his example on Circular Image control : https://gist.github.com/jamesmontemagno/36a25351625ab7e2838e
        // which tipped me off the idea of how to implement my scenario
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == VisualElement.HeightProperty.PropertyName ||
                e.PropertyName == VisualElement.WidthProperty.PropertyName)
            {
                try
                {
                    double min = Math.Min(Element.Width, Element.Height);
                    Control.Layer.CornerRadius = 8;
                    Control.Layer.MasksToBounds = false;
                    Control.ClipsToBounds = true;
                }
                catch (Exception ex)
                {
                    // ignored
                }
            }
        }
    }
}
