using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XFAdvThemeing.Dependencies;
using XFAdvThemeing.ThemeResources;

namespace XFAdvThemeing.ViewModels
{
    public class ThemeSelectionViewModel : BaseViewModel
    {
        public ThemeSelectionViewModel()
        {
            Title = "Select Theme";

            //Initialize the List with the theme details, you want to add in the app
            Themes = new List<AppTheme>()
            {
                new AppTheme() { ThemeId = ThemeManager.Themes.Light, Title = "Light Theme", Description = "Gives a light theme experience" },
                new AppTheme() { ThemeId = ThemeManager.Themes.Dark, Title = "Dark Theme", Description = "Gives a dark theme experience" },
                //new AppTheme() { ThemeId = ThemeManager.Themes.Blue, Title = "Blue Theme", Description = "Gives a blue theme experience" },
                //new AppTheme() { ThemeId = ThemeManager.Themes.Orange, Title = "Orange Theme", Description = "Gives an orange theme experience" },
                //new AppTheme() { ThemeId = ThemeManager.Themes.White, Title = "White Theme", Description = "Gives a white theme experience" }
            };

            //Find the Current/Last selected theme, and set the IsSelected property for that specific theme item in the list.
            var selectedTheme = Themes.FirstOrDefault(x => x.ThemeId == ThemeManager.CurrentTheme());
            selectedTheme.IsSelected = true;
        }

        List<AppTheme> _themes;
        public List<AppTheme> Themes
        {
            get { return _themes; }
            set { SetProperty(ref _themes, value); }
        }

        AppTheme _selectedTheme;
        public AppTheme SelectedTheme
        {
            get { return _selectedTheme; }
            set
            {
                SetProperty(ref _selectedTheme, value);
                if (value != null) { OnThemeSelected(value); }
            }
        }

        /// <summary>
        /// Invokes when you select any Theme from the ListView
        /// </summary>
        /// <param name="selectedTheme"></param>
        private void OnThemeSelected(AppTheme selectedTheme)
        {
            foreach (var t in Themes)
            {
                t.IsSelected = t.ThemeId == selectedTheme.ThemeId;
            }
            ThemeManager.ChangeTheme(selectedTheme.ThemeId);

            ////For Android we need some Platform specific twicks for Android Toolbar. 
            ////Apply this platform specific change by invoking following DependencyService
            //if (Device.RuntimePlatform == Device.Android)
            //{
            //    DependencyService.Get<INativeServices>().OnThemeChanged(selectedTheme.ThemeId);
            //}
        }
    }
}
