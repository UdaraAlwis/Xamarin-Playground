using Prism.Commands;
using Prism.Navigation;
using AdvPrismTabNavigation.Views;

namespace AdvPrismTabNavigation.ViewModels
{
    public class TabChild1PageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand GoToDetailPageCommand { get; set; }

        public TabChild1PageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            this._navigationService = navigationService;

            Title = "Tab Child 1";
            
            GoToDetailPageCommand = new DelegateCommand(GoToDetailPage);
        }

        private async void GoToDetailPage()
        {
            await _navigationService.NavigateAsync(nameof(DetailPage));
        }
    }
}
