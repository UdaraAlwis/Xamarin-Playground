using Plugin.Permissions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFHybridWebViewAdvDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private bool _isHtmlSet = false;

        private DeviceFeaturesHelper _deviceFeaturesHelper;

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (_isHtmlSet)
                return;

            webViewElement.Source = new HtmlWebViewSource()
            {
                Html =
                    $@"<html>" +
                    "<head>" +
                        "<meta charset=\"utf-8\">" +
                        "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\">" +
                        "<link rel=\"stylesheet\" href=\"https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css\" " +
                        "integrity=\"sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh\" crossorigin=\"anonymous\">" +

                        "<script type=\"text/javascript\">" +
                            "function setresult_takephoto(value) {" +
                            "    document.getElementById(\"photoCamera_ResultElement\").src = \"data:image/png;base64,\" + value;" +
                            "    document.getElementById(\"photoCamera_placeholderElement\").remove();" +
                            "}" +
                            "function setresult_selectphoto(value) {" +
                            "    document.getElementById(\"photoGallery_ResultElement\").src = \"data:image/png;base64,\" + value;" +
                            "    document.getElementById(\"photoGallery_placeholderElement\").remove();" +
                            "}" +
                            "function setresult_getdeviceinfo(value) {" +
                            "    document.getElementById(\"deviceInfo_ResultElement\").innerHTML = value;" +
                            "    document.getElementById(\"deviceInfo_placeholderElement\").remove();" +
                            "}" +
                            "function invokexamarinforms(param){" +
                            "    try{" +
                            "        invokeXamarinFormsAction(param);" +
                            "    }" +
                            "    catch(err){" +
                            "        alert(err);" +
                            "    }" +
                            "}" +
                        "</script>" +
                    "</head>" +

                    "<body style=\"background-color: #d4ecff;padding: 20px; border: 1px solid #2196F3;border-radius: 5px;\">" +
                        "<div>" +
                            "<p class=\"h4\">This is a simple bootstrap HTML Web page!</p><br />" +
                        "</div>" +

                        "<div class=\"card border-primary mb-3\">" +
                            "<h5 class=\"card-header\">Take Photo</h5>" +
                            "<div class=\"card-body\">" +
                                "<div class=\"shadow-sm p-2 mb-3 bg-white rounded\">" +
                                    "<div id=\"photoCamera_placeholderElement\" >" +
                                        "<span class=\"spinner-grow spinner-grow-sm\" role=\"status\" aria-hidden=\"true\" ></span>" +
                                        "<span style=\"padding-left:10px;\">Waiting for data...</span>" +
                                    "</div>" +
                                    "<img class=\"card-img-top\" id=\"photoCamera_ResultElement\" />" +
                                "</div>" +
                                "<button type=\"button\" class=\"btn btn-primary btn-lg btn-block\" onclick=\"invokexamarinforms('PHOTO|CAMERA')\">Get from Xamarin.Forms</button>" +
                            "</div>" +
                        "</div>" +

                        "<div class=\"card border-primary mb-3\">" +
                            "<h5 class=\"card-header\">Select Photo</h5>" +
                            "<div class=\"card-body\">" +
                                "<div class=\"shadow-sm p-2 mb-3 bg-white rounded\">" +
                                    "<div id=\"photoGallery_placeholderElement\" >" +
                                        "<span class=\"spinner-grow spinner-grow-sm\" role=\"status\" aria-hidden=\"true\" ></span>" +
                                        "<span style=\"padding-left:10px;\">Waiting for data...</span>" +
                                    "</div>" +
                                    "<img class=\"card-img-top\" id=\"photoGallery_ResultElement\" />" +
                                "</div>" +
                                "<button type=\"button\" class=\"btn btn-primary btn-lg btn-block\" onclick=\"invokexamarinforms('PHOTO|GALLERY')\">Get from Xamarin.Forms</button>" +
                            "</div>" +
                        "</div>" +

                        "<div class=\"card border-primary mb-3\">" +
                            "<h5 class=\"card-header\">GPS Location</h5>" +
                            "<div class=\"card-body\">" +
                                "<div class=\"shadow-sm p-2 mb-3 bg-white rounded\">" +
                                    "<div id=\"gps_placeholderElement\" >" +
                                        "<span class=\"spinner-grow spinner-grow-sm\" role=\"status\" aria-hidden=\"true\" ></span>" +
                                        "<span style=\"padding-left:10px;\">Waiting for data...</span>" +
                                    "</div>" +
                                    "<img class=\"card-img-top\" id=\"gps_ResultElement\" />" +
                                "</div>" +
                                "<button type=\"button\" class=\"btn btn-primary btn-lg btn-block\" onclick=\"invokexamarinforms('GPS')\">Get from Xamarin.Forms</button>" +
                            "</div>" +
                        "</div>" +

                        "<div class=\"card border-primary mb-3\">" +
                            "<h5 class=\"card-header\">Device Info</h5>" +
                            "<div class=\"card-body\">" +
                                "<div class=\"shadow-sm p-2 mb-3 bg-white rounded\">" +
                                    "<div id=\"deviceInfo_placeholderElement\" >" +
                                        "<span class=\"spinner-grow spinner-grow-sm\" role=\"status\" aria-hidden=\"true\" ></span>" +
                                        "<span style=\"padding-left:10px;\">Waiting for data...</span>" +
                                    "</div>" +
                                    "<p class=\"text-uppercase\" id=\"deviceInfo_ResultElement\" />" +
                                "</div>" +
                                "<button type=\"button\" class=\"btn btn-primary btn-lg btn-block\" onclick=\"invokexamarinforms('INFO')\">Get from Xamarin.Forms</button>" +
                            "</div>" +
                        "</div>" +

                    "</body>" +

                    "</html>"
            };

            webViewElement.RegisterAction(DisplayDataFromJavascript);
            
            var isInit = await Plugin.Media.CrossMedia.Current.Initialize();

            _deviceFeaturesHelper = new DeviceFeaturesHelper();

            _isHtmlSet = true;
        }

        private async void DisplayDataFromJavascript(string data1, string data2)
        {
            if (data1 != null && data1.Equals("PHOTO") && data2.Equals("CAMERA"))
            {
                var result = await _deviceFeaturesHelper.TakePhoto(this);
                if (result != null)
                {
                    await webViewElement.EvaluateJavaScriptAsync($"setresult_takephoto('{result}')");
                }
            }
            else if (data1 != null && data1.Equals("PHOTO") && data2.Equals("GALLERY"))
            {
                var result = await _deviceFeaturesHelper.SelectPhoto(this);
                if (result != null)
                {
                    await webViewElement.EvaluateJavaScriptAsync($"setresult_selectphoto('{result}')");
                }
            }
            else if (data1 != null && data1.Equals("INFO"))
            {
                var result = await _deviceFeaturesHelper.GetDeviceData();
                if (result != null)
                {
                    await webViewElement.EvaluateJavaScriptAsync($"setresult_getdeviceinfo('{result}')");
                }
            }
        }
    }
}