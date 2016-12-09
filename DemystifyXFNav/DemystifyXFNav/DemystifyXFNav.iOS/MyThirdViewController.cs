using System;
using System.Drawing;
using CoreGraphics;
using Foundation;
using UIKit;

namespace DemystifyXFNav.iOS
{
    [Register("UniversalView")]
    public class UniversalView : UIView
    {
        public UniversalView()
        {
            Initialize();
        }

        public UniversalView(RectangleF bounds) : base(bounds)
        {
            Initialize();
        }

        void Initialize()
        {
            BackgroundColor = UIColor.Red;
        }
    }

    public partial class MyThirdViewController : UIViewController
    {
        public MyThirdViewController() : base("MyThirdViewController", null)
        {
            View = new UniversalView();
            

            UILabel uiLabel = new UILabel(new CGRect(15, 70, 380, 74));
            uiLabel.TextAlignment = UITextAlignment.Center;
            uiLabel.Font = UIFont.SystemFontOfSize(23);
            uiLabel.LineBreakMode = UILineBreakMode.WordWrap;
            uiLabel.Lines = 0;
            uiLabel.Text = "behold the Poup View Page!";
            View.AddSubview(uiLabel);

            var playButton = UIButton.FromType(UIButtonType.RoundedRect);
            playButton.Frame = new CGRect(10, 380, View.Bounds.Width - 20, 44);
            playButton.SetTitle("Close this!", UIControlState.Normal);
            playButton.BackgroundColor = UIColor.White;
            playButton.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
            playButton.TouchUpInside += delegate
            {
                this.DismissModalViewController(true);
            };
            View.AddSubview(playButton);

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            UIView.Animate(
            0.25f,
            0f,
            (UIViewAnimationOptions)UIViewAnimationOptions.CurveEaseIn,
            (Action)delegate
            {
                View.BackgroundColor = new UIColor(0, 0, 0, 0.4f);
            },
            null);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            View.BackgroundColor = UIColor.Clear;
        }
    }
}