using XFFillInAnswersLayout;
using XFFillInAnswersLayout.iOS;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(PlainEntry), typeof(PlainEntryRenderer))]
namespace XFFillInAnswersLayout.iOS
{
    public class PlainEntryRenderer : EntryRenderer
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