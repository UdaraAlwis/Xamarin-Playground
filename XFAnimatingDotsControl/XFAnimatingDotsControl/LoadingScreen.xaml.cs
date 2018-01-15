using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XFAnimatingDotsControl
{
    public partial class LoadingScreen : ContentPage
    {
        public LoadingScreen()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await Task.Factory.StartNew(async () =>
            {
                await Task.Delay(7000);

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopModalAsync();
                });
            });
        }
    }
}
