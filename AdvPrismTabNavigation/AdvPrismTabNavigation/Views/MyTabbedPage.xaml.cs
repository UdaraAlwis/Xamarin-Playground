using AdvPrismTabNavigation.Interfaces;
using Unity;
using Xamarin.Forms;
using Prism.Unity;
using System;
using System.Runtime.CompilerServices;
using Prism.Navigation;
using Xamarin.Forms.Xaml;

namespace AdvPrismTabNavigation.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyTabbedPage : TabbedPage
    {
        private bool _isTabPageVisible;

        public static readonly BindableProperty SelectedTabIndexProperty =
            BindableProperty.Create(
                nameof(SelectedTabIndex), 
                typeof(int),
                typeof(MyTabbedPage), 0,
                BindingMode.TwoWay, null,
                propertyChanged: OnSelectedTabIndexChanged);
        static void OnSelectedTabIndexChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (((MyTabbedPage)bindable)._isTabPageVisible)
            {
                ((MyTabbedPage)bindable).CurrentPage = ((MyTabbedPage)bindable).Children[(int)newValue];
            }
        }
        public int SelectedTabIndex
        {
            get { return (int)GetValue(SelectedTabIndexProperty); }
            set { SetValue(SelectedTabIndexProperty, value); }
        }

        public MyTabbedPage()
        {
            InitializeComponent();
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();

            _isTabPageVisible = true;

            this.CurrentPage = this.Children[SelectedTabIndex];
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            _isTabPageVisible = false;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();

            SelectedTabIndex = this.Children.IndexOf(this.CurrentPage);
        }
    }
}
