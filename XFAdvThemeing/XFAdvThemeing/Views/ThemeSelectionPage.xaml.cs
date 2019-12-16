using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFAdvThemeing.Models;
using XFAdvThemeing.Themes;

namespace XFAdvThemeing.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThemeSelectionPage : ContentPage
    {
        public ThemeSelectionPage()
        {
            InitializeComponent();
        }

        void OnPickerSelectionChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            Theme theme = (Theme)picker.SelectedItem;

            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();

                switch (theme)
                {
                    case Theme.Dark:
                        mergedDictionaries.Add(new DarkTheme());
                        break;
                    case Theme.Light:
                    default:
                        mergedDictionaries.Add(new LightTheme());
                        break;
                }
                statusLabel.Text = $"{theme.ToString()} theme loaded. Close this page.";
            }
        }

        private async void CloseButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}