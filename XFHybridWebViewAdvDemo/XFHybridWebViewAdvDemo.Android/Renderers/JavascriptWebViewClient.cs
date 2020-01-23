using Android.Webkit;

namespace XFHybridWebViewAdvDemo.Droid.Renderers
{
    public class JavascriptWebViewClient : WebViewClient
    {
        readonly string _javascript;

        public JavascriptWebViewClient(string javascript)
        {
            _javascript = javascript;
        }

        public override void OnPageFinished(WebView view, string url)
        {
            base.OnPageFinished(view, url);
            view.EvaluateJavascript(_javascript, null);
        }
    }
}