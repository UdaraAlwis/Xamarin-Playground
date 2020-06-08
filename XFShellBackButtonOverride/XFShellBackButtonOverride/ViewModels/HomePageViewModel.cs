using System.Threading.Tasks;
using Xamarin.Forms;
using XFShellBackButtonOverride.Views;

namespace XFShellBackButtonOverride.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public Command GoToFirstPageCommand { get; set; }

        public Command GoToSecondPageCommand { get; set; }

        public HomePageViewModel()
        {
            Title = "Home Page";
            GoToFirstPageCommand = new Command(async () => await GoToFirstPage());
            GoToSecondPageCommand = new Command(async () => await GoToSecondPage());
        }

        private async Task GoToFirstPage()
        {
            await Shell.Current.GoToAsync(nameof(FirstPage));
        }

        private async Task GoToSecondPage()
        {
            await Shell.Current.GoToAsync(nameof(SecondPage));
        }
    }
}
