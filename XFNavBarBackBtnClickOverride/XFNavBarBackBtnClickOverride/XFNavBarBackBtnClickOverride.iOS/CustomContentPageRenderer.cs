using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFNavBarBackBtnClickOverride;
using XFNavBarBackBtnClickOverride.iOS;


[assembly: ExportRenderer(typeof(CoolContentPage), typeof(CoolContentPageRenderer))]
namespace XFNavBarBackBtnClickOverride.iOS
{
    public class CoolContentPageRenderer : PageRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            
            if (((CoolContentPage)Element).EnableBackButtonOverride)
            {
                SetCustomBackButton();
            }
        }

        private void SetCustomBackButton()
        {
            var backBtnImage = UIImage.FromBundle("iosbackarrow.png");

            backBtnImage = backBtnImage.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);

            var backBtn = new UIButton(UIButtonType.Custom)
            {
                HorizontalAlignment = UIControlContentHorizontalAlignment.Left,
                TitleEdgeInsets = new UIEdgeInsets(11.5f, 15f, 10f, 0f),
                ImageEdgeInsets = new UIEdgeInsets(1f, 8f, 0f, 0f)
            };

            backBtn.SetTitle("Back", UIControlState.Normal);
            backBtn.SetTitleColor(UIColor.FromRGB(0, 129, 249), UIControlState.Normal);
            backBtn.SetTitleColor(UIColor.LightGray, UIControlState.Highlighted);
            backBtn.SetImage(backBtnImage, UIControlState.Normal);
            backBtn.Font = UIFont.FromName("HelveticaNeue", (nfloat)17);
            backBtn.SizeToFit();
            backBtn.TouchDown += (sender, e) =>
            {
                if (((CoolContentPage)Element).CustomBackButtonAction != null)
                {
                    ((CoolContentPage)Element).CustomBackButtonAction. Invoke();
                }
            };
            
            //Set the frame of the button
            backBtn.Frame = new CGRect(
                0,
                0,
                UIScreen.MainScreen.Bounds.Width / 4,
                NavigationController.NavigationBar.Frame.Height);

            var btnContainer = new UIView(new CGRect(0, 0, backBtn.Frame.Width, backBtn.Frame.Height));
            btnContainer.AddSubview(backBtn);

            var fixedSpace = new UIBarButtonItem(UIBarButtonSystemItem.FixedSpace)
            {
                Width = -16f
            };
            var backButtonItem = new UIBarButtonItem("", UIBarButtonItemStyle.Plain, null)
            {
                CustomView = backBtn
            };

            NavigationController.TopViewController.NavigationItem.LeftBarButtonItems = new[] { fixedSpace, backButtonItem };
        }
    }
}