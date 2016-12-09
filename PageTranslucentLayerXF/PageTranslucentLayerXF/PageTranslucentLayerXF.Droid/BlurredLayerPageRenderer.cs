using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Renderscripts;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PageTranslucentLayerXF;
using PageTranslucentLayerXF.Droid;
using Rg.Plugins.Popup.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BlurredLayerPage), typeof(BlurredLayerPageRenderer))]
namespace PageTranslucentLayerXF.Droid
{
    public class BlurredLayerPageRenderer : PopupPageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {

                var view = ((Activity) Context).Window.DecorView;

                //Capturing the screenshot of the current activity before moving to next
                Bitmap bitmap = Bitmap.CreateBitmap(view.Width,
                    view.Height, Bitmap.Config.Argb8888);
                Canvas canvas = new Canvas(bitmap);
                view.Draw(canvas);

                // Blurring the screenshot image
                Bitmap _previousPageScreenshot = CreateBlurredImage(25, bitmap, this.Context);
                this.Background = new BitmapDrawable(_previousPageScreenshot);
            }
        }


        public static Bitmap CreateBlurredImage(int radius, Bitmap bitmap, Context context)
        {
            // Load a clean bitmap and work from that.
            Bitmap originalBitmap = bitmap;

            // Create another bitmap that will hold the results of the filter.
            Bitmap blurredBitmap;
            blurredBitmap = Bitmap.CreateBitmap(originalBitmap);

            // Create the Renderscript instance that will do the work.
            RenderScript rs = RenderScript.Create(context);

            // Allocate memory for Renderscript to work with
            Allocation input = Allocation.CreateFromBitmap(rs, originalBitmap, Allocation.MipmapControl.MipmapFull, AllocationUsage.Script);
            Allocation output = Allocation.CreateTyped(rs, input.Type);

            // Load up an instance of the specific script that we want to use.
            ScriptIntrinsicBlur script = ScriptIntrinsicBlur.Create(rs, Android.Renderscripts.Element.U8_4(rs));
            script.SetInput(input);

            // Set the blur radius
            script.SetRadius(radius);

            // Start the ScriptIntrinisicBlur
            script.ForEach(output);

            // Copy the output to the blurred bitmap
            output.CopyTo(blurredBitmap);

            return blurredBitmap;
        }
    }
}