using Plugin.Permissions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFHybridWebViewAdvDemo.Content;

namespace XFHybridWebViewAdvDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private DeviceFeaturesHelper _deviceFeaturesHelper;

        public MainPage()
        {
            InitializeComponent();

            webViewElement.Source = new HtmlWebViewSource()
            {
                Html = HtmlSourceContent.Content,
            };

            webViewElement.RegisterAction(ExecuteActionFromJavascript);

            _deviceFeaturesHelper = new DeviceFeaturesHelper();
        }

        private async void ExecuteActionFromJavascript(string param1, string param2)
        {
            statusActivityIndicator.IsVisible = true;
            statusLabel.Text = $"Received request: {param1} {param2}";

            if (param1 != null && param1.Equals("PHOTO") && param2.Equals("CAMERA"))
            {
                var result = await _deviceFeaturesHelper.TakePhoto(this);
                if (result != null)
                {
                    await webViewElement.EvaluateJavaScriptAsync($"setresult_takephoto('{result}')");
                }
            }
            else if (param1 != null && param1.Equals("PHOTO") && param2.Equals("GALLERY"))
            {
                var result = await _deviceFeaturesHelper.SelectPhoto(this);
                if (result != null)
                {
                    await webViewElement.EvaluateJavaScriptAsync($"setresult_selectphoto('{result}')");
                }
            }
            else if (param1 != null && param1.Equals("DEVICEINFO"))
            {
                var result = await _deviceFeaturesHelper.GetDeviceData();
                if (result != null)
                {
                    await webViewElement.EvaluateJavaScriptAsync($"setresult_getdeviceinfo('{result}')");
                }
            }
            else if (param1 != null && param1.Equals("GPS"))
            {
                var result = await _deviceFeaturesHelper.GetGpsLocation();
                if (result != null)
                {
                    await webViewElement.EvaluateJavaScriptAsync($"setresult_getgpslocation('{result}')");
                }
            }

            statusActivityIndicator.IsVisible = false;
            statusLabel.Text = $"Waiting for requests from Javascript in the WebView...";
        }

		//private void htmlSourceSwitch_Toggled(object sender, ToggledEventArgs e)
		//{
		//	if (e.Value) 
		//	{
		//		webSourceStatusLabel.Text = "HTML Source: Online hosted Web content.";
		//		webViewElement.Source = "https://testwebpage.htmlsave.com/";
		//	}
		//	else
		//	{
		//		webSourceStatusLabel.Text = "HTML Source: Local generated Web content.";
  //              webViewElement.Source = new HtmlWebViewSource()
  //              {
  //                  Html = HtmlSourceContent.Content,
  //              };
  //          }
  //      }
	}
}