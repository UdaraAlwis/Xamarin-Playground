using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFForcefulKeyboardDismiss
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonDismissalTimerStart_OnClicked(object sender, EventArgs e)
        {
            int timerCount = 7;

            Device.StartTimer(TimeSpan.FromSeconds(1), 
            () =>
            {
                if (timerCount == 0)
                {

                    DependencyService.Get<IForceKeyboardDismissalService>().DismissKeyboard();
                    return false;
                }

                timerCount--;
                LabelCountDown.Text = $"Keyboard will dismiss in {timerCount} seconds...";

                return true;
            });
        }
    }
}
