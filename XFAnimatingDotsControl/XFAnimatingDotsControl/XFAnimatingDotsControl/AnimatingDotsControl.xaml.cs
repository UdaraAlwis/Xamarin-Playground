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

        protected override async void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            // Make sure the controls are rendered and then start the animation
            if (!animationStarted && Dot1!= null)
            {
                animationStarted = true;
                
                await Task.Factory.StartNew(RunAnimations);

                Device.StartTimer(TimeSpan.FromSeconds(1.1), () =>
                {
                    Task.Factory.StartNew(RunAnimations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
                    
                    return true; // repeat the animation
                });
            }
        }

        private async void RunAnimations()
        {
            await Dot1.FadeTo(1, 200);
            await Dot1.FadeTo(0, 200);
            await Dot2.FadeTo(1, 200);
            await Dot2.FadeTo(0, 200);
            await Dot3.FadeTo(1, 200);
            await Dot3.FadeTo(0, 200);
        }
    }
}
