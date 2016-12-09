using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CustomRenderersDemo
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Padding = new Thickness(10,10,10,0),
                    Spacing = 20,
                    Children = {
                        new Label {
                            XAlign = TextAlignment.Center,
                            Text = "Welcome to Xamarin Forms!",
                            TextColor = Color.Black,
                            FontSize = 20,
                        }, 
                        new Button()
                        {
                            Text = "Click this Normal Button!",
                            BorderWidth = 2,
                            BorderColor = Color.Black,
                            BackgroundColor = Color.White,
                            TextColor = Color.Black,
                        },
                        new RoundCornersButton()
                        {
                            Text = "Click this Round Corners Button!",
                            BorderWidth = 2,
                            BorderColor = Color.Black,
                            BackgroundColor = Color.White,
                            TextColor = Color.Black,
                        }
                    }
                },
                BackgroundColor = Color.White
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
