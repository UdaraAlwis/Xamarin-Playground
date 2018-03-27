using Prism.Commands;
using Prism.Navigation;
using AdvPrismTabNavigation.Views;

namespace AdvPrismTabNavigation.ViewModels
{
    public class TabChild2PageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand GoToDetailPageCommand { get; set; }

        public TabChild2PageViewModel(INavigationService navigationService)
	        : base(navigationService)
        {
            this._navigationService = navigationService;

            Title = "Tab Child 2";

            GoToDetailPageCommand = new DelegateCommand(GoToDetailPage);
        }

        private async void GoToDetailPage()
        {
            await _navigationService.NavigateAsync(nameof(DetailPage));
        }
    }
}
