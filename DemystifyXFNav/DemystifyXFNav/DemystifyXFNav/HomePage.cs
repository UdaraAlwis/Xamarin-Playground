using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemystifyXFNav
{
    public class HomePage : ContentPage
    {
        private Label _lbl;
        private Button _btn1;
        private Button _btn2;
        private Button _btn3;

        public HomePage()
        {
            Title = "Home Page";
            _lbl = new Label();

            _btn1 = new Button() { Text = "PushAsync" };
            _btn1.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new Page1());
            };
            
            _btn2 = new Button() { Text = "PushModalAsync" };
            _btn2.Clicked += async (sender, args) =>
            {
                await Navigation.PushModalAsync(new NavigationPage(new Page1()) {
                    BarBackgroundColor = Color.FromHex("#ff0066"),
                    BarTextColor = Color.White,
                }, false);
            };

            _btn3 = new Button() { Text = "Native PushModalAsync" };
            _btn3.Clicked +=  (sender, args) =>
            {
                //await Navigation.PushModalAsync(new MyThirdPage());
                MessagingCenter.Send(this, "THISISAMESSAGE", new NativeNavigationArgs(new MyThirdPage()));
            };

            Content = new StackLayout
            {
                Children = {
                    
                    _btn1,
                    _btn2,
                    _btn3,

                    _lbl
                }
            };

            _lbl.Text += "App Opened!\n";

            this.Appearing += (sender, args) =>
            {
                _lbl.Text += $"OnAppearing! { this.Title } \n";
            };

            this.Disappearing += (sender, args) =>
            {
                _lbl.Text += $"OnDisappearing! { this.Title } \n";
            };
        }
    }
}
