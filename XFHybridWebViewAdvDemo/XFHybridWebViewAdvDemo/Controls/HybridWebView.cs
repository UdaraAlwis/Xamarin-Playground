using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XFHybridWebViewAdvDemo.Controls
{
    public class HybridWebView : WebView
    {
        private Action<string, string> _action;

        public void RegisterAction(Action<string, string> callback)
        {
            _action = callback;
        }

        public void Cleanup()
        {
            _action = null;
        }

        public void InvokeAction(string param1, string param2)
        {
            if (_action == null || (param1 == null && param2 == null))
            {
                return;
            }

            if (MainThread.IsMainThread)
                _action.Invoke(param1, param2);
            else
                MainThread.BeginInvokeOnMainThread(() => _action.Invoke(param1, param2));
        }
    }
}
