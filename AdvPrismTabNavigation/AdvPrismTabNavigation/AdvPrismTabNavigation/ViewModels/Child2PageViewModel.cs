using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace AdvPrismTabNavigation.ViewModels
{
	public class Child2PageViewModel : ViewModelBase
	{
	    public Child2PageViewModel(INavigationService navigationService)
	        : base(navigationService)
        {
            Title = "Child 2";
        }
	}
}
