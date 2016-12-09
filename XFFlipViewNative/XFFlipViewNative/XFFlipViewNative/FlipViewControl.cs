using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XFFlipViewNative
{
    public class FlipViewControl : ContentView
    {
        public ICommand MoveToPreviousCommand;

        public FlipViewControl()
        {
            Content = new StackLayout()
            {
                Children =
                {
                    new Label()
                    {
                        Text = "FrontView",
                        FontSize = 20,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.CenterAndExpand
                    }
                },

                BackgroundColor = Color.Red,
                HeightRequest = 200,
            };
        }
    }
}
