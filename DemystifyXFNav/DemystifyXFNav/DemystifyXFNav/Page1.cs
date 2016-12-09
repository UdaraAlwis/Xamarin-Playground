using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace DemystifyXFNav
{
    public class Page1 : ContentPage
    {
        private Button _btnClose;

        public Page1()
        {
            Title = "Page 1";

            NavigationPage.SetHasNavigationBar(this, false);

            // Modal page doesn't have navigation bar
            //NavigationPage.SetHasNavigationBar(this, true);

            _btnClose = new Button() {Text = "Close this"};
            _btnClose.Clicked += (sender, args) =>
            {
                if (Navigation.ModalStack.Count > 0 && 
                Navigation.ModalStack.Last().GetType() == this.GetType())
                {
                    Navigation.PopModalAsync();
                }
                else
                if (Navigation.NavigationStack.Count > 0 && 
                Navigation.NavigationStack?.Last().GetType() == this.GetType())
                {
                    Navigation.PopAsync();
                }
            };

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" },
                    _btnClose
                }
            };

            this.BackgroundColor = Color.Gray;

        }
    }
}
