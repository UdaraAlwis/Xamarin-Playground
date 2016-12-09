using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PageTranslucentLayerXF;
using PageTranslucentLayerXF.iOS;
using Rg.Plugins.Popup.IOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BlurredLayerPage), typeof(BlurredLayerPageRenderer))]
namespace PageTranslucentLayerXF.iOS
{
    public class BlurredLayerPageRenderer : PopupPageRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            
            if (e.NewElement != null)
            {
                var layer = UIApplication.SharedApplication.KeyWindow;

                UIImage uiImage = layer.Capture();

                this.View.BackgroundColor = UIColor.FromPatternImage(uiImage.ApplyDarkEffect());
            }
        }
    }
}