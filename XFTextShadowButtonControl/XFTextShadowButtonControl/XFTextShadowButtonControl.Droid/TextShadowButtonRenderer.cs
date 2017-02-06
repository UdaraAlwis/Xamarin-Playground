using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFTextShadowButtonControl;
using XFTextShadowButtonControl.Droid;

[assembly: ExportRenderer(typeof(TextShadowButton), typeof(TextShadowButtonRenderer))]
namespace XFTextShadowButtonControl.Droid
{
    public class TextShadowButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            var view = (TextShadowButton)Element;
            if (view == null) return;

            // Adding the Button text shadow effect
            Control.SetShadowLayer(4, 0, 2, ((TextShadowButton)Element).TextShadowColor.ToAndroid());
        }
    }
}