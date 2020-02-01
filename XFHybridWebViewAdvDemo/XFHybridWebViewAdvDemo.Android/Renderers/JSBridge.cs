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
                    var paramArray = dataBody.Split("|");
                    var param1 = paramArray[0];
                    var param2 = paramArray[1];
                    ((HybridWebView)hybridRenderer.Element).InvokeAction(param1, param2);
                }
                else
                {
                    ((HybridWebView)hybridRenderer.Element).InvokeAction(dataBody, null);
                }
            }
        }
    }
}