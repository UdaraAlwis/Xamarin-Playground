using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace AdvPrismTabNavigation.ViewModels
{
	public class TabTabChild2PageViewModel : ViewModelBase
	{
	    public TabTabChild2PageViewModel(INavigationService navigationService)
	        : base(navigationService)
        {
            Title = "Tab Child 2";
        }
	}
}
