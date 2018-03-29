using AdvPrismTabNavigation.Interfaces;
using Prism.Commands;
using Prism.Navigation;
using AdvPrismTabNavigation.Views;
using Unity;

namespace AdvPrismTabNavigation.ViewModels
{
    public class TabChild2PageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUnityContainer _unityContainer;

        public DelegateCommand GoToDetailPageCommand { get; set; }

        public DelegateCommand<string> GoToNextTabCommand { get; set; }

        public TabChild2PageViewModel(INavigationService navigationService, IUnityContainer unityContainer)
            : base(navigationService)
        {
            this._navigationService = navigationService;
            this._unityContainer = unityContainer;

            Title = "Tab Child 2";

            GoToDetailPageCommand = new DelegateCommand(GoToDetailPage);

            GoToNextTabCommand = new DelegateCommand<string>((param) => GoToNextTab(int.Parse(param)));
        }

        private async void GoToDetailPage()
        {
            await _navigationService.NavigateAsync(nameof(DetailPage));
        }

        private void GoToNextTab(int tabIndex)
        {
            _unityContainer.Resolve<IMyTabbedPageSelectedTab>().SetSelectedTab(tabIndex);
        }
    }
}
