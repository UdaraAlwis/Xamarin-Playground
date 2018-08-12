using Xamarin.Forms.Platform.UWP;
using Xamarin.Forms;
using XFHacks.UWP;

[assembly: ExportRenderer(typeof(Frame), typeof(CustomFrameRenderer))]
namespace XFHacks.UWP
{
    class CustomFrameRenderer : FrameRenderer
    {
        private Color backgroundColor;
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                backgroundColor = e.NewElement.BackgroundColor;
                UpdateBackgroundColor();
            }
        }

        protected override void UpdateBackgroundColor()
        {
            //base.UpdateBackgroundColor();
            if (Control != null)
            {
                var nativeControl = (Windows.UI.Xaml.Controls.Border)Control;
                var nativeColor = Windows.UI.Color.FromArgb(
                                                                (byte)(backgroundColor.A * 255),
                                                                (byte)(backgroundColor.R * 255),
                                                                (byte)(backgroundColor.G * 255),
                                                                (byte)(backgroundColor.B * 255));
                nativeControl.Background = new Windows.UI.Xaml.Media.SolidColorBrush(nativeColor);
            }
        }

    }
}