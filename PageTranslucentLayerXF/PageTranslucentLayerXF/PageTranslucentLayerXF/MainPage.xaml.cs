using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace PageTranslucentLayerXF
{
    public partial class MainPage : CoolCustomPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void RelativeLayoutPageBlock_OnClicked(object sender, EventArgs e)
        {
            CoolImageControl.IsVisible = true;

            Device.StartTimer(TimeSpan.FromSeconds(3), 
            () =>
            {
                CoolImageControl.FadeTo(0, 400).ContinueWith((result) =>
                {
                    CoolImageControl.IsVisible = false;
                });

                return false;
            });
        }

        private async void NewPageOverlayBlock_OnClicked(object sender, EventArgs e)
        {
            this.TranslucentPageBlock = TranslucentBlockerState.Active;

            var page = new BlurredLayerPage();
            await Navigation.PushPopupAsync(page);


            //var page2 = new BlurredLayerPage();
            //await Navigation.PushPopupAsync(page2);

            //Device.StartTimer(TimeSpan.FromSeconds(2),
            //() =>
            //{
            //    Navigation.PushModalAsync(new TransparentPage());

            //    return false;
            //});
        }
    }
}
