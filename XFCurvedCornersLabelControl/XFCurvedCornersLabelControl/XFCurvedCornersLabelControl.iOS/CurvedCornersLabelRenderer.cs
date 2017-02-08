using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFCurvedCornersLabelControl;
using XFCurvedCornersLabelControl.iOS;

[assembly: ExportRenderer(typeof(CurvedCornersLabel), typeof(CurvedCornersLabelRenderer))]
namespace XFCurvedCornersLabelControl.iOS
{ 
    public class CurvedCornersLabelRenderer : ViewRenderer<CurvedCornersLabel, UIView>
    {
        private UILabel _nativeUiLabel;

        private CurvedCornersLabel _xfViewReference;

        protected override void OnElementChanged(ElementChangedEventArgs<CurvedCornersLabel> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                _xfViewReference = (CurvedCornersLabel)Element;

                // Creating the UILabel from the XF Properties
                _nativeUiLabel = new UILabel(new CGRect(0, 0, 0, 0));
                _nativeUiLabel.Text = _xfViewReference.Text;
                _nativeUiLabel.TextColor = _xfViewReference.TextColor.ToUIColor();
                
                _nativeUiLabel.Font = _nativeUiLabel.Font.WithSize((float)_xfViewReference.FontSize);
                
                switch (_xfViewReference.HorizontalTextAlignment)
                {
                    case TextAlignment.Center:
                        _nativeUiLabel.TextAlignment = UITextAlignment.Center;
                        break;
                    case TextAlignment.Start:
                        _nativeUiLabel.TextAlignment = UITextAlignment.Left;
                        break;
                    case TextAlignment.End:
                        _nativeUiLabel.TextAlignment = UITextAlignment.Right;
                        break;
                }

                // adding the UILabel to the UIView
                this.AddSubview(_nativeUiLabel);

                this.Layer.CornerRadius = (float)_xfViewReference.CurvedCornerRadius;
                this.Layer.BackgroundColor = _xfViewReference.CurvedBackgroundColor.ToCGColor();
            }
        }
        
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            // now let's resize the UILabel to the actual renderered size of UIView
            _nativeUiLabel.Frame = new CGRect(0, 0, rect.Width, rect.Height);
        }
    }
}