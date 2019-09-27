using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App2;
using App2.iOS;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace App2.iOS
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
                return;
            }

            Control.LeftView = new UIView(new CGRect(0, 0, 0, 0));
            Control.LeftViewMode = UITextFieldViewMode.Never;
            Control.RightView = new UIView(new CGRect(0, 0, 0, 0));
            Control.RightViewMode = UITextFieldViewMode.Never;
            Control.BorderStyle = UITextBorderStyle.None;
        }
    }
}