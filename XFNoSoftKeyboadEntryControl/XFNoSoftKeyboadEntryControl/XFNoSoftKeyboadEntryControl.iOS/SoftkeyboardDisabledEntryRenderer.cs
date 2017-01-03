using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFNoSoftKeyboadEntryControl;
using XFNoSoftKeyboadEntryControl.iOS;

[assembly: ExportRenderer(typeof(SoftkeyboardDisabledEntry), typeof(SoftkeyboardDisabledEntryRenderer))]
namespace XFNoSoftKeyboadEntryControl.iOS
{
    public class SoftkeyboardDisabledEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            // Disabling the keyboard
            this.Control.InputView = new UIView();
        }
    }
}