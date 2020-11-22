
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFWithSQLiteDb.ViewModels;

namespace XFWithSQLiteDb.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewNotePage : ContentPage
    {
        readonly NewNotePageViewModel _viewModel;

        public NewNotePage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new NewNotePageViewModel();
        }
    }
}