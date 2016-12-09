using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Internal.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFCustomNavBar.Droid;
using Color = Android.Graphics.Color;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(ContentPage), typeof(ContentPageRenderer))]
namespace XFCustomNavBar.Droid
{
    public class ContentPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement.ToolbarItems != null && 
                e.NewElement.ToolbarItems.Count > 0)
            {
                //Toolbar toolbar = new Toolbar(this.Context);
                //toolbar.LayoutParameters = new Toolbar.LayoutParams(LayoutParams.MatchParent, LayoutParams.WrapContent);

                //((Activity)this.Context).SetActionBar(toolbar);
                //((Activity)this.Context).ActionBar.SetDisplayShowCustomEnabled(true);

                //((Activity)this.Context).ActionBar.SetCustomView(toolbar,
                //    new ActionBar.LayoutParams(
                //        LayoutParams.MatchParent,
                //        LayoutParams.MatchParent));

                e.NewElement.ToolbarItems.Clear();
            }

            //e.NewElement.ToolbarItems

            //ActionBar actionBar = ((Activity)this.Context).ActionBar; // or getActionBar();
            ////actionBar.Hide(); // or even hide the actionbar
            
            //actionBar.MenuVisibility += (sender, args) =>
            //{
                
            //};
        }

        public override void OnViewAdded(View child)
        {
            base.OnViewAdded(child);

            //ActionBar actionBar = ((Activity)this.Context).ActionBar; // or getActionBar();
            ////actionBar.Hide(); // or even hide the actionbar

            //int itemsCount = actionBar.NavigationItemCount;

            //actionBar.RemoveAllTabs();
        }

        protected override void OnAttachedToWindow()
        {
            LinearLayout linLayout = new LinearLayout(this.Context)
            {
                Background = new ColorDrawable(Color.Red)
            };
            linLayout.LayoutParameters = new ViewGroup.LayoutParams(LayoutParams.MatchParent, LayoutParams.WrapContent);
            linLayout.SetPadding(0, 20, 0, 0);
        }


        private View GetViewFromToolBarTitle(String title)
        {
            var textView = new TextView(this.Context);

            LayoutParams tableRowLayoutParams = new ViewGroup.LayoutParams(LayoutParams.MatchParent, LayoutParams.WrapContent);
            tableRowLayoutParams.Width = LayoutParams.WrapContent;
            tableRowLayoutParams.Height = LayoutParams.MatchParent;

            textView.LayoutParameters = tableRowLayoutParams;

            textView.Text = title;
            textView.SetTypeface(Typeface.Create("sans-serif", TypefaceStyle.Bold), TypefaceStyle.Bold);
            textView.SetTextSize(ComplexUnitType.Dip, 19);
            textView.SetTextColor(Color.Black);
            textView.Gravity = GravityFlags.Center;

            return textView;
        }
    }
}