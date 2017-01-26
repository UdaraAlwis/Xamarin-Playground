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

        private void BlinkyTextButton1_OnClicked(object sender, EventArgs e)
        {
            BlinkyTextButton1.IsTextColorAnimating = !BlinkyTextButton1.IsTextColorAnimating;
        }
        private void BlinkyTextButton2_OnClicked(object sender, EventArgs e)
        {
            BlinkyTextButton2.IsTextColorAnimating = !BlinkyTextButton2.IsTextColorAnimating;
        }
    }
}
