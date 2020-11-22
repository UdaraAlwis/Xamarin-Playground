using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

        public NotesPageViewModel()
        {
            Title = "Notes";

            NotesList = new ObservableCollection<Note>();

            LoadNotesCommand = new Command(async () => await LoadNotes());
            NewNoteCommand = new Command(async () => await NewNote());
        }

        private async Task NewNote()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new NewNotePage());
        }

        private async Task LoadNotes()
        {
            IsBusy = true;

            try
            {
                NotesList.Clear();

                await Task.Delay(new Random().Next(1000, 2000));

                var items = await DatabaseService.GetAllNotes();
                foreach (var item in items)
                {
                    NotesList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
