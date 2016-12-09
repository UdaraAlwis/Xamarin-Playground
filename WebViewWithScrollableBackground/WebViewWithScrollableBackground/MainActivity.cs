using System;
using Android.Animation;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using Android.Webkit;

namespace WebViewWithScrollableBackground
{
    [Activity(Label = "WebViewWithScrollableBackground", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;


        /// <summary>
        /// Sets the Vertical offset value for the BouncyScrollView 
        /// </summary>
        private double _scrollViewOverScrollOffsetValue;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            SetContentView(Resource.Layout.Main);




            TextView textView1 = FindViewById<TextView>(Resource.Id.textView1);

            TextView textView2 = FindViewById<TextView>(Resource.Id.textView2);

            WebView webView = FindViewById<WebView>(Resource.Id.driver_log);

            int valueINcrease = 0;

            BounceScrollView scrollView = FindViewById<BounceScrollView>(Resource.Id.scrollview);
            //scrollView.SmoothScrollingEnabled = true;
            scrollView.ScrollChange += (sender, args) =>
            {
                double alpha = 1;

                //if (args.ScrollY <= -150)
                //{
                    alpha = (((double)(100)/30) / ((double)Math.Abs(args.ScrollY) / 100))/10;
                //}
                //else
                //{
                //    alpha = 1;
                //}

                webView.Alpha = (float)alpha;

                textView1.Text = args.ScrollY.ToString() + " - " + alpha;

                //double valueY = args.ScrollY;

                //var upwards = valueY >= 0;


                //textView1.Text = args.ScrollY.ToString() + " - " + upwards;


                //webView.SetY(args.ScrollY + 200);
                //textView1.Text = args.ScrollY.ToString();
            };

            //scrollView.OverScrollMode = OverScrollMode.Always;

            //ObjectAnimator.OfInt(scrollView, "scrollY", 400).SetDuration(500).Start();

            scrollView.Touch += (sender, args) =>
            {
                textView2.Text = args.Event.Action.ToString();


                //if (args.Event.Action == MotionEventActions.Down)
                //{

                //    if (scrollView.ScrollY <= 0)
                //    {
                //        //if (!ObjectAnimator.OfInt(scrollView, "ScrollY", 400).SetDuration(1000).IsStarted)
                //        //{
                //        ObjectAnimator.OfInt(scrollView, "ScrollY", 0).SetDuration(1000).Start();
                //        //}
                //    }
                //}

                scrollView.OnTouchEvent(args.Event);
            };


            scrollView.OverScrollMode = OverScrollMode.Always;

            webView.SetBackgroundColor(Color.Transparent);
            webView.LoadDataWithBaseURL("file:///android_asset/",
                @"<html><head><link rel='stylesheet' href='Style.css' type='text/css' /></head><body class=""balancesheet-body""><br /><br /><table class=""balance-header-table"">
                    <tr class=""balance-caption""><td>Your Tippstr balance</td><td class=""balance-value"">£27.61</td></tr>
                    <tr class=""balance-subcaption""><td>Lifetime earnings:</td><td class=""balance-value"">£157.61</td></tr>
                    </table>
                    <img src=""popup_background_divider_n@2x.png"" class=""balance-divider"" />
                    <table class=""balance-section-table"">
                    <tr class=""balance-caption""><td>Earned in the last 7 days:</td><td class=""balance-value"">£21.79</td></tr>



                    <tr class=""balance-text""><td>Tipp redeemed at Strada</td><td class=""balance-value"">£8.54</td></tr>
                    <tr class=""balance-withdraw""><td>You withdrew money!</td><td class=""balance-value"">-£50.00</td></tr>
                    <tr class=""balance-shared""><td>Jane used the Costa Coffee Tipp you shared</td><td class=""balance-value"">£0.15</td></tr>
                    <tr class=""balance-text""><td>Peter redeemed a Tipp (you introduced them to Tippstr)</td><td class=""balance-value"">£1.07</td></tr>
                    <tr class=""balance-text""><td>Tipp redeemed at Royal Opera House</td><td class=""balance-value"">£10.89</td></tr>
                    <tr class=""balance-text""><td>Maria’s friend used a Tipp (you introduced Maria to Tippstr)</td><td class=""balance-value"">£0.31</td></tr>
                    <tr class=""balance-shared""><td>Katy used the LoveFilm Tipp you shared</td><td class=""balance-value"">£0.83</td></tr>
                    </table>
                    <img src=""popup_background_divider_n@2x.png"" class=""balance-divider"" />
                    <table class=""balance-section-table"">
                    <tr class=""balance-caption""><td>Earned in the last 30 days:</td><td class=""balance-value"">£98.53</td></tr>
                    <tr class=""balance-shared""><td>Richard used the Taj Tanjing Tipp you shared</td><td class=""balance-value"">£2.31</td></tr>
                    <tr class=""balance-text""><td>Tipp redeemed at Taj Tanjing</td><td class=""balance-value"">£13.23</td></tr>
                    <tr class=""balance-shared""><td>Amanda used the Yoga Mad Tipp you shared</td><td class=""balance-value"">£3.06</td></tr>
                    <tr class=""balance-shared""><td>Morgan used the Costa Coffee Tipp you shared</td><td class=""balance-value"">£0.15</td></tr>
                    <tr class=""balance-text""><td>Peter’s friend used a Tipp (you introduced Peter to Tippstr)</td><td class=""balance-value"">£0.49</td></tr>
                    <tr class=""balance-text""><td>Tipp redeemed at Costa Coffee</td><td class=""balance-value"">£1.00</td></tr>
                    <tr class=""balance-text""><td>Tipp redeemed at TOPMAN</td><td class=""balance-value"">£7.83</td></tr>
                    <tr class=""balance-text""><td>Amanda redeemed a Tipp (you introduced them to Tippstr)</td><td class=""balance-value"">£1.07</td></tr>
                    <tr class=""balance-text""><td>Tipp redeemed at Costa Coffee</td><td class=""balance-value"">£1.00</td></tr>
                    <tr class=""balance-withdraw""><td>You withdrew money!</td><td class=""balance-value"">-£80.00</td></tr>
                    <tr class=""balance-text""><td>Paul redeemed a Tipp (you introduced them to Tippstr)</td><td class=""balance-value"">£0.32</td></tr>
                    <tr class=""balance-text""><td>Tipp redeemed at Sony</td><td class=""balance-value"">£56.42</td></tr>
                    <tr class=""balance-text""><td>Morgan’s friend used a Tipp (you introduced Morgan to Tippstr)</td><td class=""balance-value"">£0.49</td></tr>
                    <tr class=""balance-shared""><td>Sue used the Wimbledon Tipp you shared</td><td class=""balance-value"">£3.86</td></tr>
                    <tr class=""balance-text""><td>Tipp redeemed at Strada</td><td class=""balance-value"">£7.30</td></tr>
                    </table>
                    <img src=""popup_background_divider_n@2x.png"" class=""balance-divider"" />
                    <table class=""balance-section-table"">
                    <tr class=""balance-caption""><td>All previous earnings:</td><td class=""balance-value"">£37.29</td></tr>
                    <tr class=""balance-shared""><td>Jane used the Yoga Mad Tipp you shared</td><td class=""balance-value"">£4.22</td></tr>
                    <tr class=""balance-text""><td>Peter redeemed a Tipp (you introduced them to Tippstr)</td><td class=""balance-value"">£2.37</td></tr>
                    <tr class=""balance-text""><td>Tipp redeemed at Wetherspoon</td><td class=""balance-value"">£4.94</td></tr>
                    <tr class=""balance-text""><td>Tipp redeemed at Coca Cola</td><td class=""balance-value"">£1.00</td></tr>
                    <tr class=""balance-text""><td>Tipp redeemed at Wimbledon</td><td class=""balance-value"">£10.00</td></tr>
                    <tr class=""balance-text""><td>Tipp redeemed at Yoga Mad</td><td class=""balance-value"">£14.76</td></tr>
                    </table>
                    </body></html>", "text/html", "UTF-8", null);



            // Retrieving the screen height
            Point size = new Point();
          WindowManager.DefaultDisplay.GetSize(size);
            var _screenHeight = size.Y;

            _scrollViewOverScrollOffsetValue = (_screenHeight * ((double)1/4)) * -1; // Pulling down through Y axis gives you minus values
        }

        public static float GetAlphaByDistance(
    float distance,
    float? startingScrollPoint,
    float positiveRatio,
    float negativeRatio,
    float minDownwardsAlpha)
        {
            if (!startingScrollPoint.HasValue)
            {
                return 1f;
            }

            var upwards = distance >= startingScrollPoint.Value;
            var ratio = upwards ? positiveRatio : negativeRatio;
            var alpha = (float)Math.Abs(startingScrollPoint.Value - distance) * ratio / 100;
            if (alpha > 1)
            {
                alpha = 1;
            }

            alpha = 1 - alpha;

            return ((alpha < minDownwardsAlpha) && (!upwards)) ? minDownwardsAlpha : alpha;
        }
    }

    public class BounceScrollView : ScrollView
    {

        private static int MAX_Y_OVERSCROLL_DISTANCE = 300;

        private Context mContext;
        private int mMaxYOverscrollDistance;

        public BounceScrollView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {

        }

        public BounceScrollView(Context context) : base(context)
        {

            mContext = context;
            initBounceScrollView();
        }

        public BounceScrollView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            mContext = context;
            initBounceScrollView();
        }

        public BounceScrollView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            mContext = context;
            initBounceScrollView();
        }


