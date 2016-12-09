using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace XFTransparentPopupUpdate
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OpenTransparentPopupButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new TransparentPopup());
        }
    }
}
