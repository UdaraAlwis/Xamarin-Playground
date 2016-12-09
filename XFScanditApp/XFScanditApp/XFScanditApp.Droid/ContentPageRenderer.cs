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
using ScanditBarcodePicker.Android;
using ScanditBarcodePicker.Android.Recognition;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFScanditApp;
using XFScanditApp.Droid;

[assembly: ExportRenderer(typeof(CustomContentPage), typeof(CustomContentPageRenderer))]
namespace XFScanditApp.Droid
{
    public class CustomContentPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
        }
    }
}