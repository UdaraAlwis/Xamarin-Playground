using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSegmentedControl
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SegmentedControl : ContentView
	{
		public SegmentedControl ()
		{
			InitializeComponent ();

            SelectTab1();
        }

	    private void Tab1Button_OnClicked(object sender, EventArgs e)
	    {
            SelectTab1();
        }

        private void Tab2Button_OnClicked(object sender, EventArgs e)
        {
            SelectTab2();
        }

        private void SelectTab1()
        {
            Tab1BoxView.IsVisible = true;
            Tab2BoxView.IsVisible = false;
        }

        private void SelectTab2()
        {
            Tab1BoxView.IsVisible = false;
            Tab2BoxView.IsVisible = true;
        }
    }
}