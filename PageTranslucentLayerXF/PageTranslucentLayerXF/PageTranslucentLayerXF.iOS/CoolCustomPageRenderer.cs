using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using PageTranslucentLayerXF;
using PageTranslucentLayerXF.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CoolCustomPage), typeof(CoolCustomPageRenderer))]
namespace PageTranslucentLayerXF.iOS
{
    public class CoolCustomPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                ((CoolCustomPage)e.NewElement).PropertyChanged += OnPropertyChanged;
            }
            if (e.OldElement != null)
            {
                ((CoolCustomPage)e.OldElement).PropertyChanged -= OnPropertyChanged;
            }
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "TranslucentPageBlock")
            {
                //var layer = UIApplication.SharedApplication.KeyWindow;

                //UIImage uiImage = layer.Capture();

                //var splash2 = new UIImageView(uiImage.ApplyDarkEffect());

                ////UIApplication.SharedApplication.KeyWindow.AddSubview(splash2);

                ////UIView.Animate(
                ////  55f,
                ////  0f,
                ////  (UIViewAnimationOptions)UIViewAnimationOptions.TransitionNone,
                ////  (Action)delegate
                ////  {
                ////      splash2.Alpha = 0f;
                ////  },
                ////  (Action)splash2.RemoveFromSuperview);

                //View.AddSubview(splash2);
                //View.BringSubviewToFront(splash2);
            }
        }
    }
}