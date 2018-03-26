using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using AdvPrismTabNavigation.Views;
using Prism.Navigation;

namespace AdvPrismTabNavigation.ViewModels
{
	public class Child3PageViewModel : ViewModelBase
	{
	    private readonly INavigationService _navigationService;
	    public DelegateCommand GoToXPageCommand { get; set; }

        public Child3PageViewModel(INavigationService navigationService)
	        : base(navigationService)
        {
            _navigationService = navigationService;
            Title = "Child 3";

            GoToXPageCommand = new DelegateCommand(GoToXPage);
        }

	    private async void GoToXPage()
	    {
	        await _navigationService.NavigateAsync(nameof(XPage));
	    }
    }
}
