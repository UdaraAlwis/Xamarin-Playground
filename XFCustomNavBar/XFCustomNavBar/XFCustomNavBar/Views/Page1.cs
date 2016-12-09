using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace XFCustomNavBar.Views
{
    public class Page1 : ContentPage
    {
        public Page1()
        {
            Button btn1 = new Button()
            {
                Text = "Go to page 2",
                BackgroundColor = Color.FromHex("#ff5300"),
                TextColor = Color.White,
            };
            btn1.Clicked += (sender, args) =>
            {
                Navigation.PushAsync(new Page2());
            };

            BackgroundColor = Color.White;
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Padding = new Thickness(10, 10, 10, 10),
                Spacing = 25,
                Children =
                {
                    new Label
                    {
                        XAlign = TextAlignment.Center,
                        FontSize = 25,
                        TextColor = Color.Black,
                        Text = "Welcome to the App with the Awesome Content Page by the ÇøŋfuzëÐ SøurcëÇødë ! ;)"
                    },
                    btn1
                }
            };
            
            this.Title = "Page 1";
        }
    }
}
