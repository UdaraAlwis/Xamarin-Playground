using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XFNavBarBackBtnClickOverride
{
    public partial class Page2 : CoolContentPage
    {
        public Page2()
        {
            InitializeComponent();
            
            if (EnableBackButtonOverride)
            {
                this.CustomBackButtonAction = async () =>
                {
                    var result = await this.DisplayAlert(null,
                        "Hey wait now! are you sure you want to go back?",
                        "Yes go back", "Nope");

                    if (result)
                    {
                        await Navigation.PopAsync(true);
                    }
                };
            }
        }
    }
}
