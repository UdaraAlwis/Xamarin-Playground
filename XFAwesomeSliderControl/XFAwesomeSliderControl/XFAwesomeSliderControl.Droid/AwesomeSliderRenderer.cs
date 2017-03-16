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
                //// Set custom drawable resource
                //Control.SetProgressDrawableTiled(Resources.GetDrawable(Resource.Drawable.custom_progressbar_style, (this.Context).Theme));


                //// Hide thumb
                //Control.SetThumb(new ColorDrawable(Color.Transparent));



                // Set Progress bar Thumb color
                //Control.Thumb.SetColorFilter(Xamarin.Forms.Color.FromHex("#d0a436").ToAndroid(), PorterDuff.Mode.SrcIn);



                //// progressbar and progressbar background color
                //Control.ProgressDrawable.SetColorFilter(
                //    new PorterDuffColorFilter(
                //    Xamarin.Forms.Color.FromHex("#ff0066").ToAndroid(),
                //    PorterDuff.Mode.SrcIn));



                ////Different colors for ProgressBar components
                //// Set Progress bar color
                //Control.ProgressTintList = ColorStateList.ValueOf(Color.Red);
                //Control.ProgressTintMode = PorterDuff.Mode.SrcIn;

                //Set Seconday Progress bar color
                Control.SecondaryProgressTintList = ColorStateList.ValueOf(Color.DarkGray);
                Control.SecondaryProgressTintMode = PorterDuff.Mode.SrcIn;

                // secondary progress value in Xamarin Forms units
                int secondaryProgressValue = 50;
                
                // secondary progress value in Android native Seekbar units
                int secondaryProgressValueInAndroidUnits =
                (int)((secondaryProgressValue - ((AwesomeSlider)Element).Minimum) /
                (((AwesomeSlider)Element).Maximum - ((AwesomeSlider)Element).Minimum) * 1000.0);

                // set the secondary progress value
                Control.SecondaryProgress = secondaryProgressValueInAndroidUnits;

                //// Set Background Progress bar color
                //Control.ProgressBackgroundTintList = ColorStateList.ValueOf(Color.Silver);
                //Control.ProgressBackgroundTintMode = PorterDuff.Mode.SrcIn;

                //// try this out : https://github.com/Redth/FlatUI.Xamarin.Android/blob/master/FlatUI/FlatSeekBar.cs

                // for a floating progress bubble
                //https://github.com/thinkSky1206/SeekBarHint/blob/master/library/src/main/java/com/liuwp/seekbarhint/SeekBarHint.java  

            }
        }
    }
}