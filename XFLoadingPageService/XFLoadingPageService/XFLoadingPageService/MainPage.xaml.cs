using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFLoadingPageService
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
        }

	    private async void ButtonOpenSpinner_OnClicked(object sender, EventArgs e)
	    {
	        DependencyService.Get<ILodingPageService>().ShowLoadingPage();

            await Task.Delay(2000);

	        await Navigation.PushAsync(new Page1());
	    }
	}
}
