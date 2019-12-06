using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Xamarin.Forms;

namespace XFInteropTest
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private string sampleImageElement =
            "<img alt=\"Google\" height=\"92\" id=\"hplogo\" src=\"https://www.google.com/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png\"  style=\"padding-top:109px\" width=\"272\">";

        public MainPage()
        {
            InitializeComponent();

            webViewElement.Source = new HtmlWebViewSource
            {
                Html = $@"<html>"+
                       "<head><style>*{margin:0;padding:0}.imgbox{display:grid;height:100%}.center-fit{max-width:100%;max-height:100vh;margin:auto}</style></head>" +
                       "<body>" +
                       "<script type=\"text/javascript\">" +
                       "function factorial(num) {" +
                       "        var numValue = num;"+
                       "        if(isNaN(num)){" +
                       "            document.getElementById(\"calcValue\").innerHTML = \"nope!\";" +
                       "            return num;" +
                       "        }"+
                       "        if (num === 0 || num === 1)" +
                       "            return 1;" +
                       "        for (var i = num - 1; i >= 1; i--) {" +
                       "            num *= i;" +
                       "        }" +
                       "        document.getElementById(\"calcValue\").innerHTML = \"Factorial of \" + numValue + \" is \" + num + \".\";" +
                       "        return num;" +
                       "}" +
                       "function showimg(base64imagestring) {" +
                       //"        alert('starting!');" +
                       //"        document.getElementById(\"myImg\").src = \"https://loremflickr.com/640/360\" + \"?t=\" + new Date().getTime(); " +
                       "        document.getElementById(\"myImg\").src = \"data:image/png;base64,\" + base64imagestring;" +

                       "        alert('done!');" +
                       "}" +
                       "function showtext(textval) {" +
                       "        document.getElementById(\"textValue\").innerHTML = textval;" +
                       "}" +
                       "</script>" +

                       "<p id=\"calcValue\"></p> <br>" +
                       "<p id=\"textValue\"></p> <br>" +
                       "<img id=\"myImg\" class=\"center-fit\" >" +

                       "</body>" +
                       "</html>"
            };

        }

        private async void entry1Element_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(entry1Element.Text, out int number))
            {
                string result = await webViewElement.EvaluateJavaScriptAsync($"factorial({number})");
                labelElement.Text = $"Factorial of {number} is {result}.";
            }
            else
            {
                string result = await webViewElement.EvaluateJavaScriptAsync($"factorial('{entry1Element.Text}')");
                labelElement.Text = string.Empty;
            }
        }

        private async void entry2Element_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            string result = await webViewElement.EvaluateJavaScriptAsync($"showtext('{entry2Element.Text}')");
        }

        private async void buttonElement_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                SaveToAlbum = false,
            });

            if (file == null)
                return;


            byte[] imageAsBytes;
            using (var memoryStream = new MemoryStream())
            {
                file.GetStream().CopyTo(memoryStream);
                file.Dispose();
                imageAsBytes = memoryStream.ToArray();
            }

            var imageAsBytesBase64 = Convert.ToBase64String(imageAsBytes);

            string result = await webViewElement.EvaluateJavaScriptAsync($"showimg('{imageAsBytesBase64}')");

            //image.Source = ImageSource.FromStream(() =>
            //{
            //    var stream = file.GetStream();
            //    return stream;
            //});
        }
    }
}
