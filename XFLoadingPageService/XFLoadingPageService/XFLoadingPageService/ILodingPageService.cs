using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XFLoadingPageService
{
    public interface ILodingPageService
    {
        void ShowLoadingPage(ContentPage loadingIndicatorPage = null);

        void HideLoadingPage();
    }
}
