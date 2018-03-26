using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using AdvPrismTabNavigation.Views;
using Prism.Commands;

namespace AdvPrismTabNavigation.ViewModels
{
    public class XPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand ProgramaticallyGoBackCommand { get; set; }

        public XPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            this._navigationService = navigationService;

            ProgramaticallyGoBackCommand = new DelegateCommand(ProgramaticallyGoBack);
        }

        private void ProgramaticallyGoBack()
        {
            NavigationParameters navigationParameters = new NavigationParameters()
            {
                {"selectedTab", nameof(Child1Page)},
            };

            _navigationService.GoBackAsync(navigationParameters);
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }
    }
}
