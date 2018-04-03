using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFHacks.Extensions
{
    [ContentProperty(nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }

            // Do your translation lookup here, using whatever method you require
            ImageSource imageSource;

            if (Device.RuntimePlatform == Device.UWP)
            {
                // fix for UWP resource loading issue
                imageSource = ImageSource.FromResource(Source, Assembly.GetExecutingAssembly());
            }
            else
            {
                imageSource = ImageSource.FromResource(Source);
            }

            return imageSource;
        }
    }
}
