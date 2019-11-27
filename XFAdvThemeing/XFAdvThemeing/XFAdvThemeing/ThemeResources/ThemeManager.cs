using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Xamarin.Forms;
using XFAdvThemeing.ThemeResources;

namespace XFAdvThemeing.ThemeResources
{
    public class ThemeManager
    {
        /// <summary>
        /// Defines the supported themes for the sample app
        /// </summary>
        public enum Themes
        {
            Light,
            Dark,
            Blue,
            Orange,
            White
        }

        /// <summary>
        /// Changes the theme of the app.
        /// Add additional switch cases for more themes you add to the app.
        /// This also updates the local key storage value for the selected theme.
        /// </summary>
        /// <param name="theme"></param>
        public static void ChangeTheme(Themes theme)
        {
            var mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();

                //Update local key value with the new theme you select.
                CrossSettings.Current.AddOrUpdateValue("SelectedTheme", (int)theme);

                switch (theme)
                {
                    case Themes.Light:
                        {
                            mergedDictionaries.Add(new LightTheme());
                            break;
                        }
                    //case Themes.Dark:
                    //    {
                    //        mergedDictionaries.Add(new DarkTheme());
                    //        break;
                    //    }
                    //case Themes.Blue:
                    //    {
                    //        mergedDictionaries.Add(new BlueTheme());
                    //        break;
                    //    }
                    //case Themes.Orange:
                    //    {
                    //        mergedDictionaries.Add(new OrangeTheme());
                    //        break;
                    //    }
                    //case Themes.White:
                    //    {
                    //        mergedDictionaries.Add(new WhiteTheme());
                    //        break;
                    //    }
                    default:
                        mergedDictionaries.Add(new LightTheme());
                        break;
                }
            }
        }

        /// <summary>
        /// Reads current theme id from the local storage and loads it.
        /// </summary>
        public static void LoadTheme()
        {
            Themes currentTheme = CurrentTheme();
            ChangeTheme(currentTheme);
        }

        /// <summary>
        /// Gives current/last selected theme from the local storage.
        /// </summary>
        /// <returns></returns>
        public static Themes CurrentTheme()
        {
            return (Themes)CrossSettings.Current.GetValueOrDefault("SelectedTheme", (int)Themes.Light);
        }
    }
}
