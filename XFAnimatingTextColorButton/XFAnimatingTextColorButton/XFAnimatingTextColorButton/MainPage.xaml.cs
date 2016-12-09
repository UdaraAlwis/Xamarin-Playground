using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFAnimatingTextColorButton
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BlinkyTextButton_OnClicked(object sender, EventArgs e)
        {
            BlinkyTextButton.IsTextColorAnimating = !BlinkyTextButton.IsTextColorAnimating;
        }
    }
}
