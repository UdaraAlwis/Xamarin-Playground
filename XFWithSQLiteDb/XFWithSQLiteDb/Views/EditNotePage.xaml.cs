using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFWithSQLiteDb.ViewModels;

namespace XFWithSQLiteDb.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditNotePage : ContentPage
    {
        private readonly EditNotePageViewModel _viewModel;
        private readonly Guid _noteId;

        public EditNotePage(Guid noteId)
        {
            InitializeComponent();

            _noteId = noteId;
            BindingContext = _viewModel = new EditNotePageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.LoadNoteCommand.Execute(_noteId);
        }
    }
}