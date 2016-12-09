using System;
using System.Collections.Generic;
using System.Text;
using CoreGraphics;
using DemystifyXFNav;
using DemystifyXFNav.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MyThirdPage), typeof(MyThirdPageRenderer))]
namespace DemystifyXFNav.iOS
{
    /// <summary>
    /// Render this page using platform-specific UIKit controls
    /// </summary>
    public class MyThirdPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            var page = e.NewElement as MyThirdPage;

            var hostViewController = ViewController;

            var viewController = new UIViewController();

            var label = new UILabel(new CGRect(50, 40, 320, 40));
            label.Text = "3 " + page.Heading;
            viewController.View.Add(label);

            hostViewController.AddChildViewController(viewController);
            hostViewController.View.Add(viewController.View);

            viewController.DidMoveToParentViewController(hostViewController);
        }
    }
}
