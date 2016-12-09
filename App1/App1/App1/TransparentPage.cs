using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public class TransparentPage : ContentPage
    {
        public TransparentPage()
        {
            this.BackgroundColor = new Color(0,0,0, 0.4);
        }
    }
}
