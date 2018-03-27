using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvPrismTabNavigation.ViewModels
{
	public class MyTabbedPageViewModel : ViewModelBase
    {
        public MyTabbedPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "My Tabbed Page";
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("selectedTab"))
            {
                
            }
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
        }
    }
}