        private void initBounceScrollView()
        {
            DisplayMetrics metrics = mContext.Resources.DisplayMetrics;
             float density = metrics.Density;

            mMaxYOverscrollDistance = (int)(density * MAX_Y_OVERSCROLL_DISTANCE);
        }

        protected override bool OverScrollBy(int deltaX, int deltaY, int scrollX,
  int scrollY, int scrollRangeX, int scrollRangeY,
  int maxOverScrollX, int maxOverScrollY, bool isTouchEvent)
        {
            if (scrollRangeY <= scrollY)
            {
                return base.OverScrollBy(deltaX, deltaY, scrollX, scrollY,
              scrollRangeX, scrollRangeY, maxOverScrollX,
              maxOverScrollY, isTouchEvent);
            }

            // This is where the magic happens, we have replaced the incoming
            // maxOverScrollY with our own custom variable mMaxYOverscrollDistance;
            return base.OverScrollBy(deltaX, deltaY, scrollX, scrollY,
              scrollRangeX, scrollRangeY, maxOverScrollX,
              mMaxYOverscrollDistance, isTouchEvent);
        }


        public override bool DispatchNestedFling(float velocityX, float velocityY, bool consumed)
        {
            // Not consumed means it wasn't handled because ScrollView
            // doesn't take over scrolling bounds into scroll range,
            // so we fling it ourselves to get it bounce back
            if (!consumed)
            {
                Fling((int)velocityY);

                return true;
            }
            else
            {
                return base.DispatchNestedFling(velocityX, velocityY, consumed);
            }
        }

        public BounceScrollView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {

        }
    }
}

