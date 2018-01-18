using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFPageLifecycleDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private List<EventRecord> _propertyChangedHistoryList = new List<EventRecord>();

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            _propertyChangedHistoryList.Add(new EventRecord(propertyName, false));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _propertyChangedHistoryList.Add(new EventRecord("OnAppearing", false));

            WriteToUi();
        }
        
        protected override void OnDisappearing()
        {
            base.OnAppearing();

            _propertyChangedHistoryList.Add(new EventRecord("OnDisappearing", false));

            WriteToUi();
        }

        private void WriteToUi()
        {
            if (listStackLayout != null)
            {
                for (int i = 0; i < _propertyChangedHistoryList.Count; i++)
                {
                    if (!_propertyChangedHistoryList[i].IsWrittenToUI)
                    {
                        listStackLayout.Children.Add(
                            new StackLayout()
                            {
                                BackgroundColor = Color.DodgerBlue,
                                Padding = new Thickness(10, 0, 10, 0),
                                HorizontalOptions = LayoutOptions.Center,
                                Children =
                                {
                                    new Label()
                                    {
                                        Text = _propertyChangedHistoryList[i].EventName,
                                        FontAttributes = FontAttributes.Bold,
                                        TextColor = Color.White,
                                        VerticalTextAlignment = TextAlignment.Center,
                                        VerticalOptions = LayoutOptions.Center,
                                        HeightRequest = 30,
                                    },
                                }
                            });

                        _propertyChangedHistoryList[i].IsWrittenToUI = true;
                    }
                }
            }
        }

        private void BtnNextpage_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page2());
        }
    }

    public class EventRecord
    {
        public String EventName;
        public bool IsWrittenToUI;

        public EventRecord(string eventName, bool isWrittenToUi)
        {
            this.EventName = eventName;
            this.IsWrittenToUI = isWrittenToUi;
        }
    }
}