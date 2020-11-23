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
        public Command GoBackCommand { get; set; }

        public NewNotePageViewModel()
        {
            Title = "New Note Page";

            Note = new Note();
            Note.NoteTitle = new Faker().Lorem.Sentence();
            Note.NoteText = new Faker().Lorem.Sentence(new Random().Next(10, 50));
            SaveNoteCommand = new Command(async () => await SaveNote());
            GoBackCommand = new Command(async () => await GoBack());
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

        private async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
