using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XFHacks.Triggers
{
    /// <summary>
    /// A simple trigger to change a View's visibility dynamically
    /// </summary>
    public class VisibilityTriggerAction : TriggerAction<View>
    {
        public bool IsViewVisible { get; set; }

        protected override void Invoke(View sender)
        {
            sender.IsVisible = IsViewVisible;
        }
    }
}
