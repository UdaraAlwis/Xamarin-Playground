using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Animation;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace DemystifyXFNav.Droid
{
    [Activity(Theme = "@style/Theme.Transparent")]
    public class MyThirdActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            

            SetContentView(Resource.Layout.MyThirdLayout);

            var button = FindViewById<Button>(Resource.Id.myButton);

            button.Click += (sender, e) => {
                Finish(); // back to the previous activity
            };

            var parentLayout =  FindViewById<LinearLayout>(Resource.Id.parentLayout);


            ValueAnimator _openingBackgroundAnimation;
            
            var colorStart1 = Color.Transparent;
            var colorEnd1 =  Color.Red;
            _openingBackgroundAnimation = ObjectAnimator.OfInt(
                parentLayout, "BackgroundColor", colorStart1,
                colorEnd1);
            _openingBackgroundAnimation.SetDuration(2000);
            _openingBackgroundAnimation.SetEvaluator(new ArgbEvaluator());
            _openingBackgroundAnimation.RepeatCount = 0;

            _openingBackgroundAnimation.Start();
        }
    }
}