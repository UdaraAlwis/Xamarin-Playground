using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using XFTransparentPopup;
using XFTransparentPopup.Droid;

[assembly: ExportRenderer(typeof(TransparentPopup), typeof(TransparentPopupRenderer))]
namespace XFTransparentPopup.Droid
{
    public class TransparentPopupRenderer : PageRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }
    }
}