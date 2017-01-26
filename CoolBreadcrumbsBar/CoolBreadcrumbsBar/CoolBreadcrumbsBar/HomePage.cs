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
        private StackLayout _animatedStack;
        private ScrollView _breadCrumbsScrollView;
        private Button _addNewBreadcrumbButton;

        public HomePage()
        {
            _animatedStack = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    new Label
                    {
                        HorizontalOptions = LayoutOptions.Start,
                        Text = "Welcome!",
                        FontSize = 15,
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Color.Black,
                    },
                },
                Padding = new Thickness(10,0,10,0),
                HeightRequest = 40,
            };
            _animatedStack.ChildAdded += _animatedStack_ChildAdded;

            _breadCrumbsScrollView = new ScrollView
            {
                Content = _animatedStack,
                Orientation = ScrollOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
            };

            _addNewBreadcrumbButton =
                new Button()
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Text = "Add a Breadcrumb",
                };
            _addNewBreadcrumbButton.Clicked += AddNewBreadcrumbButton_Clicked;


            Content =
            new StackLayout()
            {
                Padding = new Thickness(0,20,0,0),
                Children =
                {
                    new Label()
                    {
                        HorizontalTextAlignment = TextAlignment.Center,
                        Text = "Welcome to the Cool Breadcrumbs Bar!",
                        FontSize = 20,
                        HeightRequest = 80,
                        TextColor = Color.Black,
                    },

                    _breadCrumbsScrollView,

                    _addNewBreadcrumbButton,
                }
            };

            BackgroundColor = Color.White;
            
        }

        private void _animatedStack_ChildAdded(object sender, ElementEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var width = Application.Current.MainPage.Width;

                var storyboard = new Animation();
                var enterRight = new Animation(callback: d => _animatedStack.Children.Last().TranslationX = d,
                                               start: width,
                                               end: 0,
                                               easing: Easing.Linear);

                storyboard.Add(0, 1, enterRight);
                storyboard.Commit(_animatedStack.Children.Last(), "LeftToRightAnimation", length: 700);
            });
        }

        private void AddNewBreadcrumbButton_Clicked(object sender, EventArgs e)
        {
            _addNewBreadcrumbButton.IsEnabled = false;

            // retrieve the page width
            var width = Application.Current.MainPage.Width;

            // Add the new Breadcrumb Label
            _animatedStack.Children.Add(new Label
            {
                HorizontalOptions = LayoutOptions.End,
                Text = "\\ " + RandomWordGenerator.WordFinder2(new Random().Next(5, 10)),
                FontSize = 15,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
                TranslationX = width,
            });

            // Scroll to the end of the StackLayout
            _breadCrumbsScrollView.ScrollToAsync(_animatedStack,
                ScrollToPosition.End, true);

            _addNewBreadcrumbButton.IsEnabled = true;
        }
    }
}
