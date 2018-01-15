using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFAnimatingDotsControl
{
    public partial class AnimatingDotsControl : ContentView
    {
        public AnimatingDotsControl()
        {
            InitializeComponent();
            
            if (Device.OS == TargetPlatform.Android)
            {
                Dot1.TranslateTo(Dot1.X, Dot1.Y + 50);
                Dot2.TranslateTo(Dot1.X, Dot2.Y + 50);
                Dot3.TranslateTo(Dot1.X, Dot3.Y + 50);

                Dot1Shadow.TranslateTo(Dot1.X, Dot1.Y + 50);
                Dot2Shadow.TranslateTo(Dot1.X, Dot2.Y + 50);
                Dot3Shadow.TranslateTo(Dot1.X, Dot3.Y + 50);
            }
        }

        private bool animationStarted;

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            // Make sure the controls are rendered and then start the animation
            if (!animationStarted && Dot1!= null)
            {
                animationStarted = true;

                //CancellationTokenSource cancelConnectionAnimation = new CancellationTokenSource();

                //Task.Run(async () =>
                //{
                //    while (!cancelConnectionAnimation.Token.IsCancellationRequested)
                //    {
                //        Xamarin.Forms.Device.BeginInvokeOnMainThread(RunAnimations);

                //        await Task.Delay(1200, cancelConnectionAnimation.Token);
                //    }

                //}, cancelConnectionAnimation.Token);

                RunAnimations();
            }
        }

        private async void RunAnimations()
        {
            //await Dot1.FadeTo(1, 200);
            //await Dot1.FadeTo(0, 200);
            //await Dot2.FadeTo(1, 200);
            //await Dot2.FadeTo(0, 200);
            //await Dot3.FadeTo(1, 200);
            //await Dot3.FadeTo(0, 200);
            
            var pulseAnimation = new Animation();
            pulseAnimation.Add(0, 0.5, new Animation(alpha => Dot1.Opacity = alpha, 0, 1, Easing.CubicOut, null));
            pulseAnimation.Add(0.5, 1, new Animation(alpha => Dot1.Opacity = alpha, 1, 0, Easing.CubicOut, null));
            pulseAnimation.Commit(Dot1, "loadingIndicatorPulseAnimation1", 10, 1500, null, null, () => true);

            var pulseAnimation2 = new Animation();
            pulseAnimation2.Add(0, 0.5, new Animation(alpha => Dot2.Opacity = alpha, 0, 1, Easing.CubicOut, null));
            pulseAnimation2.Add(0.5, 1, new Animation(alpha => Dot2.Opacity = alpha, 1, 0, Easing.CubicOut, null));
            pulseAnimation2.Commit(Dot2, "loadingIndicatorPulseAnimation2", 10, 1500, null, null, () => true);

            var pulseAnimation3 = new Animation();
            pulseAnimation3.Add(0, 0.5, new Animation(alpha => Dot3.Opacity = alpha, 0, 1, Easing.CubicOut, null));
            pulseAnimation3.Add(0.5, 1, new Animation(alpha => Dot3.Opacity = alpha, 1, 0, Easing.CubicOut, null));
            pulseAnimation3.Commit(Dot3, "loadingIndicatorPulseAnimation3", 10, 1500, null, null, () => true);
        }
    }
}
