using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFHybridWebViewAdvDemo.Controls;
using XFHybridWebViewAdvDemo.Droid.Renderers;

[assembly: ExportRenderer(typeof(HybridWebView), typeof(HybridWebViewRenderer))]
namespace XFHybridWebViewAdvDemo.Droid.Renderers
{
    public class HybridWebViewRenderer : WebViewRenderer
    {
        private const string JavascriptFunction = "function invokeXamarinFormsAction(data){jsBridge.invokeAction(data);}";
        Context _context;

        public HybridWebViewRenderer(Context context) : base(context)
        {
            _context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                Control.RemoveJavascriptInterface("jsBridge");
                ((HybridWebView)Element).Cleanup();
            }
            if (e.NewElement != null)
            {
                Control.SetWebViewClient(new JavascriptWebViewClient($"javascript: {JavascriptFunction}"));
                Control.AddJavascriptInterface(new JsBridge(this), "jsBridge");
                //// No need this since we're loading dynamically generated HTML content
                //Control.LoadUrl($@"file:///android_asset/Content/{((HybridWebView)Element).Uri}");
            }
        }
    }
}