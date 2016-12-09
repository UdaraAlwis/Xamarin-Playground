using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CustomRenderersDemo;
using CustomRenderersDemo.WinPhone;

using Xamarin.Forms.Platform.WinRT;

[assembly:ExportRenderer(typeof(RoundCornersButton), typeof(RoundCornersButtonRenderer))]
namespace CustomRenderersDemo.WinPhone
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media;

    using Xamarin.Forms.Platform.WinRT;

    using Button = Xamarin.Forms.Button;

    public class RoundCornersButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
				// Subscribe for events

                e.NewElement.SizeChanged += XFButtonOnSizeChanged;
            }
            else if (e.OldElement != null)
            {
                // Unsubscribe from events

                e.OldElement.SizeChanged -= XFButtonOnSizeChanged;
            }
        }

        private void XFButtonOnSizeChanged(object sender, EventArgs eventArgs)
        {
			// Credits for the code : http://www.wintellect.com/devcenter/jprosise/supercharging-xamarin-forms-with-custom-renderers-part-2
            Control.ApplyTemplate();
            var borders = Control.GetVisuals<Border>();
            var radius = Math.Min(Element.Width, Element.Height) / 2.0;

            foreach (var border in borders)
            {
                border.CornerRadius = new CornerRadius(radius);
            }
        }
    }

	// Credits for the code : http://www.wintellect.com/devcenter/jprosise/supercharging-xamarin-forms-with-custom-renderers-part-2
    static class DependencyObjectExtensions
    {
        public static IEnumerable<T> GetVisuals<T>(this DependencyObject root)
            where T : DependencyObject
        {
            int count = VisualTreeHelper.GetChildrenCount(root);

            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(root, i);

                if (child is T)
                    yield return child as T;

                foreach (var descendants in child.GetVisuals<T>())
                {
                    yield return descendants;
                }
            }
        }
    }
}
