using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XFShellAppTryOut.Views;

namespace XFShellAppTryOut
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("itemdetailpage", typeof(ItemDetailPage));
        }
    }
}
