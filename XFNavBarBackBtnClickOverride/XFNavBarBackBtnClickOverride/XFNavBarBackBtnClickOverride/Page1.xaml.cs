using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFNavBarBackBtnClickOverride
{
    public partial class Page1 : CoolContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void OpenPageButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page2());
        }
    }
}
