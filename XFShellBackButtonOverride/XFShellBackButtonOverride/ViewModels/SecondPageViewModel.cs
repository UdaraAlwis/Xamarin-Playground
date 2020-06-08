using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFShellBackButtonOverride.ViewModels
{
    public class SecondPageViewModel : BaseViewModel
    {
        public Command GoBackCommand { get; set; }

        public Command OnAppearingCommand { get; set; }

        public Command OnDisappearingCommand { get; set; }

        public SecondPageViewModel()
        {
            Title = "Second Page";
            GoBackCommand = new Command(async () => await GoBack());
            OnAppearingCommand = new Command(() => OnAppearing());
            OnDisappearingCommand = new Command(() => OnDisappearing());
        }

        private void OnAppearing()
        {
            Shell.Current.Navigating += Current_Navigating;
        }

        private void OnDisappearing()
        {
            Shell.Current.Navigating -= Current_Navigating;
        }

        private async void Current_Navigating(object sender, ShellNavigatingEventArgs e)
        {
            e.Cancel();
            await GoBack();
        }

        private async Task GoBack()
        {
            var result = await Shell.Current.DisplayAlert(
                "Going Back?", 
                "Are you sure you want to go back?",
                "Ok", "Cancel");

            if (result)
            {
                Shell.Current.Navigating -= Current_Navigating;
                await Shell.Current.GoToAsync("..", true);
            }
        }
    }
}
