using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFShellBackButtonOverride.ViewModels;

namespace XFShellBackButtonOverride.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (this.BindingContext != null)
            {
                if (((SecondPageViewModel)this.BindingContext).OnAppearingCommand.CanExecute(null))
                {
                    ((SecondPageViewModel)this.BindingContext).OnAppearingCommand.Execute(null);
                }
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (this.BindingContext != null)
            {
                if (((SecondPageViewModel)this.BindingContext).OnDisappearingCommand.CanExecute(null))
                {
                    ((SecondPageViewModel)this.BindingContext).OnDisappearingCommand.Execute(null);
                }
            }
        }
    }
}