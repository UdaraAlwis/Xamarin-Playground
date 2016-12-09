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
                            Text = "Welcome to the awesome HTML Formatter Label Control by ÇøŋfuzëÐ SøurcëÇødë !"
                        },
                        new HtmlFormattedLabel()
                        {
                            FontSize = 14,
                            Text = "<html><body><Center>" +
                                   "<font size='6'>" +
                                   "This is normal text, but this is <b>bold text</b>... " +
                                   "and this is <u>underline text</u>... " +
                                   "and this is <strike>strike through text</strike>... " +
                                   "and finally this is <i>italic text</i>... " +
                                   "</font>" +
                                   "<Center></body></html>",
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
