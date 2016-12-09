using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFTransparentPopup
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OpenTransparentPopupButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new TransparentPopup());
        }
    }
}
