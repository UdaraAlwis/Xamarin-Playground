using AdvPrismTabNavigation.Interfaces;
using Xamarin.Forms;

namespace AdvPrismTabNavigation.Views
{
    public partial class MyTabbedPage : TabbedPage, IMyTabbedPageSelectedTab
    {
        private int _selectedTab = 0;

        public MyTabbedPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.CurrentPage = this.Children[_selectedTab];
        }

        public void SetSelectedTab(int tabIndex)
        {
            _selectedTab = tabIndex;
        }
    }
}
