using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFTransparentPopup
{
    public class TransparentPopup : ContentPage
    {
        public TransparentPopup()
        {
            Button btnClose = new Button() { Text = "Close this" };
            btnClose.Clicked +=  BtnCloseOnClicked;

            Content = new StackLayout()
            {
                BackgroundColor = Color.Transparent,
                Children =
                {
                    new Label()
                    {
                        Text = "Hello from Transparent Modal Page",
                        FontSize = 18,
                        HorizontalTextAlignment = TextAlignment.Center
                    },
                    new ActivityIndicator()
                    {
                        IsRunning = true
                    },
                    btnClose,
                },
                VerticalOptions = LayoutOptions.Center,
                Padding = new Thickness(10, 0, 10, 0),
            };

            // set the background to transparent color 
            // (actually darkened-transparency: notice the alpha value at the end)
            this.BackgroundColor = new Color(0,0,0, 0.4);
        }

        private void BtnCloseOnClicked(object sender, EventArgs eventArgs)
        {
            // Close the modal page
            Navigation.PopModalAsync();
        }
    }
}
