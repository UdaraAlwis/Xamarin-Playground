using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSegmentedControl.Simple
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void SegmentedControlView_SelectedTabIndexChanged(object sender, SelectedTabIndexEventArgs e)
        {
            if (e.SelectedTabIndex == 0)
            {
                ContentView1.IsVisible = true;
                ContentView2.IsVisible = false;
            }
            if (e.SelectedTabIndex == 1)
            {
                ContentView1.IsVisible = false;
                ContentView2.IsVisible = true;
            }
        }
    }
}
