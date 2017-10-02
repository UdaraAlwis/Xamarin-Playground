using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UdaraMyNotesApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
	    private ObservableCollection<MyNote> _myNotesList;

	    private IMobileServiceTable<MyNote> _myNotesTable;

        public MainPage ()
		{
			InitializeComponent();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await RefreshItems();
        }
        
	    private async void SaveButton_OnClicked(object sender, EventArgs e)
	    {
	        if (!string.IsNullOrWhiteSpace(titleText.Text) && !string.IsNullOrWhiteSpace(descriptionText.Text))
	        {
	            var newNote = new MyNote()
	            {
	                TimeStamp = DateTime.Now,
	                Title = titleText.Text,
	                Description = descriptionText.Text,
	            };

	            titleText.Text = string.Empty;
	            descriptionText.Text = string.Empty;

	            await _myNotesTable.InsertAsync(newNote);

	            await RefreshItems();
	        }
	    }
        
	    private async Task RefreshItems()
	    {
	        _myNotesTable = App.MobileService.GetTable<MyNote>();

	        IEnumerable<MyNote> items = await _myNotesTable.ToEnumerableAsync();
	        _myNotesList = new ObservableCollection<MyNote>(items);
	        listView.ItemsSource = _myNotesList;

	        listView.IsRefreshing = false;
	    }

	    private async void listView_OnRefreshing(object sender, EventArgs e)
	    {
	        await RefreshItems();
        }

	    private async void OnDelete(object sender, EventArgs e)
	    {
	        var mi = ((MenuItem)sender);
	        var noteToDelete =  (MyNote)mi.CommandParameter;
            
	        await _myNotesTable.DeleteAsync(noteToDelete);

	        await RefreshItems();
        }
    }
}