using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MultiSelectListViewControl
{
    /// <summary>
    /// Clear the SelectedItem value
    /// </summary>
    public class ListViewItemSelectedTriggerAction : TriggerAction<ListView>
    {
        protected override void Invoke(ListView entry)
        {
            entry.SelectedItem = null;
        }
    }
}
