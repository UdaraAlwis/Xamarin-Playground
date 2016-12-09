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
using XFImprovedScrollView;
using XFImprovedScrollView.Droid;

[assembly: ExportRenderer(typeof(BloopyScrollView), typeof(BloopyScrollViewRenderer))]
namespace XFImprovedScrollView.Droid
{
    public class BloopyScrollViewRenderer : ScrollViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            this.VerticalScrollBarEnabled = ((BloopyScrollView)e.NewElement).IsVerticalScrollbarEnabled;
            this.HorizontalScrollBarEnabled = ((BloopyScrollView)e.NewElement).IsHorizontalScrollbarEnabled;

            if (((BloopyScrollView)e.NewElement).IsNativeBouncyEffectEnabled)
            {
                this.OverScrollMode = OverScrollMode.Always;
            }

            this.Focusable = false; // Otherwise we children touch events won't work
            this.Clickable = false; // Otherwise we children touch events won't work
        }
    }
}