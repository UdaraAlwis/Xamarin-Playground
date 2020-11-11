
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using System.Net;

namespace XFUploadFilesToServer
{
    public partial class MainPage : ContentPage
    {
        private FileResult _selectedFile;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void ButtonSelectFile_Clicked(object sender, EventArgs e)
        {
            try
            {
                ButtonUploadFile.IsEnabled = false;

                FileResult photo;
                if (MediaPicker.IsCaptureSupported)
                    photo = await MediaPicker.CapturePhotoAsync();
                else
                    photo = await MediaPicker.PickPhotoAsync();

                if (photo == null)
                    return;

                _selectedFile = photo;

                LabelFileName.Text = $"{_selectedFile.FileName} file selected. Ready to upload!";

                ButtonUploadFile.IsEnabled = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ops something went wrong: {ex.Message}");
                ButtonUploadFile.IsEnabled = false;
            }
        }

        private async void ButtonUploadFile_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (_selectedFile == null)
                    return;

                ActivityIndicator.IsRunning = true;

                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(await _selectedFile.OpenReadAsync()), "photo", _selectedFile.FileName);

                var httpClient = new HttpClient();
                var response = await httpClient.PostAsync("http://192.168.86.25:5000/FileUpload", content);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    LabelFileName.Text = $"{_selectedFile.FileName} upload success.";
                    ButtonUploadFile.IsEnabled = false;
                }
                else
                {
                    LabelFileName.Text = $"{_selectedFile.FileName} upload failed.";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ops something went wrong: {ex.Message}");
                LabelFileName.Text = $"{_selectedFile.FileName} upload failed.";
            }

            ActivityIndicator.IsRunning = false;
        }
    }
}
