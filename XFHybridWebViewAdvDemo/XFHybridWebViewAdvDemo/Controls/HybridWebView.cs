using System;
using System.Collections.Generic;
using System.Text;
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

        public void InvokeAction(string data1, string data2)
        {
            if (_action == null || (data1 == null && data2 == null))
            {
                return;
            }
            _action.Invoke(data1, data2);
        }
    }
}
