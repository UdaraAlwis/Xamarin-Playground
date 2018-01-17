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
	public partial class Page2 : ContentPage
	{
		public Page2 ()
		{
			InitializeComponent ();
		}

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
            
	        Device.StartTimer(TimeSpan.FromSeconds(3), () =>
	        {
	            DependencyService.Get<ILodingPageService>().HideLoadingPage();

	            return false;
	        });
        }
    }
}