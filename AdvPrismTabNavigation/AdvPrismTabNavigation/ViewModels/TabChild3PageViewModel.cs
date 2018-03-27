using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using AdvPrismTabNavigation.Views;
using Prism.Navigation;

namespace AdvPrismTabNavigation.ViewModels
{
	public class TabChild3PageViewModel : ViewModelBase
	{
	    private readonly INavigationService _navigationService;

	    public DelegateCommand GoToDetailPageCommand { get; set; }

        public TabChild3PageViewModel(INavigationService navigationService)
	        : base(navigationService)
        {
            _navigationService = navigationService;

            Title = "Tab Child 3";

            GoToDetailPageCommand = new DelegateCommand(GoToDetailPage);
        }

	    private async void GoToDetailPage()
	    {
	        await _navigationService.NavigateAsync(nameof(DetailPage));
	    }
    }
}
