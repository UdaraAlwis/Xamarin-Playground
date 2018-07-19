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
	}
}