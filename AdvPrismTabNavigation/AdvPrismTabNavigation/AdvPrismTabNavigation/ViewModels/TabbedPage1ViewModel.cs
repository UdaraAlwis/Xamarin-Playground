using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvPrismTabNavigation.ViewModels
{
	public class TabbedPage1ViewModel : ViewModelBase
    {
        public TabbedPage1ViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }
	}
}
