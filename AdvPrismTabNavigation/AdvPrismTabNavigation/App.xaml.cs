using Prism;
using Prism.Ioc;
using AdvPrismTabNavigation.ViewModels;
using AdvPrismTabNavigation.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using AdvPrismTabNavigation.Interfaces;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AdvPrismTabNavigation
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/HomePage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage>();
            containerRegistry.RegisterForNavigation<MyTabbedPage>();
            containerRegistry.RegisterForNavigation<TabChild1Page>();
            containerRegistry.RegisterForNavigation<TabChild2Page>();
            containerRegistry.RegisterForNavigation<TabChild3Page>();
            containerRegistry.RegisterForNavigation<DetailPage>();

            containerRegistry.Register<IMyTabbedPageSelectedTab, MyTabbedPage>();
        }
    }
}
