using System;
using System.Collections.Generic;
using System.Text;

namespace AdvPrismTabNavigation.Interfaces
{
    public interface IMyTabbedPageSelectedTab
    {
        int SelectedTab { get; set; }

        void SetSelectedTab(int tabIndex);
    }
}
