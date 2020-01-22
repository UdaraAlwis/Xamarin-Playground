using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XFHybridWebViewAdvDemo.Controls
{
    public class HybridWebView : WebView
    {
        private Action<string> _action;

        public void RegisterAction(Action<string> callback)
        {
            _action = callback;
        }

        public void Cleanup()
        {
            _action = null;
        }

        public void InvokeAction(string data)
        {
            if (_action == null || data == null)
            {
                return;
            }
            _action.Invoke(data);
        }
    }
}
