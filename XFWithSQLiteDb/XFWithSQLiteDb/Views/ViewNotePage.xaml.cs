using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFWithSQLiteDb.ViewModels;

namespace XFWithSQLiteDb.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewNotePage : ContentPage
    {
        private readonly ViewNotePageViewModel _viewModel;
        private readonly Guid _noteId;

        public ViewNotePage(Guid noteId)
        {
            InitializeComponent();

            _noteId = noteId;
            BindingContext = _viewModel = new ViewNotePageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.LoadNoteCommand.Execute(_noteId);
        }
    }
}