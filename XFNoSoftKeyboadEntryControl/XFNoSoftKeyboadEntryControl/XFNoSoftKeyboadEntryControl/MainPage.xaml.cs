using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFNoSoftKeyboadEntryControl
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            SoftkeyboardDisabledEntry.Text += ((Button) sender).Text;
        }

        private void ButtonClear_OnClicked(object sender, EventArgs e)
        {
            SoftkeyboardDisabledEntry.Text = "";
        }
    }
}
