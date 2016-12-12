using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace XFImprovedScrollView.iOS
{
    public class IosImageHelper
    {
        private static IImageSourceHandler GetHandler(ImageSource source)
        {
            IImageSourceHandler returnValue = null;
            if (source is UriImageSource)
            {
                returnValue = new ImageLoaderSourceHandler();
            }
            else if (source is FileImageSource)
            {
                returnValue = new FileImageSourceHandler();
            }
            else if (source is StreamImageSource)
            {
                returnValue = new StreamImagesourceHandler();
            }
            return returnValue;
        }

        /// <summary>
        /// For converting Xamarin Forms ImageSource object to Native Image type
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static async Task<UIImage> GetUIImageFromImageSourceAsync(ImageSource source)
        {
            var handler = GetHandler(source);
            var returnValue = (UIImage)null;

            returnValue = await handler.LoadImageAsync(source);

            return returnValue;
        }

    }
}