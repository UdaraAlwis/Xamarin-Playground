using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFHacks
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShowHidePasswordEntryPage : ContentPage
	{
		public ShowHidePasswordEntryPage ()
		{
			InitializeComponent ();
		}

	    private void ShowPasswordButton_OnClicked(object sender, EventArgs e)
	    {
	        EntryPassword.IsVisible = !EntryPassword.IsVisible;
	        EntryText.IsVisible = !EntryText.IsVisible;

            if (EntryPassword.IsVisible)
                ShowPasswordButtonIcon.Source = ImageSource.FromResource("XFHacks.Resources.showpasswordicon.png", Assembly.GetExecutingAssembly());
            else
                ShowPasswordButtonIcon.Source = ImageSource.FromResource("XFHacks.Resources.hidepasswordicon.png", Assembly.GetExecutingAssembly());
        }
	}
}