using System.Threading.Tasks;
using Xamarin.Forms;
using XFShellBackButtonOverride.Views;

namespace XFShellBackButtonOverride.ViewModels
{
    public class FirstPageViewModel : BaseViewModel
    {
        public Command GoBackCommand { get; set; }

        public FirstPageViewModel()
        {
            Title = "First Page";
            GoBackCommand = new Command(async () => await GoBack());
        }

        private async Task GoBack()
        {
            var result = await Shell.Current.DisplayAlert(
                "Going Back?",
                "Are you sure you want to go back?",
                "Yes, Please!", "Nope!");

            if (result)
            {
                await Shell.Current.GoToAsync("..", true);
            }
        }
    }
}
