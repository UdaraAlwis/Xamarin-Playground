using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFControlTemplateThemes
{
    public partial class MainPage : ContentPage
    {
        public static readonly BindableProperty ThemeColorProperty =
            BindableProperty.Create("ThemeColor", typeof(Color), typeof(MainPage), Color.Red);
        /// <summary>
        /// Gets or Sets the theme color for the template
        /// </summary>
        public Color ThemeColor
        {
            set { SetValue(ThemeColorProperty, value); }
            get { return (Color)GetValue(ThemeColorProperty); }
        }

        private bool _originalTemplate = true;
        private ControlTemplate _myTemplate1;
        private ControlTemplate _myTemplate2;

        public MainPage()
        {
            InitializeComponent();

            _myTemplate1 = (ControlTemplate)Application.Current.Resources["MyTemplate1"];
            _myTemplate2 = (ControlTemplate)Application.Current.Resources["MyTemplate2"];
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            // switching to the next theme
            _originalTemplate = !_originalTemplate;
            contentView.ControlTemplate = (_originalTemplate) ? _myTemplate1 : _myTemplate2;
        }

        private void OnColorChangeButtonClicked(object sender, EventArgs e)
        {
            if (((Button)sender) != null)
            {
                var sender1 = ((Button)sender);

                // Change the theme color according 
                // to the selected button color
                ThemeColor = sender1.BackgroundColor;

                // this will update the ThemeColor property
                // and reflect to the Control template
            }
        }
    }
}
