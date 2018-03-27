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
    public class HomePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand GoToTabPageCommand { get; set; }

        public HomePageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            this._navigationService = navigationService;

            Title = "Main Page";

            GoToTabPageCommand = new DelegateCommand(GoToTabPage);
        }

        private async void GoToTabPage()
        {
            await _navigationService.NavigateAsync($"{nameof(MyTabbedPage)}?selectedTab=TabChild3Page");
        }
    }
}
