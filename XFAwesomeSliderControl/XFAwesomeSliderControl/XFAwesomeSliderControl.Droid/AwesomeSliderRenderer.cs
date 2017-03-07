using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFAwesomeSliderControl.Droid;
using XFAwesomeSliderControl;
using Android.Graphics;
using Android.Graphics.Drawables;
using Color = Android.Graphics.Color;

[assembly:ExportRenderer(typeof(AwesomeSlider), typeof(AwesomeSliderRenderer))]
namespace XFAwesomeSliderControl.Droid
{
    public class AwesomeSliderRenderer : SliderRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                // Set custom drawable resource
                Control.SetProgressDrawableTiled(Resources.GetDrawable(Resource.Drawable.custom_progressbar_style, (this.Context).Theme));

                //// Hide thumb
                //Control.SetThumb(new ColorDrawable(Color.Transparent));

                //// progressbar and progressbar background color
                //Control.ProgressDrawable.SetColorFilter(
                //    new PorterDuffColorFilter(
                //    Xamarin.Forms.Color.FromHex("#ff0066").ToAndroid(),
                //    PorterDuff.Mode.SrcIn));
            }
        }
    }
}