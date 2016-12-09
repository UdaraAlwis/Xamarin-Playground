using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using ScanditSDK;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFScanditApp;
using XFScanditApp.iOS;

[assembly: ExportRenderer(typeof(CustomStackLayout), typeof(CustomStackLayoutRenderer))]
namespace XFScanditApp.iOS
{
    public class CustomStackLayoutRenderer : ViewRenderer<CustomStackLayout, UIView>
    {
        private SIBarcodePicker _picker;
        public static string appKey = "<--your ScandIt key-->";

        /// <summary>
        /// View finder width
        /// </summary>
        private const float ViewFinderWidth = 215f;

        protected override void OnElementChanged(ElementChangedEventArgs<CustomStackLayout> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                
            }
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            _picker = new SIBarcodePicker(appKey);

            _picker.OverlayController.DidScanBarcode += OverlayControllerOnDidScanBarcode;

            _picker.OverlayController.SetTorchEnabled(false);
            _picker.OverlayController.SetLogoOffset(60, -10, 60, -10);
            _picker.OverlayController.SetViewfinderSize(0.8f, 1.1f, 0.8f, 1.1f);
            _picker.OverlayController.DrawViewfinder(false);

            _picker.Size = new SizeF(
                (float)this.Bounds.Width,
                (float)this.Bounds.Height);
            _picker.View.Frame = this.Bounds;

            // custom view finder
            var viewFinderHeight = this.Bounds.Height - 20f;
            var viewFinder = new UIView(new CGRect(
                this.Bounds.Width / 2 - ViewFinderWidth / 2,
                this.Bounds.Height / 2 - viewFinderHeight / 2,
                ViewFinderWidth,
                viewFinderHeight))
            { BackgroundColor = UIColor.Clear };
            viewFinder.Layer.BorderColor = UIColor.White.CGColor;
            viewFinder.Layer.BorderWidth = 2f;
            viewFinder.Layer.CornerRadius = 10f;
            viewFinder.Layer.MasksToBounds = true;
            _picker.OverlayController.Add(viewFinder);

            Add(_picker.View);

        }

        private void OverlayControllerOnDidScanBarcode(object sender, SIOverlayControllerDidScanEventArgs siOverlayControllerDidScanEventArgs)
        {
        }
        
    }
}