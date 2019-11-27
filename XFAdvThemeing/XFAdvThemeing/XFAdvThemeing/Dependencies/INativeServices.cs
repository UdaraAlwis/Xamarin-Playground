using System;
using System.Collections.Generic;
using System.Text;
using XFAdvThemeing.ThemeResources;

namespace XFAdvThemeing.Dependencies
{
    public interface INativeServices
    {
        void OnThemeChanged(ThemeManager.Themes theme);
    }
}
