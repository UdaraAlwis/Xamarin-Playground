using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UIKit;
using XFForcefulKeyboardDismiss.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(IosForceKeyboardDismissalService))]
namespace XFForcefulKeyboardDismiss.iOS
{
    public class IosForceKeyboardDismissalService : IForceKeyboardDismissalService
    {
        public void DismissKeyboard()
        {
            UIApplication.SharedApplication.InvokeOnMainThread(() =>
            {
                var window = UIApplication.SharedApplication.KeyWindow;
                var vc = window.RootViewController;
                while (vc.PresentedViewController != null)
                {
                    vc = vc.PresentedViewController;
                }

                vc.View.EndEditing(true);
            });

        }
    }
}