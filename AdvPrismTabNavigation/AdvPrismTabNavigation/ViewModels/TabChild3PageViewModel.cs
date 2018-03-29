using AdvPrismTabNavigation.Interfaces;
using Prism.Commands;
using AdvPrismTabNavigation.Views;
using Prism.Navigation;
using Unity;

namespace AdvPrismTabNavigation.ViewModels
{
    public class TabChild3PageViewModel : ViewModelBase
	{
	    private readonly INavigationService _navigationService;
	    private readonly IUnityContainer _unityContainer;

        public DelegateCommand GoToDetailPageCommand { get; set; }

	    public DelegateCommand<string> GoToNextTabCommand { get; set; }

        public TabChild3PageViewModel(INavigationService navigationService, IUnityContainer unityContainer)
            : base(navigationService)
        {
            this._navigationService = navigationService;
            this._unityContainer = unityContainer;

            Title = "Tab Child 3";

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
