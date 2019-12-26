using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ThemePicker.ItemsSource = Enum.GetValues(typeof(Theme));

            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries.Count > 0)
            {
                var currentTheme = mergedDictionaries.First().GetType();

                if (currentTheme.FullName != null && currentTheme.FullName.Equals(typeof(LightTheme).FullName))
                {
                    ThemePicker.SelectedIndex = 0;
                }
                else
                if (currentTheme.FullName != null && currentTheme.FullName.Equals(typeof(DarkTheme).FullName))
                {
                    ThemePicker.SelectedIndex = 1;
                }
                else
                if (currentTheme.FullName != null && currentTheme.FullName.Equals(typeof(PinkTheme).FullName))
                {
                    ThemePicker.SelectedIndex = 2;
                }
                else
                if (currentTheme.FullName != null && currentTheme.FullName.Equals(typeof(GoldTheme).FullName))
                {
                    ThemePicker.SelectedIndex = 3;
                }

                if (ThemePicker.SelectedItem != null)
                    statusLabel.Text = $"Currently, {ThemePicker.SelectedItem.ToString()} theme loaded.";
            }
        }

        void OnPickerSelectionChanged(object sender, EventArgs e)
        {
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();

                // parsing selected theme value
                if (Enum.TryParse(ThemePicker.SelectedItem.ToString(), out Theme currentThemeEnum))
                {
                    // setting up theme
                    if (ThemeHelper.SetAppTheme(currentThemeEnum))
                    {
                        // Theme setting successful
                        statusLabel.Text = $"{ThemePicker.SelectedItem.ToString()} theme loaded. Close this page.";
                        Preferences.Set("CurrentAppTheme", ThemePicker.SelectedItem.ToString());
                    }
                }

            }
        }

        private async void CloseButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}