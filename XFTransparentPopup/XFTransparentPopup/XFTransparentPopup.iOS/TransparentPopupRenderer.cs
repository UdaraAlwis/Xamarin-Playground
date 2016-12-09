using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFTransparentPopup;
using XFTransparentPopup.iOS;


[assembly: ExportRenderer(typeof(TransparentPopup), typeof(TransparentPopupRenderer))]
namespace XFTransparentPopup.iOS
{
    public class TransparentPopupRenderer : PageRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
        }

        public override void DidMoveToParentViewController(UIViewController parent)
        {
            base.DidMoveToParentViewController(parent);

            if (ParentViewController != null)
            {
                // Preparing the view to get the presentation of the parent view for the background
                ParentViewController.ModalPresentationStyle = UIModalPresentationStyle.OverCurrentContext;
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Setting the background color to transparent when the view is appearing
            View.BackgroundColor = UIColor.Clear;
        }
    }
}