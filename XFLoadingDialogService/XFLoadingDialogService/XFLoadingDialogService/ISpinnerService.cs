using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XFLoadingDialogService
{
    public interface ISpinnerService
    {
        void OpenSpinner();

        void CloseSpinner();
    }
}
