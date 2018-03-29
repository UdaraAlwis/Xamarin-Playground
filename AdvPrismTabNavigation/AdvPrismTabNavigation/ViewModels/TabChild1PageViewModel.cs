using AdvPrismTabNavigation.Interfaces;
using Prism.Commands;
using Prism.Navigation;
using AdvPrismTabNavigation.Views;
using Unity;

namespace AdvPrismTabNavigation.ViewModels
{
    public class TabChild1PageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUnityContainer _unityContainer;

        public DelegateCommand GoToDetailPageCommand { get; set; }

        public DelegateCommand<object> GoToNextTabCommand { get; set; }

        public TabChild1PageViewModel(INavigationService navigationService, IUnityContainer unityContainer)
            : base(navigationService)
        {
            this._navigationService = navigationService;
            this._unityContainer = unityContainer;

            Title = "Tab Child 1";
            
            GoToDetailPageCommand = new DelegateCommand(GoToDetailPage);

            GoToNextTabCommand = new DelegateCommand<object>((param) => GoToNextTab(int.Parse(param.ToString())));
        }

        private async void GoToDetailPage()
        {
            await _navigationService.NavigateAsync(nameof(DetailPage));
        }

        private void GoToNextTab(int? tabIndex)
        {
            if (tabIndex !=null)
            {
                _unityContainer.Resolve<IMyTabbedPageSelectedTab>().SetSelectedTab(tabIndex.Value);
            }
        }
    }
}
