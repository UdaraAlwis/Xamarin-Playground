using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFWithSQLiteDb.Models;
using XFWithSQLiteDb.Services;

namespace XFWithSQLiteDb.ViewModels
{
    public class EditNotePageViewModel : BaseViewModel
    {
        private Note _note;
        public Note Note
        {
            get => _note;
            set => SetProperty(ref _note, value);
        }

        public Command<Guid> LoadNoteCommand { get; set; }
        public Command UpdateNoteCommand { get; set; }
        public Command GoBackCommand { get; set; }

        public EditNotePageViewModel()
        {
            Title = "Edit Note Page";

            Note = new Note();

            LoadNoteCommand = new Command<Guid>(async (noteId) => await LoadNote(noteId));
            UpdateNoteCommand = new Command(async () => await UpdateNote());
            GoBackCommand = new Command(async () => await GoBack());
        }

        private async Task LoadNote(Guid noteId)
        {
            Note = await DatabaseService.GetNote(noteId);
        }

        private async Task UpdateNote()
        {
            if (string.IsNullOrWhiteSpace(Note.NoteTitle) ||
                string.IsNullOrWhiteSpace(Note.NoteText))
                return;

            IsBusy = true;

            await Task.Delay(new Random().Next(1000, 2000));
            Note.NoteTimeStamp = DateTime.Now;
            await DatabaseService.UpdateNote(Note);
        
            IsBusy = false;

            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        private async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
