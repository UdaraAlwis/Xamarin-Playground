using System;
using Android.Webkit;
using Java.Interop;
using XFHybridWebViewAdvDemo.Controls;

namespace XFHybridWebViewAdvDemo.Droid.Renderers
{
    public class JsBridge : Java.Lang.Object
    {
        readonly WeakReference<HybridWebViewRenderer> HybridWebViewMainRenderer;

        public JsBridge(HybridWebViewRenderer hybridRenderer)
        {
            HybridWebViewMainRenderer = new WeakReference<HybridWebViewRenderer>(hybridRenderer);
        }

        [JavascriptInterface]
        [Export("invokeAction")]
        public void InvokeAction(string data)
        {
            if (HybridWebViewMainRenderer != null && HybridWebViewMainRenderer.TryGetTarget(out var hybridRenderer))
            {
                var dataBody = data;
                if (dataBody.Contains("|"))
                {
                    var dataArray = dataBody.Split("|");
                    var data1 = dataArray[0];
                    var data2 = dataArray[1];
                    ((HybridWebView)hybridRenderer.Element).InvokeAction(data1, data2);
                }
                else
                {
                    ((HybridWebView)hybridRenderer.Element).InvokeAction(dataBody, null);
                }
            }
        }
    }
}