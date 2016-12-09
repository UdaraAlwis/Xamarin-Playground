using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFCurvedCornersImageControl;
using XFCurvedCornersImageControl.Droid;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(CurvedCornersImage), typeof(CurvedCornersImageRenderer))]
namespace XFCurvedCornersImageControl.Droid
{
    public class CurvedCornersImageRenderer : ImageRenderer
    {
        // Special Thanks to @jamesmontemagno for 
        // his example on Circular Image control : https://gist.github.com/jamesmontemagno/36a25351625ab7e2838e
        // which tipped me off the idea of how to implement my scenario
        protected override bool DrawChild(Canvas canvas, global::Android.Views.View child, long drawingTime)
        {
            try
            {
                Rect rect = new Rect(0, 0, this.Width, this.Height);
                RectF rectF = new RectF(rect);
                
                Path path = new Path();
                path.AddRoundRect(rectF, 20, 20, Path.Direction.Ccw);
                canvas.Save();
                canvas.ClipPath(path);

                var result = base.DrawChild(canvas, child, drawingTime);

                canvas.Restore();

                path.Dispose();
                return result;
            }
            catch (Exception ex)
            {
                // ignored
            }

            return base.DrawChild(canvas, child, drawingTime);
        }

    }
}