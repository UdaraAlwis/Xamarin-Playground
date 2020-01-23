using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
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

        private bool isHtmlSet = false;

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (isHtmlSet)
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

                    "</body>" +

                    "</html>"
            };

            webViewElement.RegisterAction(DisplayDataFromJavascript);

            isHtmlSet = true;
        }

        private void DisplayDataFromJavascript(string data1, string data2)
        {
            Device.InvokeOnMainThreadAsync(async () =>
            {
                if (data1!=null && data1.Equals("PHOTO") && data2.Equals("CAMERA"))
                {
                    var result = await TakePhoto();
                    if (result != null)
                    {
                        await webViewElement.EvaluateJavaScriptAsync($"setresult_takephoto('{result}')");
                    }
                }
                else if (data1 != null && data1.Equals("PHOTO") && data2.Equals("GALLERY"))
                {
                    var result = await SelectPhoto();
                    if (result != null)
                    {
                        await webViewElement.EvaluateJavaScriptAsync($"setresult_selectphoto('{result}')");
                    }
                }
            });
        }

        private async Task<string> TakePhoto()
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return null;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "TestPhotoFolder",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = PhotoSize.Medium,
                MaxWidthHeight = 1000,
            });

            if (file == null)
                return null;

            // Convert bytes to base64 content
            var imageAsBytesBase64 = Convert.ToBase64String(ConvertFileToByteArray(file));

            return imageAsBytesBase64;
        }

        private async Task<string> SelectPhoto()
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return null;
            }

            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
            });

            if (file == null)
                return null;
            
            // Convert bytes to base64 content
            var imageAsBytesBase64 = Convert.ToBase64String(ConvertFileToByteArray(file));

            return imageAsBytesBase64;
        }

        private byte[] ConvertFileToByteArray(MediaFile imageFile)
        {
            // Convert Image to bytes
            byte[] imageAsBytes;
            using (var memoryStream = new MemoryStream())
            {
                imageFile.GetStream().CopyTo(memoryStream);
                imageFile.Dispose();
                imageAsBytes = memoryStream.ToArray();
            }

            return imageAsBytes;
        }
    }
}