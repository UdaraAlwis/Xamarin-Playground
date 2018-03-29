using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvPrismTabNavigation.ViewModels;
using AdvPrismTabNavigation.Views;
using Prism.Common;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;
using Xunit;

namespace AdvPrismTabNavigation.xUnitTest
{
    public class FirstTest
    {
        private TestApp _appInstance;

        public FirstTest()
        {
            Xamarin.Forms.Mocks.MockForms.Init();
        }

        [Fact]
        public void AppInit()
        {
            _appInstance = new TestApp();

            Assert.NotNull(_appInstance);
        }

        [Fact]
        public void HomePageInit()
        {
            _appInstance = new TestApp();

            //HomePage homePage = new HomePage();
            //ViewModelLocator.SetAutowireViewModel(homePage, true);

            //Assert.NotNull(homePage.BindingContext);
            //Assert.IsType<HomePageViewModel>(homePage.BindingContext);
            
            // Am I in the HomePage?
            Assert.IsType<HomePage>(PageUtilities.GetCurrentPage(_appInstance.MainPage));

            // Let's go to Tabbed Page
            var homePageViewModel = _appInstance.Container.Resolve<HomePageViewModel>();
            homePageViewModel.GoToTabPageCommand.Execute();
            _appInstance.Container.Resolve<MyTabbedPage>().SendAppearing();

            //  Am I in the MyTabbedPage-> TabChild1Page?
            Assert.IsType<TabChild1Page>(PageUtilities.GetCurrentPage(_appInstance.MainPage));

            //  Let's Tab-Navigate to TabChild2Page
            _appInstance.Container.Resolve<TabChild1PageViewModel>().GoToNextTabCommand.Execute("1");

            //  Am I in the MyTabbedPage-> TabChild2Page?
            Assert.IsType<TabChild2Page>(_appInstance.Container.Resolve<MyTabbedPage>().CurrentPage);

            //  Let's Tab-Navigate to TabChild3Page
            _appInstance.Container.Resolve<TabChild2PageViewModel>().GoToNextTabCommand.Execute("2");

            //  Am I in the MyTabbedPage-> TabChild2Page?
            Assert.IsType<TabChild3Page>(_appInstance.Container.Resolve<MyTabbedPage>().CurrentPage);
        }
    }
}
