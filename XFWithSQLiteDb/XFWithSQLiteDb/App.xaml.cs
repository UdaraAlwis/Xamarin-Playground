using Xamarin.Forms;
using XFWithSQLiteDb.Views;

namespace XFWithSQLiteDb
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Device.SetFlags(new string[] { "SwipeView_Experimental" });

            MainPage = new NotesPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
