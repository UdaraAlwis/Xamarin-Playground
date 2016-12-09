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

using CustomRenderersDemo;
using CustomRenderersDemo.Droid;

using Xamarin.Forms;

[assembly: ExportRenderer(typeof(RoundCornersButton), typeof(RoundCornersButtonRenderer))]
namespace CustomRenderersDemo.Droid
{
    using Android.Graphics.Drawables;

    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    public class RoundCornersButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                // Subscribe for events
            }
            else if (e.OldElement != null)
            {
                // Unsubscribe from events
            }

            if (Control != null)
            {
                GradientDrawable gradientDrawable = new GradientDrawable();
                gradientDrawable.SetShape(ShapeType.Rectangle);
                gradientDrawable.SetColor(Element.BackgroundColor.ToAndroid());
                gradientDrawable.SetStroke(4, Element.BorderColor.ToAndroid());
                gradientDrawable.SetCornerRadius(38.0f);

                Control.SetBackground(gradientDrawable);
            }
        }
    }
}