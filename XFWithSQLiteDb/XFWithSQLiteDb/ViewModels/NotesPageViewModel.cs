using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFWithSQLiteDb.Models;
using XFWithSQLiteDb.Services;
using XFWithSQLiteDb.Views;

namespace XFWithSQLiteDb.ViewModels
{
    public class NotesPageViewModel : BaseViewModel
    {
        public ObservableCollection<Note> NotesList { get; set; }
        public Command LoadNotesCommand { get; set; }
        public Command NewNoteCommand { get; set; }
        public Command<Note> ViewNoteCommand { get; set; }
        public Command<Note> DeleteNoteCommand { get; set; }

        public NotesPageViewModel()
        {
            Title = "Notes";

            NotesList = new ObservableCollection<Note>();

            LoadNotesCommand = new Command(async () => await LoadNotes());
            NewNoteCommand = new Command(async () => await NewNote());
            ViewNoteCommand = new Command<Note>(async (note) => await ViewNote(note));
            DeleteNoteCommand = new Command<Note>(async (note) => await DeleteNote(note));
        }

        private async Task NewNote()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new NewNotePage());
        }

        private async Task ViewNote(Note note)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ViewNotePage(note.NoteId));
        }

        private async Task LoadNotes()
        {
            IsBusy = true;

            await Task.Delay(new Random().Next(1000, 2000));

            NotesList.Clear();

            var items = await DatabaseService.GetAllNotes();
            foreach (var item in items)
            {
                NotesList.Add(item);
            }

            IsBusy = false;
        }

        private async Task DeleteNote(Note note)
        {
            await DatabaseService.DeleteNote(note);

            await LoadNotes();
        }
    }
}
