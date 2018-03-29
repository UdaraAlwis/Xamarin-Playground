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
        public void NavigatingWithinTabbedPage()
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
            ((TabChild1PageViewModel)(myTabbedPage.Children[0]).BindingContext)
                        .GoToNextTabCommand.Execute("1");

            ////  Am I in the MyTabbedPage-> TabChild2Page?
            Assert.IsType<TabChild2PageViewModel>(myTabbedPage.CurrentPage.BindingContext);

            //  Let's Tab-Navigate to TabChild3Page
            ((TabChild2PageViewModel)(myTabbedPage.Children[1]).BindingContext)
                        .GoToNextTabCommand.Execute("2");

            ////  Am I in the MyTabbedPage-> TabChild2Page?
            Assert.IsType<TabChild3PageViewModel>(myTabbedPage.CurrentPage.BindingContext);
        }

        [Fact]
        public void NavigatingOutOfTabbedPage()
        {
            _appInstance = new TestApp();

            var navigationStack = ((NavigationPage)_appInstance.MainPage).Navigation.NavigationStack;

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
            ((TabChild1PageViewModel)myTabbedPage.CurrentPage.BindingContext)
                        .GoToDetailPageCommand.Execute();

            //  Am I inside the MyTabbedPage
            Assert.IsType<DetailPageViewModel>(navigationStack.Last().BindingContext);
        }
    }
}
