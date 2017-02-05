using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XFHtmlFormattedLabelControl
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
                    Padding = new Thickness(20,0,20,0),
                    Spacing = 30,
                    Children = {
                        new Label {
                            HorizontalTextAlignment = TextAlignment.Center,
                            TextColor = Color.Black,
                            Text = "Welcome to the awesome HTML Formatter Label Control by ÇøŋfuzëÐ SøurcëÇødë!"
                        },
                        new HtmlFormattedLabel()
                        {
                            FontSize = Device.OnPlatform(14,20,20),
                            TextColor = Color.Black,
                            Text = "<html><body><Center>" +
                                   "<font size='6'>" +
                                   "This is a html formatted text, so this is <b>bold text</b>... " +
                                   "and this is <u>underline text</u>... " +
                                   "and this is <strike>strike through text</strike>... " +
                                   "and finally this is <i>italic text</i>... " +
                                   "<br />" +
                                   "Ops this is html line break..." +
                                   "<br />" +
                                   "And this is <sup>superscripted</sup> html text."+
                                   "</font>" +
                                   "<Center></body></html>",
                        }
                    }
                },
                BackgroundColor = Color.White,
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
