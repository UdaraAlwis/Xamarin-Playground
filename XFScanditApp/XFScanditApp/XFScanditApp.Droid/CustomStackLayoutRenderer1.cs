using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ScanditBarcodePicker.Android;
using ScanditBarcodePicker.Android.Recognition;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFScanditApp;
using XFScanditApp.Droid;
using View = Android.Views.View;

//[assembly: ExportRenderer(typeof(CustomStackLayout), typeof(CustomStackLayoutRenderer))]
namespace XFScanditApp.Droid
{
    //public class CustomStackLayoutRenderer : ViewRenderer<CustomStackLayout, View>, IOnScanListener, IDialogInterfaceOnCancelListener
    //{
    //    private BarcodePicker picker;
    //public static string appKey = "<--your ScandIt key-->";

    //    protected override void OnElementChanged(ElementChangedEventArgs<CustomStackLayout> e)
    //    {
    //        base.OnElementChanged(e);

    //        //var test = this as ViewGroup;

    //        if (e.NewElement != null)
    //        {

    //            var activity = this.Context as Activity;
    //            //var view = activity.LayoutInflater.Inflate(Resource.Layout.CameraLayout, this, false);


    //            // Set the app key before instantiating the picker.
    //            ScanditLicense.AppKey = appKey;

    //            // The scanning behavior of the barcode picker is configured through scan
    //            // settings. We start with empty scan settings and enable a very generous
    //            // set of symbologies. In your own apps, only enable the symbologies you
    //            // actually need.
    //            ScanSettings settings = ScanSettings.Create();
    //            int[] symbologiesToEnable = new int[]
    //            {
    //                Barcode.SymbologyEan13,
    //                Barcode.SymbologyEan8,
    //                Barcode.SymbologyUpca,
    //                Barcode.SymbologyDataMatrix,
    //                Barcode.SymbologyQr,
    //                Barcode.SymbologyCode39,
    //                Barcode.SymbologyCode128,
    //                Barcode.SymbologyInterleaved2Of5,
    //                Barcode.SymbologyUpce
    //            };

    //            for (int sym = 0; sym < symbologiesToEnable.Length; sym++)
    //            {
    //                settings.SetSymbologyEnabled(symbologiesToEnable[sym], true);
    //            }

    //            // Some 1d barcode symbologies allow you to encode variable-length data. By default, the
    //            // Scandit BarcodeScanner SDK only scans barcodes in a certain length range. If your
    //            // application requires scanning of one of these symbologies, and the length is falling
    //            // outside the default range, you may need to adjust the "active symbol counts" for this
    //            // symbology. This is shown in the following few lines of code.

    //            SymbologySettings symSettings = settings.GetSymbologySettings(Barcode.SymbologyCode128);
    //            short[] activeSymbolCounts = new short[]
    //            {
    //                7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20
    //            };
    //            symSettings.SetActiveSymbolCounts(activeSymbolCounts);
    //            // For details on defaults and how to calculate the symbol counts for each symbology, take
    //            // a look at http://docs.scandit.com/stable/c_api/symbologies.html.

    //            picker = new BarcodePicker(Forms.Context, settings);

    //            // Set listener for the scan event.
    //            picker.SetOnScanListener(this);

    //            //picker.LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);

    //            // Show the scan user interface
    //            //SetContentView(picker);

    //            //test = (picker);

    //            picker.StartScanning(false);

    //            picker.Scan += (sender, args) =>
    //            {

    //            };

    //            AddView(picker);

    //            //SetNativeControl(picker);
    //        }
    //    }

    //    protected override void OnLayout(bool changed, int l, int t, int r, int b)
    //    {
    //        base.OnLayout(changed, l, t, r, b);

    //        var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
    //        var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);


    //        picker.Measure(msw, msh);
    //        picker.Layout(0, 0, r - l, b - t);
    //    }

    //    public void DidScan(IScanSession session)
    //    {
    //        if (session.NewlyRecognizedCodes.Count > 0)
    //        {
    //            Barcode code = session.NewlyRecognizedCodes[0];
    //            Console.WriteLine("barcode scanned: {0}, '{1}'", code.SymbologyName, code.Data);

    //            // Call GC.Collect() before stopping the scanner as the garbage collector for some reason does not 
    //            // collect objects without references asap but waits for a long time until finally collecting them.
    //            GC.Collect();

    //            // Stop the scanner directly on the session.
    //            session.StopScanning();

    //            // If you want to edit something in the view hierarchy make sure to run it on the UI thread.
    //            ((Activity)this.Context).RunOnUiThread(() =>
    //            {
    //                AlertDialog alert = new AlertDialog.Builder((Activity)this.Context)
    //                    .SetTitle(code.SymbologyName + " Barcode Detected")
    //                    .SetMessage(code.Data)
    //                    .SetPositiveButton("OK", delegate
    //                    {
    //                        picker.StartScanning();
    //                    })
    //                    .SetOnCancelListener(this)
    //                    .Create();

    //                alert.Show();
    //            });
    //        }
    //    }

    //    public void OnCancel(IDialogInterface dialog)
    //    {
    //        picker.StartScanning();
    //    }


    //}
}