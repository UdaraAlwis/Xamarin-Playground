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

        private async void buttonOpenNextPage_OnClicked(object sender, EventArgs e)
	    {
            // show the loading page...
            DependencyService.Get<ILodingPageService>().ShowLoadingPage();

            // just to showcase a delay...
            await Task.Delay(2000);

            // navigate to next page...
	        //await Navigation.PushAsync(new Page2());
            
	        Application.Current.MainPage = new NavigationPage(new Page2());
        }

	    private async void buttonLoadingPageTimer_OnClicked(object sender, EventArgs e)
	    {
	        // show the loading page...
	        DependencyService.Get<ILodingPageService>().ShowLoadingPage();

	        // just to showcase a delay...
	        await Task.Delay(2000);
	        
            // close the loading page...
	        DependencyService.Get<ILodingPageService>().HideLoadingPage();
        }
    }
}
