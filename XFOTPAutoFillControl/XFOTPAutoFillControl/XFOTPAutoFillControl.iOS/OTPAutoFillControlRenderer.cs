using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFOTPAutoFillControl;
using XFOTPAutoFillControl.iOS;

[assembly: ExportRenderer(typeof(OTPAutoFillControl), typeof(OTPAutoFillControlRenderer))]
namespace XFOTPAutoFillControl.iOS
{
    public class OTPAutoFillControlRenderer: EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                Control.TextContentType = UITextContentType.OneTimeCode;
            }
        }
    }
}