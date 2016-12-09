using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemystifyXFNav
{
    public class NativeNavigationArgs
    {
        public Page Page { get; private set; }

        public NativeNavigationArgs(Page page)
        {
            Page = page;
        }
    }
}
