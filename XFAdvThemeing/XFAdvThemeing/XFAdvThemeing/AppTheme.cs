using System;
using System.Collections.Generic;
using System.Text;
using XFAdvThemeing.ThemeResources;
using XFAdvThemeing.ViewModels;

namespace XFAdvThemeing
{
    public class AppTheme : ObservableObject
    {
        public ThemeManager.Themes ThemeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        bool _isSelected = false;
        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }
    }
}
