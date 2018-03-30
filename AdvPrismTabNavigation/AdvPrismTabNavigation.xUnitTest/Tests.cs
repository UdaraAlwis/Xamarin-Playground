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
    public class Tests
    {
        private TestApp _appInstance;

        public Tests()
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
        public void NavigatingFromWithinTabbedPage()
        {
            _appInstance = new TestApp();

            var navigationStack = ((NavigationPage)_appInstance.MainPage).Navigation.NavigationStack;

            // Am I in the HomePage?
            Assert.IsType<HomePageViewModel>(navigationStack.Last().BindingContext);

            // Let's go to Tabbed Page
            _appInstance.Container.Resolve<HomePageViewModel>()
                                        .GoToTabPageCommand.Execute();

            //Resolving MyTabbedPage instance   
            var myTabbedPage = (MyTabbedPage)_appInstance.Container.Resolve<MyTabbedPage>();
            myTabbedPage.SendAppearing();

            //  Am I inside the MyTabbedPage
            Assert.IsType<MyTabbedPageViewModel>(navigationStack.Last().BindingContext);

            //  Am I in the MyTabbedPage-> TabChild1Page?
            Assert.IsType<TabChild1PageViewModel>(myTabbedPage.CurrentPage.BindingContext);

            //  Let's Tab-Navigate to TabChild2Page
            _appInstance.Container.Resolve<TabChild1PageViewModel>()
                        .GoToNextTabCommand.Execute("1");

            ////  Am I in the MyTabbedPage-> TabChild2Page?
            Assert.IsType<TabChild2PageViewModel>(myTabbedPage.CurrentPage.BindingContext);

            //  Let's Tab-Navigate to TabChild3Page
            _appInstance.Container.Resolve<TabChild2PageViewModel>()
                        .GoToNextTabCommand.Execute("2");

            ////  Am I in the MyTabbedPage-> TabChild2Page?
            Assert.IsType<TabChild3PageViewModel>(myTabbedPage.CurrentPage.BindingContext);
        }

        [Fact]
        public void NavigatingFromOutsideTabbedPage()
        {
            _appInstance = new TestApp();

            var navigationStack = ((NavigationPage)_appInstance.MainPage).Navigation.NavigationStack;

            // Let's go to Tabbed Page
            _appInstance.Container.Resolve<HomePageViewModel>()
                                        .GoToTabPageCommand.Execute();

            //Resolving MyTabbedPage instance   
            var myTabbedPage = (MyTabbedPage)_appInstance.Container.Resolve<MyTabbedPage>();
            myTabbedPage.SendAppearing();

            //  Am I inside the MyTabbedPage?
            Assert.IsType<MyTabbedPageViewModel>(navigationStack.Last().BindingContext);

            //  Am I in the MyTabbedPage-> TabChild1Page?
            Assert.IsType<TabChild1PageViewModel>(myTabbedPage.CurrentPage.BindingContext);

            //  Let's go to DetailPage
            _appInstance.Container.Resolve<TabChild1PageViewModel>()
                        .GoToDetailPageCommand.Execute();

            //  Am I inside the DetailPage?
            Assert.IsType<DetailPageViewModel>(navigationStack.Last().BindingContext);

            // Let's go back to Tabbed Page -> TabChild1Page
            _appInstance.Container.Resolve<DetailPageViewModel>()
                                        .GoBackToTabChild3PageCommand.Execute();

            //  Am I inside the MyTabbedPage?
            Assert.IsType<MyTabbedPageViewModel>(navigationStack.Last().BindingContext);

            //  Am I in the MyTabbedPage-> TabChild1Page?
            Assert.IsType<TabChild3PageViewModel>(myTabbedPage.CurrentPage.BindingContext);

            //  Go back to the Homepage manually by user
            _appInstance.Container.Resolve<INavigationService>().GoBackAsync();
            
            //  Am I inside the HomePage?
            Assert.IsType<HomePageViewModel>(navigationStack.Last().BindingContext);
        }
    }
}
