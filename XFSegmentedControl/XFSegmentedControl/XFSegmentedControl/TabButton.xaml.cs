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
	public partial class TabButton : Grid
	{
		public TabButton ()
		{
			InitializeComponent ();
		}

        private void TabButton_OnClicked(object sender, EventArgs e)
        {

        }
    }
}