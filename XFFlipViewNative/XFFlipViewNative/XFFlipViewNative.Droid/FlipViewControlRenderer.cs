using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Android.Animation;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFFlipViewNative;
using XFFlipViewNative.Droid;
using Animation = Xamarin.Forms.Animation;

[assembly: ExportRenderer(typeof(FlipViewControl), typeof(FlipViewControlRenderer))]
namespace XFFlipViewNative.Droid
{
    public class FlipViewControlRenderer : ViewRenderer<FlipViewControl, Android.Views.View>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<FlipViewControl> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                ((FlipViewControl)e.NewElement).MoveToPreviousCommand = new Command(() =>
                {
                    //FlipAnimation flipAnimation = new FlipAnimation(new Android.Views.View(this.Context), new Android.Views.View(this.Context));

                    var distance = 8000;
                    float scale = Context.Resources.DisplayMetrics.Density * distance;
                    SetCameraDistance(scale);

                    //this.StartAnimation(flipAnimation);

                    //// Out Animation
                    ObjectAnimator animYForward = ObjectAnimator.OfFloat(this, "RotationY", 0.0f, 180f);
                    animYForward.SetDuration(700);

                    var contentRenderer = Platform.CreateRenderer(new ContentView());
                    //var contentRenderer = Xamarin.Forms.Platform.Android.RendererFactory.GetRenderer(new ContentView());
                    var rendererType = contentRenderer.GetType();
                    var nativeControlType = contentRenderer.ViewGroup.GetType();

                    //ObjectAnimator animAlphaOut = ObjectAnimator.OfFloat(this, "Alpha", 1.0f, 0.0f);
                    //animAlphaOut.SetDuration(0);
                    //animAlphaOut.SetCurrentFraction(1500);


                    //// In Animation
                    //ObjectAnimator animAlphaIn1 = ObjectAnimator.OfFloat(this, "Alpha", 1.0f, 0.0f);
                    //animAlphaIn1.SetDuration(0);

                    //ObjectAnimator animYBackward = ObjectAnimator.OfFloat(this, "RotationY", -180f, 0.0f);
                    //animYBackward.RepeatMode = ValueAnimatorRepeatMode.Reverse;
                    //animYBackward.SetDuration(3000);

                    //ObjectAnimator animAlphaIn2 = ObjectAnimator.OfFloat(this, "Alpha", 0.0f, 1.0f);
                    //animAlphaIn2.SetDuration(0);
                    //animAlphaIn2.SetCurrentFraction(1500);


                    //AnimatorSet animSetXY = new AnimatorSet();
                    //animSetXY.PlaySequentially(
                    //    animYForward, animAlphaOut, animAlphaIn1,
                    //    animYBackward, animAlphaIn2);
                    //animSetXY.Start();
                    //animSetXY.AnimationEnd += (sender, args) =>
                    //{
                    //    animSetXY.Start();
                    //};

                    animYForward.Start();
                    animYForward.Update += (sender, args) =>
                    {
                        // https://forums.xamarin.com/discussion/49978/changing-default-perspective-after-rotation
                        var distance1 = 8000;
                        float scale1 = Context.Resources.DisplayMetrics.Density * distance1;
                        SetCameraDistance(scale1);
                    };
                });

            }

        }

        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }
    }
}