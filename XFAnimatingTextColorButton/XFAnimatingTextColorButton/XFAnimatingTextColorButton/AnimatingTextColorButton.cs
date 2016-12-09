using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFAnimatingTextColorButton
{
    public class AnimatingTextColorButton : Button
    {
        /// <summary>
        /// Property for handling Text Color changing animation
        /// </summary>
        public static readonly BindableProperty IsTextColorAnimatingProperty =
            BindableProperty.Create(
                nameof(IsTextColorAnimating),
                typeof(bool),
                typeof(AnimatingTextColorButton),
                false);
        public bool IsTextColorAnimating
        {
            get { return (bool)GetValue(IsTextColorAnimatingProperty); }
            set { SetValue(IsTextColorAnimatingProperty, value); }
        }
    }
}
