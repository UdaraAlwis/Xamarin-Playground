using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XFCurvedCornersImageControl
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
                    Padding = new Thickness(30,10,30,10),
                    Spacing = 30,
                    Children = {
                        new Label {
                            XAlign = TextAlignment.Center,
                            Text = "Welcome to Xamarin Forms!"
                        },
                        new Image()
                        {
                            Aspect = Aspect.AspectFill,
                            Source = ImageSource.FromResource("XFCurvedCornersImageControl.Images.xamarinlogo.png")
                        },
                        new CurvedCornersImage()
                        {
                            Aspect = Aspect.AspectFill,
                            Source = ImageSource.FromResource("XFCurvedCornersImageControl.Images.xamarinlogo.png")
                        },
                        new Label()
                        {
                            XAlign = TextAlignment.Center,
                            Text = "Behold this awesome Curved Corners Image Control!",
                        }
                    }
                }
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
