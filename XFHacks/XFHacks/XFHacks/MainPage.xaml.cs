using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFHacks
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        void OnButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PickerWithIconPage());
        }

        void OnButtonWithIconClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ButtonWithIconPage());
        }

        void OnEditorWithBorderClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditorWithBorderPage());
        }

        void OnEditorWithPlaceholderClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditorWithPlaceholderPage());
        }

        void OnButtonWithMoreControlClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ButtonWithMoreControlPage());
        }

        void OnShowHidePasswordEntryClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ShowHidePasswordEntryPage());
        }

        void OnFrameWithBorderWidthClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FrameWithBorderWidth());
        }

        void OnLabelwithBorderClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ElementWithBorderPage());
        }
    }
}
