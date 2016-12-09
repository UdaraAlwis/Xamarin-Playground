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

[assembly: ExportRenderer(typeof(CoolImage), typeof(CoolImageRenderer))]
namespace PageTranslucentLayerXF.iOS
{
    public class CoolImageRenderer : ImageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                ((CoolImage)e.NewElement).PropertyChanged += OnPropertyChanged;
            }
            if (e.OldElement != null)
            {
                ((CoolImage)e.OldElement).PropertyChanged -= OnPropertyChanged;
            }
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "IsVisible")
            {
                if (((CoolImage)Element).IsVisible)
                {
                    ((CoolImage) Element).Opacity = 0;

                    var layer = UIApplication.SharedApplication.KeyWindow;

                    UIImage uiImage = layer.Capture();

                    Control.Image = uiImage.ApplyDarkEffect();
                
                    ((CoolImage)Element).FadeTo(1, 500);
                }
                else
                {
                    Control.Image = null;
                }
            }
        }
    }
}