using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace PageTranslucentLayerXF
{
    public partial class BlurredLayerPage : PopupPage
    {
        public BlurredLayerPage()
        {
            InitializeComponent();
        }
        
        private void OnClose(object sender, EventArgs e)
        {
           Navigation.PopPopupAsync();
        }

        protected override Task OnAppearingAnimationEnd()
        {
            return base.OnAppearingAnimationEnd();
        }

        protected override bool OnBackgroundClicked()
        {
            return false;
        }
    }
}
