using System;
using System.ComponentModel;
using System.Net.Http;
using Xamarin.Forms;

namespace XFSslSwitchDemo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            HttpClient _client;
            _client = new HttpClient();

            // http://httpbin.org/
            // http://httpbin.org/get

            // http://example.com/
            // https://example.com/

            // self-signed certificate connection
            // https://self-signed.badssl.com/
            // https://badssl.com/

            var url = "http://http.badssl.com/";

            try
            {
                var uri = new Uri(url);

                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    await DisplayAlert($"SUCCESS: {url}", content, cancel: "Ok");
                }
            }
            catch (Exception e)
            {
                await DisplayAlert($"FAILED: {url}", e.Message, cancel: "Ok");
            }
        }
    }
}
