using AdvPrismTabNavigation.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvPrismTabNavigation.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        DelegateCommand GoToTabPageCommand;

        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            this._navigationService = navigationService;

            Title = "Main Page";

            GoToTabPageCommand = new DelegateCommand(GoToTabPage);
        }

        private async void GoToTabPage()
        {
            await _navigationService.NavigateAsync(nameof(TabbedPage1));
        }
    }
}
