using AdvPrismTabNavigation.Interfaces;
using Unity;
using Xamarin.Forms;
using Prism.Unity;
using System;
using System.Runtime.CompilerServices;
using Prism.Navigation;

namespace AdvPrismTabNavigation.Views
{
    public partial class MyTabbedPage : TabbedPage, IMyTabbedPageSelectedTab, IDestructible
    {
        private readonly IUnityContainer _container;
        private int _selectedTab = 0;
        private bool _isTabPageVisible;

        public MyTabbedPage(IUnityContainer container)
        {
            InitializeComponent();

            this._container = container;
            this._container.RegisterInstance<IMyTabbedPageSelectedTab>(this);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _isTabPageVisible = true;

            this.CurrentPage = this.Children[_selectedTab];
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            _isTabPageVisible = false;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();

            _selectedTab = this.Children.IndexOf(this.CurrentPage);
        }

        public void SetSelectedTab(int tabIndex)
        {
            _selectedTab = tabIndex;

            if (_isTabPageVisible)
            {
                this.CurrentPage = this.Children[_selectedTab];
            }
        }

        public void Destroy()
        {
            _isTabPageVisible = false;

            this._container.RegisterInstance<IMyTabbedPageSelectedTab>(null);
        }
    }
}
