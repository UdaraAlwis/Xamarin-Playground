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
using XFCurvedCornersLabelControl;
using XFCurvedCornersLabelControl.Droid;

[assembly: ExportRenderer(typeof(CurvedCornersLabel), typeof(CurvedCornersLabelRenderer))]
namespace XFCurvedCornersLabelControl.Droid
{
    public class CurvedCornersLabelRenderer : LabelRenderer
    {
        private GradientDrawable _gradientBackground;

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var view = (CurvedCornersLabel)Element;
            if (view == null) return;

            // creating gradient drawable for the curved background
            _gradientBackground = new GradientDrawable();
            _gradientBackground.SetShape(ShapeType.Rectangle);
            _gradientBackground.SetColor(view.CurvedBackgroundColor.ToAndroid());
            
            // Thickness of the stroke line
            _gradientBackground.SetStroke(4, view.CurvedBackgroundColor.ToAndroid());
            
            // Radius for the curves
            _gradientBackground.SetCornerRadius((float)view.CurvedCornerRadius);

            // set the background of the label
            Control.SetBackground(_gradientBackground);
        }
    }
}