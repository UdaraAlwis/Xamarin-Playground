using Xamarin.Forms;
using XFSimpleDiDemo.ViewModel;

namespace XFSimpleDiDemo.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel mainPageViewModel = null)
        {
            InitializeComponent();
            this.BindingContext = mainPageViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((MainPageViewModel)this.BindingContext).DoIt();
        }
    }
}
