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
using XFEntryWithCurvedCorners;
using XFEntryWithCurvedCorners.Droid;

[assembly: ExportRenderer(typeof(EntryWithCurvedCorners), typeof(EntryWithCurvedCornersRenderer))]
namespace XFEntryWithCurvedCorners.Droid
{
    public class EntryWithCurvedCornersRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var view = (EntryWithCurvedCorners)Element;

                if (view.IsCurvedCornersEnabled)
                {
                    // creating gradient drawable for the curved background
                    var _gradientBackground = new GradientDrawable();
                    _gradientBackground.SetShape(ShapeType.Rectangle);
                    _gradientBackground.SetColor(view.BackgroundColor.ToAndroid());

                    // Thickness of the stroke line
                    _gradientBackground.SetStroke(view.BorderWidth, view.BorderColor.ToAndroid());

                    // Radius for the curves
                    _gradientBackground.SetCornerRadius(
                        AndroidHelpers.DpToPixels(this.Context,
                            Convert.ToSingle(view.CornerRadius)));

                    // set the background of the label
                    Control.SetBackground(_gradientBackground);
                }

                // Set padding for the internal text from border
                Control.SetPadding(
                       (int)AndroidHelpers.DpToPixels(this.Context, Convert.ToSingle(12)),
                        Control.PaddingTop,
                       (int)AndroidHelpers.DpToPixels(this.Context, Convert.ToSingle(12)),
                       Control.PaddingBottom);
            }
        }
    }
}