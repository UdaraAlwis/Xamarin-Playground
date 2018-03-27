using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using AdvPrismTabNavigation.Views;
using Prism.Navigation;

namespace AdvPrismTabNavigation.ViewModels
{
	public class TabTabChild3PageViewModel : ViewModelBase
	{
	    private readonly INavigationService _navigationService;

	    public DelegateCommand GoToExtraPageCommand { get; set; }

        public TabTabChild3PageViewModel(INavigationService navigationService)
	        : base(navigationService)
        {
            _navigationService = navigationService;
            Title = "Tab Child 3";

            GoToExtraPageCommand = new DelegateCommand(GoToExtraPage);
        }

	    private async void GoToExtraPage()
	    {
	        await _navigationService.NavigateAsync(nameof(ExtraPage));
	    }
    }
}
