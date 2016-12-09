using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CoolBreadcrumbsBar
{
    public class HomePage : ContentPage
    {
        private StackLayout animatedStack;
        private ScrollView breadCrumbsScrollView;

        public HomePage()
        {
            animatedStack = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    new Label
                    {
                        HorizontalOptions = LayoutOptions.Start,
                        Text = "Welcome",
                        FontSize = 15,
                    },
                },
                Padding = new Thickness(10,0,10,0)
            };
            
            animatedStack.ChildAdded += (sender, args) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var width = Application.Current.MainPage.Width;

                    var storyboard = new Animation();
                    var enterRight = new Animation(callback: d => animatedStack.Children.Last().TranslationX = d,
                                                   start: width,
                                                   end: 0,
                                                   easing: Easing.Linear);

                    storyboard.Add(0, 1, enterRight);
                    storyboard.Commit(animatedStack.Children.Last(), "Loop", length: 700);
                });
            };

            var addNewBreadcrumbButton =
                new Button()
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Text = "Add a Breadcrumb!",
                };

            addNewBreadcrumbButton.Clicked += (sender, args) =>
            {
                addNewBreadcrumbButton.IsEnabled = false;

                var width = Application.Current.MainPage.Width;

                animatedStack.Children.Add(new Label
                {
                    HorizontalOptions = LayoutOptions.End,
                    Text = "\\ " + WordFinder2(new Random().Next(5, 10)),
                    FontSize = 15,
                    TranslationX = width,
                });

                breadCrumbsScrollView.ScrollToAsync(animatedStack,
                    ScrollToPosition.End, true);

                addNewBreadcrumbButton.IsEnabled = true;
            };

            breadCrumbsScrollView = new ScrollView
            {
                Content = animatedStack,
                Orientation = ScrollOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
            };

            Content =

                new StackLayout()
                {
                    Children =
                    {
                        new Label()
                        {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = "Welcome to the Cool Breadcrumbs Bar!",
                            FontSize = 20,
                            HeightRequest = 80,
                        },

                        breadCrumbsScrollView,

                        addNewBreadcrumbButton,
                    }
                };
            
        }
        
        /// <summary>
        /// Just to generate some random words lah! :P
        /// </summary>
        /// <param name="requestedLength"></param>
        /// <returns></returns>
        public string WordFinder2(int requestedLength)
        {
            Random rnd = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z" };
            string[] vowels = { "a", "e", "i", "o", "u" };

            string word = "";

            if (requestedLength == 1)
            {
                word = GetRandomLetter(rnd, vowels);
            }
            else
            {
                for (int i = 0; i < requestedLength; i += 2)
                {
                    word += GetRandomLetter(rnd, consonants) + GetRandomLetter(rnd, vowels);
                }

                word = word.Replace("q", "qu").Substring(0, requestedLength); // We may generate a string longer than requested length, but it doesn't matter if cut off the excess.
            }

            return word;
        }

        private static string GetRandomLetter(Random rnd, string[] letters)
        {
            return letters[rnd.Next(0, letters.Length - 1)];
        }
    }
}
