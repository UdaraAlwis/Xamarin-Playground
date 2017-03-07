using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFAwesomeSliderControl.Droid;
using XFAwesomeSliderControl;
using Android.Graphics;

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
                this.Control.Thumb.SetColorFilter(Android.Graphics.Color.Red, PorterDuff.Mode.SrcIn);
            }
        }
    }
}