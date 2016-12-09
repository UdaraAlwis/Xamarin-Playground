using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace XFCustomNavBar.Views
{
    public class Page3 : ContentPage
    {
        public Page3()
        {
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
                        Text = "Welcome to the 3rd Page!"
                    }
                }
            };

            this.Title = "3rd Page";

            this.ToolbarItems.Add(new ToolbarItem()
            {
                Text = "Bloop",
                Order = ToolbarItemOrder.Primary,
                Command = new Command(() => { /*Later bind to viewmodel*/ }),
            });
        }
    }
}
