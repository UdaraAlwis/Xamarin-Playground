using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace XFCustomNavBar.Views
{
    public class Page2 : ContentPage
    {
        public Page2()
        {
            Button btn1 = new Button()
            {
                Text = "Go to page 3",
            };
            btn1.Clicked += (sender, args) =>
            {
                Navigation.PushAsync(new Page3());
            };

            BackgroundColor = Color.White;
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Padding = new Thickness(10, 10, 10, 10),
                Children =
                {
                    new Label
                    {
                        XAlign = TextAlignment.Center,
                        FontSize = 25,
                        TextColor = Color.Black,
                        //Text = "Here is the Page 2!"
                        Text = "Here is the 2nd Page!"
                    },
                    btn1
                }
            };

            this.Title = "2nd Page";

            this.ToolbarItems.Add(new ToolbarItem()
            {
                Text = "Refund",
                Order = ToolbarItemOrder.Primary,
                Command = new Command(() => { /*Later bind to viewmodel*/ }),
            });

            this.ToolbarItems.Add(new ToolbarItem()
            {
                Text = "Log out",
                Order = ToolbarItemOrder.Primary,
                Command = new Command(() => { /*Later bind to viewmodel*/ }),
            });

            this.ToolbarItems.Add(new ToolbarItem()
            {
                Text = "Blah blah",
                Order = ToolbarItemOrder.Primary,
                Command = new Command(() => { /*Later bind to viewmodel*/ }),
            });
        }
    }
}
