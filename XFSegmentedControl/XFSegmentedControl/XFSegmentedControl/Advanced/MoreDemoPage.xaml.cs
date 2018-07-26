using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSegmentedControl.Advanced
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MoreDemoPage : ContentPage
	{
	    private ObservableCollection<string> _tabSource;

		public MoreDemoPage ()
		{
			InitializeComponent ();

		    _tabSource = new ObservableCollection<string>()
		    {
                "Tab 1",
		        "Tab 2",
		        "Tab 3",
		        "Tab 4",
		        "Tab 5",
            };

		    AdvSegmentedControl.TabButtonsSource = _tabSource;
        }

	    private void AddTabButton_OnClicked(object sender, EventArgs e)
	    {
	        _tabSource.Add($"Tab {_tabSource.Count + 1}");

	        AdvSegmentedControl.TabButtonsSource = new ObservableCollection<string>(_tabSource);
	    }

	    private void RemoveTabButton_OnClicked(object sender, EventArgs e)
	    {
	        if (_tabSource.Count > 0)
    	        _tabSource.Remove(_tabSource.Last());

	        AdvSegmentedControl.TabButtonsSource = new ObservableCollection<string>(_tabSource);
        }

	    private void PrimaryColorButton_OnClicked(object sender, EventArgs e)
	    {
	        AdvSegmentedControl.PrimaryColor = ((Button) sender).BackgroundColor;
        }

	    private void SecondaryColorButton_OnClicked(object sender, EventArgs e)
	    {
	        AdvSegmentedControl.SecondaryColor = ((Button)sender).BackgroundColor;
        }
	}
}