using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFWithSQLiteDb.Models;
using XFWithSQLiteDb.Services;
using XFWithSQLiteDb.Views;

namespace XFWithSQLiteDb.ViewModels
{
    public class ViewNotePageViewModel : BaseViewModel
    {
        private Note _note;
        public Note Note
        {
            get => _note;
            set => SetProperty(ref _note, value);
        }

        public Command<Guid> LoadNoteCommand { get; set; }
        public Command EditNoteCommand { get; set; }
        public Command GoBackCommand { get; set; }

        public ViewNotePageViewModel()
        {
            Title = "View Note Page";

            Note = new Note();

            LoadNoteCommand = new Command<Guid>(async (noteId) => await LoadNote(noteId));
            EditNoteCommand = new Command(async () => await EditNote());
            GoBackCommand = new Command(async () => await GoBack());
        }

        private async Task LoadNote(Guid noteId)
        {
            Note = await DatabaseService.GetNote(noteId);
        }

        private async Task EditNote()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new EditNotePage(Note.NoteId));
        }

        private async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
