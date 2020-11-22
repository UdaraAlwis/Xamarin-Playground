using Bogus;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFWithSQLiteDb.Models;
using XFWithSQLiteDb.Services;

namespace XFWithSQLiteDb.ViewModels
{
    public class NewNotePageViewModel : BaseViewModel
    {
        public Note Note { get; set; }
        public Command SaveNoteCommand { get; set; }

        public NewNotePageViewModel()
        {
            Title = "Notes";

            Note = new Note();
            Note.NoteTitle = new Faker().Lorem.Sentence();
            Note.NoteText = new Faker().Lorem.Sentence();
            SaveNoteCommand = new Command(async () => await SaveNote());
        }

        private async Task SaveNote()
        {
            if (string.IsNullOrWhiteSpace(Note.NoteTitle) ||
                string.IsNullOrWhiteSpace(Note.NoteText))
                return;

            IsBusy = true;

            try
            {
                await Task.Delay(new Random().Next(1000, 2000));

                Note.NoteId = Guid.NewGuid();
                Note.NoteTimeStamp = DateTime.Now;
                await DatabaseService.SaveNote(Note);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;

                await Application.Current.MainPage.Navigation.PopModalAsync();
            }
        }
    }
}
