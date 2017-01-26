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
        private StackLayout _breadcrumbStackLayout;
        private ScrollView _breadCrumbsScrollView;
        private Button _addNewBreadcrumbButton;
        private Button _clearAllBreadcrumbsButton;

        public HomePage()
        {
            // le animated breadcrumbs bar
            _breadcrumbStackLayout = new StackLayout()
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
                HeightRequest = 30,
            };
            _breadcrumbStackLayout.ChildAdded += AnimatedStack_ChildAdded;

            // let's add that breadcrumbs stacklayout inside a scrollview
            _breadCrumbsScrollView = new ScrollView
            {
                Content = _breadcrumbStackLayout,
                Orientation = ScrollOrientation.Horizontal,
                VerticalOptions = LayoutOptions.StartAndExpand,
            };


            // Button for adding and removing breadcrumbs 
            _addNewBreadcrumbButton =
                new Button()
                {
                    Text = "Add a Breadcrumb",
                    TextColor = Color.Black,
                    BackgroundColor = Color.White,
                    BorderColor = Color.Gray,
                    BorderWidth = 2,
                };
            _addNewBreadcrumbButton.Clicked += AddNewBreadcrumbButtonOnClicked;

            _clearAllBreadcrumbsButton =
                new Button()
                {
                    Text = "Clear Breadcrumbs",
                    TextColor = Color.Black,
                    BackgroundColor = Color.White,
                    BorderColor = Color.Gray,
                    BorderWidth = 2,
                };
            _clearAllBreadcrumbsButton.Clicked += ClearAllBreadcrumbsButtonOnClicked;


            // Now put em all together on the screen
            Content =
            new StackLayout()
            {
                Padding = Device.OnPlatform(new Thickness(5, 40, 5, 0), new Thickness(0, 20, 0, 0), new Thickness(0, 20, 0, 0)),
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    _breadCrumbsScrollView,
                    
                    new Label()
                    {
                        VerticalOptions = LayoutOptions.EndAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,
                        Text = "Welcome to the Breadcrumbs Bar with Xamarin Forms !",
                        FontSize = 25,
                        TextColor = Color.Black,
                    },

                    new StackLayout() { 
                        Children = { 
                            _addNewBreadcrumbButton,
                            _clearAllBreadcrumbsButton,
                        },
                        VerticalOptions = LayoutOptions.End,
                        Padding = new Thickness(10,10,10,10),
                    }
                }
            };

            BackgroundColor = Color.White;
        }
        

        private void ClearAllBreadcrumbsButtonOnClicked(object sender, EventArgs eventArgs)
        {
            _breadcrumbStackLayout.Children.Clear();

            _breadcrumbStackLayout.Children.Add(
            new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                Text = "Welcome!",
                FontSize = 15,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
            });
        }

        private void AnimatedStack_ChildAdded(object sender, ElementEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var width = Application.Current.MainPage.Width;

                var storyboard = new Animation();
                var enterRight = new Animation(callback: d => _breadcrumbStackLayout.Children.Last().TranslationX = d,
                                               start: width,
                                               end: 0,
                                               easing: Easing.Linear);

                storyboard.Add(0, 1, enterRight);
                storyboard.Commit(_breadcrumbStackLayout.Children.Last(), "LeftToRightAnimation", length: 700);
            });
        }

        private void AddNewBreadcrumbButtonOnClicked(object sender, EventArgs e)
        {
            _addNewBreadcrumbButton.IsEnabled = false;

            // retrieve the page width
            var width = Application.Current.MainPage.Width;

            // Add the new Breadcrumb Label
            _breadcrumbStackLayout.Children.Add(new Label
            {
                HorizontalOptions = LayoutOptions.End,
                Text = "/ " + RandomWordGenerator.GetMeaninglessRandomString(new Random().Next(5, 10)),
                FontSize = 15,
                TextColor = Color.Black,
                TranslationX = width,
            });

            // Scroll to the end of the StackLayout
            _breadCrumbsScrollView.ScrollToAsync(_breadcrumbStackLayout,
                ScrollToPosition.End, true);

            _addNewBreadcrumbButton.IsEnabled = true;
        }
    }
}
