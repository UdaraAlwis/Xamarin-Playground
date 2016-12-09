using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFCarouselControl
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
        }

        private void Next_OnClicked(object sender, EventArgs e)
        {
            try
            {
                CarouselZoos.Position = CarouselZoos.Position + 1;
            }
            catch (Exception ex)
            {

            }
        }

        private void Previous_OnClicked(object sender, EventArgs e)
        {
            try
            {
                CarouselZoos.Position = CarouselZoos.Position - 1;
            }
            catch (Exception ex)
            {

            }
        }

        public static List<T> ToNonNullList<T>(IEnumerable<T> obj)
        {
            return obj == null ? new List<T>() : obj.ToList();
        }
    }
}
