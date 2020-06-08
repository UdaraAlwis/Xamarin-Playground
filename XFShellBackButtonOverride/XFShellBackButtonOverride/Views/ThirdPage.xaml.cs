using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFShellBackButtonOverride.ViewModels;

namespace XFShellBackButtonOverride.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThirdPage : ContentPage
    {
        public ThirdPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (this.BindingContext != null)
            {
                if (((ThirdPageViewModel)this.BindingContext).OnAppearingCommand.CanExecute(null))
                {
                    ((ThirdPageViewModel)this.BindingContext).OnAppearingCommand.Execute(null);
                }
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (this.BindingContext != null)
            {
                if (((ThirdPageViewModel)this.BindingContext).OnDisappearingCommand.CanExecute(null))
                {
                    ((ThirdPageViewModel)this.BindingContext).OnDisappearingCommand.Execute(null);
                }
            }
        }
    }
}