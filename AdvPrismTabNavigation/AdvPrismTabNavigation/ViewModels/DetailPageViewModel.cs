using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using AdvPrismTabNavigation.Views;
using Prism.Commands;
using Prism;
using Prism.Services;
using AdvPrismTabNavigation.Interfaces;

namespace AdvPrismTabNavigation.ViewModels
{
    public class DetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IDependencyService _dependencyService;

        public DelegateCommand ProgramaticallyGoBackCommand { get; set; }

        public DetailPageViewModel(INavigationService navigationService, IDependencyService dependencyService)
            : base(navigationService)
        {
            this._navigationService = navigationService;
            this._dependencyService = dependencyService;

            Title = "Detail Page";

            ProgramaticallyGoBackCommand = new DelegateCommand(ProgramaticallyGoBack);
        }

        private void ProgramaticallyGoBack()
        {
            var result = _dependencyService.Get<IMyTabbedPageSelectedTab>();

            _navigationService.GoBackAsync();
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
