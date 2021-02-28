using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFSimpleDiDemo.Views;

namespace XFSimpleDiDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = Startup.ServiceProvider.GetService<MainPage>();
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
