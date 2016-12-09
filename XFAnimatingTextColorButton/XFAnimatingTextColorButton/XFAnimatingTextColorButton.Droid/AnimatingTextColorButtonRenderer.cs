using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Android.Animation;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFAnimatingTextColorButton;
using XFAnimatingTextColorButton.Droid;
using Button = Xamarin.Forms.Button;

[assembly: ExportRenderer(typeof(AnimatingTextColorButton), typeof(AnimatingTextColorButtonRenderer))]
namespace XFAnimatingTextColorButton.Droid
{
    public class AnimatingTextColorButtonRenderer : ButtonRenderer
    {
        private ObjectAnimator _textColorChangingAnimation;

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            
            if (e.NewElement != null)
            {
                _textColorChangingAnimation = ObjectAnimator.OfInt(this.Control, "textColor",
                Color.Red.ToAndroid(), Color.Blue.ToAndroid());
                _textColorChangingAnimation.SetDuration(1000);
                _textColorChangingAnimation.SetEvaluator(new ArgbEvaluator());
                _textColorChangingAnimation.RepeatCount = ValueAnimator.Infinite;
                _textColorChangingAnimation.RepeatMode = ValueAnimatorRepeatMode.Reverse;

                ((AnimatingTextColorButton)e.NewElement).PropertyChanged += AnimatingTextColorButton_PropertyChanged;

                if (((AnimatingTextColorButton)e.NewElement).IsTextColorAnimating)
                {
                    StartTextColorAnimation();
                }
            }

            if (e.OldElement != null)
            {
                ((AnimatingTextColorButton)e.OldElement).PropertyChanged -= AnimatingTextColorButton_PropertyChanged;
            }
        }

        private void AnimatingTextColorButton_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AnimatingTextColorButton.IsTextColorAnimating))
            {
                if (((AnimatingTextColorButton)sender).IsTextColorAnimating)
                {
                    StartTextColorAnimation();
                }
                else
                {
                    StopTextColorAnimation();
                }
            }
        }

        private void StartTextColorAnimation()
        {
            _textColorChangingAnimation.Start();
        }

        private void StopTextColorAnimation()
        {
            _textColorChangingAnimation.End();
        }
    }
}