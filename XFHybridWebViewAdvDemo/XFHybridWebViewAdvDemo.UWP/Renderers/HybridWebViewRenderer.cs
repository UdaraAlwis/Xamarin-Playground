using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms.Platform.UWP;
using XFHybridWebViewAdvDemo.Controls;
using XFHybridWebViewAdvDemo.UWP.Renderers;

[assembly: ExportRenderer(typeof(HybridWebView), typeof(HybridWebViewRenderer))]
namespace XFHybridWebViewAdvDemo.UWP.Renderers
{
    public class HybridWebViewRenderer : WebViewRenderer
    {
        private const string JavaScriptFunction = "function invokeXamarinFormsAction(data){window.external.notify(data);}";

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                if (Control == null) return;

                Control.NavigationCompleted -= OnWebViewNavigationCompleted;
                Control.ScriptNotify -= OnWebViewScriptNotify;
            }
            if (e.NewElement != null)
            {
                Control.NavigationCompleted += OnWebViewNavigationCompleted;
                Control.ScriptNotify += OnWebViewScriptNotify;
                //// No need this since we're loading dynamically generated HTML content
                //Control.Source = new Uri($"ms-appx-web:///Content//{((HybridWebView)Element).Uri}");
            }
        }

        private async void OnWebViewNavigationCompleted(Windows.UI.Xaml.Controls.WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            if (args.IsSuccess)
            {
                // Inject JS script
                await Control.InvokeScriptAsync("eval", new[] { JavaScriptFunction });
            }
        }

        private void OnWebViewScriptNotify(object sender, NotifyEventArgs e)
        {
            var dataBody = e.Value.ToString();
            if (dataBody.Contains("|"))
            {
                var paramArray = dataBody.Split("|");
                var param1 = paramArray[0];
                var param2 = paramArray[1];
                ((HybridWebView)Element).InvokeAction(param1, param2);
            }
            else
            {
                ((HybridWebView)Element).InvokeAction(dataBody, null);
            }
        }
    }
}