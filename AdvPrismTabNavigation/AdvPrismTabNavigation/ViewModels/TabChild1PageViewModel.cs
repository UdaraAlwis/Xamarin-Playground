using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace AdvPrismTabNavigation.ViewModels
{
	public class TabChild1PageViewModel : ViewModelBase
	{
        public TabChild1PageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Tab Child 1";
        }
    }
}
