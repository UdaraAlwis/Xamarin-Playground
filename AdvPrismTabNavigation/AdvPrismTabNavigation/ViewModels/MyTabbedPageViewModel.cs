using AdvPrismTabNavigation.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity;
using Unity.Lifetime;

namespace AdvPrismTabNavigation.ViewModels
{
    public class MyTabbedPageViewModel : ViewModelBase, IMyTabbedPageSelectedTab
    {
        private readonly IUnityContainer _unityContainer;

        private int _selectedTab;
        public int SelectedTab
        {
            get { return _selectedTab; }
            set
            {
                SetProperty(ref _selectedTab, value);
                Title = $"My Tabbed Page - Tab [{SelectedTab + 1}]";
            }
        }
        
        public MyTabbedPageViewModel(INavigationService navigationService, IUnityContainer unityContainer)
            : base(navigationService)
        {
            Title = $"My Tabbed Page - Tab [{SelectedTab + 1}]";

            this._unityContainer = unityContainer;

            _unityContainer.RegisterInstance<IMyTabbedPageSelectedTab>(this, new ContainerControlledLifetimeManager());
        }

        public void SetSelectedTab(int tabIndex)
        {
            SelectedTab = tabIndex;
        }
    }
}
