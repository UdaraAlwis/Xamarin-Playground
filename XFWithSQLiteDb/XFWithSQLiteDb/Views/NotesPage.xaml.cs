using Xamarin.Forms;
using XFWithSQLiteDb.ViewModels;

namespace XFWithSQLiteDb.Views
{
    public partial class NotesPage : ContentPage
    {
        private readonly NotesPageViewModel _viewModel;

        public NotesPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new NotesPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.IsBusy = true;
        }
    }
}
