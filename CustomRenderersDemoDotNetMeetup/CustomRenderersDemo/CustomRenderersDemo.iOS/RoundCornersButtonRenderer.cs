using System;
using System.Collections.Generic;
using System.Text;

using CustomRenderersDemo;
using CustomRenderersDemo.iOS;

using Xamarin.Forms;

[assembly: ExportRenderer(typeof(RoundCornersButton), typeof(RoundCornersButtonRenderer))]
namespace CustomRenderersDemo.iOS
{
    using Xamarin.Forms.Platform.iOS;
    public class RoundCornersButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                // Subscribe for events
            }
            else if (e.OldElement != null)
            {
                // Unsubscribe from events
            }

            if (Control !=null)
            {
                Control.Layer.CornerRadius = 22;
                Control.ClipsToBounds = true;
            }
        }
    }
}
