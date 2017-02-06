using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFTextShadowButtonControl
{
    public class TextShadowButton : Button
    {
		public static readonly BindableProperty TextShadowColorProperty =
        BindableProperty.Create(
        nameof(TextShadowColor),
        typeof(Color),
        typeof(TextShadowButton),
        Color.Gray);

        /// <summary>
        /// Gets or Sets TextShadowColor property
        /// </summary>
        public Color TextShadowColor
        {
	        get
	        {
		        return (Color)GetValue(TextShadowColorProperty);
	        }
	        set
	        {
		        SetValue(TextShadowColorProperty, value);
	        }
        }
    }
}
