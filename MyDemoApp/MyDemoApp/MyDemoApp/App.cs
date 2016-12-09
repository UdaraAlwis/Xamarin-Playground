using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Forms9Patch;
using Xamarin.Forms;
using Image = Xamarin.Forms.Image;
using ImageSource = Xamarin.Forms.ImageSource;
using Label = Xamarin.Forms.Label;
using StackLayout = Xamarin.Forms.StackLayout;

namespace MyDemoApp
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new ContentPage
            {
                Content = 
                new ScrollView() { Content =
                new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        
                        
                        // multi-resolution handling

                        new Label {
                            Text = "Xamarin.Forms.Image with Xamarin.Forms.ImageSource",
                            FontSize = 18,
                            HorizontalTextAlignment = TextAlignment.Center,
                            HorizontalOptions = LayoutOptions.Center,
                        },
                        new Image
                        {
                            Source = ImageSource.FromResource("MyDemoApp.Resources.image.png")
                        },


                        new Label {
                            Text = "Forms9Patch.Image with Forms9Patch.ImageSource",
                            FontSize = 18,
                            HorizontalTextAlignment = TextAlignment.Center,
                            HorizontalOptions = LayoutOptions.Center,
                        },
                        new Forms9Patch.Image
                        {
                            Source = Forms9Patch.ImageSource.FromMultiResource("MyDemoApp.Resources.image") ,
                        },



                        
                        // image stretch-ability - CapInsets

                        new Label () {
                            Text = "Xamarin Image",FontSize = 18,
                            HorizontalTextAlignment = TextAlignment.Center,
                            HorizontalOptions = LayoutOptions.Center,
                        },
                        new Xamarin.Forms.Image ()
                        {
                            Aspect = Aspect.Fill,
                            Source = ImageSource.FromResource("MyDemoApp.Resources.redribbon.png"),
                        },



                        new Label () {
                            Text = "Forms9Patch Image w/ CapInsets",FontSize = 18,
                            HorizontalTextAlignment = TextAlignment.Center,
                            HorizontalOptions = LayoutOptions.Center,
                        },
                        new Forms9Patch.Image ()
                        {
                            Fill = Fill.Fill,
                            Source = ImageSource.FromResource("MyDemoApp.Resources.redribbon.png"),
                            CapInsets = new Thickness(23, 0, 110, 0),
                        },

                        
                        // image stretch-ability - CapInsets
                        
                        new Label () {
                            Text = "Forms9Path NinePatch Image",
                            FontSize = 18,
                            HorizontalTextAlignment = TextAlignment.Center,
                            HorizontalOptions = LayoutOptions.Center,
                        },
                        new Forms9Patch.Image () {
                            Source = Forms9Patch.ImageSource.FromMultiResource("MyDemoApp.Resources.bubble.9.png"),
                            HeightRequest = 110,
                        },

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
