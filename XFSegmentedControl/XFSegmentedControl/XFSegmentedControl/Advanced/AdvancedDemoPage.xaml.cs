using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFSegmentedControl.Simple;
using XFSegmentedControl.Simple.Controls;

namespace XFSegmentedControl.Advanced
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdvancedDemoPage : ContentPage
	{
		public AdvancedDemoPage()
		{
			InitializeComponent ();
		}

	    private void SegmentedControlV2View_OnSelectedTabIndexChanged(object sender, SelectedTabIndexEventArgs e)
	    {
	        switch (e.SelectedTabIndex)
	        {
	            case 0:
	                ContentView1.IsVisible = true;
	                ContentView2.IsVisible = false;
	                ContentView3.IsVisible = false;
	                ContentView4.IsVisible = false;
                    break;
	            case 1:
	                ContentView1.IsVisible = false;
	                ContentView2.IsVisible = true;
	                ContentView3.IsVisible = false;
	                ContentView4.IsVisible = false;
                    break;
	            case 2:
	                ContentView1.IsVisible = false;
	                ContentView2.IsVisible = false;
	                ContentView3.IsVisible = true;
	                ContentView4.IsVisible = false;
                    break;
	            case 3:
	                ContentView1.IsVisible = false;
	                ContentView2.IsVisible = false;
	                ContentView3.IsVisible = false;
	                ContentView4.IsVisible = true;
                    break;
            }
        }

	    private void MoreDemoButton_OnClicked(object sender, EventArgs e)
	    {
	        Navigation.PushAsync(new MoreDemoPage());
	    }
    }
}