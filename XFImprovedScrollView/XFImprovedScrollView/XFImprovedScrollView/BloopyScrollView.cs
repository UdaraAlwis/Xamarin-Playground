using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFImprovedScrollView
{
    public class BloopyScrollView : ScrollView
    {
        public static readonly BindableProperty IsHorizontalScrollbarEnabledProperty =
        BindableProperty.Create(
            nameof(IsHorizontalScrollbarEnabled),
            typeof(bool),
            typeof(BloopyScrollView),
            false,
            BindingMode.Default,
            null);
        /// <summary>
        /// Gets or sets the Horizontal scrollbar visibility
        /// </summary>
        public bool IsHorizontalScrollbarEnabled
        {
            get { return (bool)GetValue(IsHorizontalScrollbarEnabledProperty); }
            set { SetValue(IsHorizontalScrollbarEnabledProperty, value); }
        }


        public static readonly BindableProperty IsVerticalScrollbarEnabledProperty =
        BindableProperty.Create(
            nameof(IsVerticalScrollbarEnabled),
            typeof(bool),
            typeof(BloopyScrollView),
            false,
            BindingMode.Default,
            null);
        /// <summary>
        /// Gets or sets the Vertical scrollbar visibility
        /// </summary>
        public bool IsVerticalScrollbarEnabled
        {
            get { return (bool)GetValue(IsVerticalScrollbarEnabledProperty); }
            set { SetValue(IsVerticalScrollbarEnabledProperty, value); }
        }


        public static readonly BindableProperty IsNativeBouncyEffectEnabledProperty =
        BindableProperty.Create(
            nameof(IsNativeBouncyEffectEnabled),
            typeof(bool),
            typeof(BloopyScrollView),
            true,
            BindingMode.Default,
            null);
        /// <summary>
        /// Gets or sets the Native Bouncy effect status
        /// </summary>
        public bool IsNativeBouncyEffectEnabled
        {
            get { return (bool)GetValue(IsNativeBouncyEffectEnabledProperty); }
            set { SetValue(IsNativeBouncyEffectEnabledProperty, value); }
        }


        public static readonly BindableProperty BackgroundImageProperty =
        BindableProperty.Create(
            nameof(BackgroundImage),
            typeof(ImageSource),
            typeof(BloopyScrollView),
            null,
            BindingMode.Default,
            null);
        /// <summary>
        /// Gets or sets the Background Image of the ScrollView
        /// </summary>
        public ImageSource BackgroundImage
        {
            get { return (ImageSource)GetValue(BackgroundImageProperty); }
            set { SetValue(BackgroundImageProperty, value); }
        }
    }
}
