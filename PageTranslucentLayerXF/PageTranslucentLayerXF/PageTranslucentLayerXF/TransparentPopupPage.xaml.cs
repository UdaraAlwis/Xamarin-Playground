using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PageTranslucentLayerXF
{
    public partial class TransparentPopupPage : TransparentPage
    {
        public TransparentPopupPage()
        {
            InitializeComponent();

            // Setting the Default background Translucency level
            this.BackgroundColor = new Color(0, 0, 0, 0.4);
        }
    }
}
