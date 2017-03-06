using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;

using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFEntryWithCurvedCorners;
using XFEntryWithCurvedCorners.iOS;

[assembly: ExportRenderer(typeof(EntryWithCurvedCorners), typeof(EntryWithCurvedCornersRenderer))]
namespace XFEntryWithCurvedCorners.iOS
{
    public class EntryWithCurvedCornersRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var view = (EntryWithCurvedCorners)Element;

                Control.LeftView = new UIView(new CGRect(0f, 0f, 9f, 20f));
                Control.LeftViewMode = UITextFieldViewMode.Always;

                Control.KeyboardAppearance = UIKeyboardAppearance.Dark;
                Control.ReturnKeyType = UIReturnKeyType.Done;

                Control.Layer.CornerRadius = Convert.ToSingle(view.CornerRadius);
                Control.Layer.BorderColor = view.BorderColor.ToCGColor();
                Control.Layer.BorderWidth = view.BorderWidth;
                Control.ClipsToBounds = true;
            }
        }
    }
}