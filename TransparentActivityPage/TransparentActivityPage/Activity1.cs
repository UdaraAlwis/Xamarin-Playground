using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TransparentActivityPage
{
    [Activity]
    public class Activity1 : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            //SetContentView(Resource.Layout.layout1);

            // Create your application here


            
            // Defining the RelativeLayout layout parameters.
            // In this case I want to fill its parent
            RelativeLayout.LayoutParams relativeLayoutParameters = new RelativeLayout.LayoutParams(
                    ViewGroup.LayoutParams.MatchParent,
                    ViewGroup.LayoutParams.MatchParent);

            // Creating a new RelativeLayout
            RelativeLayout relativeLayout = new RelativeLayout(this);
            relativeLayout.LayoutParameters = relativeLayoutParameters;




            // Defining the RelativeLayout layout parameters.
            // In this case I want to fill its parent
            RelativeLayout.LayoutParams containerLayoutParams = new RelativeLayout.LayoutParams(
                    ViewGroup.LayoutParams.MatchParent,
                    ViewGroup.LayoutParams.WrapContent);
            containerLayoutParams.SetMargins(
                 (int)Math.Round(TypedValue.ApplyDimension(ComplexUnitType.Dip, 40, this.Resources.DisplayMetrics)),
                 (int)Math.Round(TypedValue.ApplyDimension(ComplexUnitType.Dip, 50, this.Resources.DisplayMetrics)),
                 (int)Math.Round(TypedValue.ApplyDimension(ComplexUnitType.Dip, 40, this.Resources.DisplayMetrics)),
                 0);

            // Creating a new RelativeLayout
            RelativeLayout container = new RelativeLayout(this);
            container.LayoutParameters = containerLayoutParams;
            container.SetBackgroundColor(Color.White);





            RelativeLayout.LayoutParams layoutParamForImageHolder = new RelativeLayout.LayoutParams(
                    ViewGroup.LayoutParams.MatchParent,
                    ViewGroup.LayoutParams.WrapContent);

            ImageView _headerBackgoundImage = new ImageView(this);
            _headerBackgoundImage.Id = 0;
            _headerBackgoundImage.SetScaleType(ImageView.ScaleType.FitXy);
            _headerBackgoundImage.SetAdjustViewBounds(true);
            _headerBackgoundImage.LayoutParameters = layoutParamForImageHolder;
            _headerBackgoundImage.SetImageBitmap(
                BitmapFactory.DecodeResource(Resources,
                Resource.Drawable.testcrabimagewide));

            RelativeLayout.LayoutParams layoutParamForCenterIcon = new RelativeLayout.LayoutParams(
                    ViewGroup.LayoutParams.WrapContent,
                    ViewGroup.LayoutParams.WrapContent);
            layoutParamForCenterIcon.AddRule(LayoutRules.CenterHorizontal);
            layoutParamForCenterIcon.AddRule(LayoutRules.Below, _headerBackgoundImage.Id);
            layoutParamForCenterIcon.SetMargins(
                 (int)Math.Round(TypedValue.ApplyDimension(ComplexUnitType.Dip, 100, this.Resources.DisplayMetrics)),
                 (int)Math.Round(TypedValue.ApplyDimension(ComplexUnitType.Dip, 50, this.Resources.DisplayMetrics)),
                 (int)Math.Round(TypedValue.ApplyDimension(ComplexUnitType.Dip, 100, this.Resources.DisplayMetrics)),
                 0);

            ImageView _headerCenterIconImage = new ImageView(this);
            _headerCenterIconImage.Id = 1;
            _headerCenterIconImage.SetAdjustViewBounds(true);
            _headerCenterIconImage.LayoutParameters = layoutParamForCenterIcon;
            _headerCenterIconImage.SetImageBitmap(
                BitmapFactory.DecodeResource(Resources,
                Resource.Drawable.circletick));



            RelativeLayout.LayoutParams layoutParamForMessageTitle = new RelativeLayout.LayoutParams(
                    ViewGroup.LayoutParams.WrapContent,
                    ViewGroup.LayoutParams.WrapContent);
            layoutParamForMessageTitle.AddRule(LayoutRules.CenterHorizontal);
            layoutParamForMessageTitle.AddRule(LayoutRules.Below, _headerCenterIconImage.Id);
            layoutParamForMessageTitle.SetMargins(
                 0,
                 (int)Math.Round(TypedValue.ApplyDimension(ComplexUnitType.Dip, 15, this.Resources.DisplayMetrics)),
                 0,
                 0);

            TextView _messageTitle = new TextView(this);
            _messageTitle.Id = 2;
            _messageTitle.Text = "Tipp successfully shared!";
            _messageTitle.LayoutParameters = layoutParamForMessageTitle;
            _messageTitle.SetTextColor(Color.Black);
            _messageTitle.SetTextSize(ComplexUnitType.Dip, 20);
            _messageTitle.SetTypeface(Typeface.Default, TypefaceStyle.Bold);







            RelativeLayout.LayoutParams layoutParamForSubMessageTitle = new RelativeLayout.LayoutParams(
                    ViewGroup.LayoutParams.WrapContent,
                    ViewGroup.LayoutParams.WrapContent);
            layoutParamForSubMessageTitle.AddRule(LayoutRules.CenterHorizontal);
            layoutParamForSubMessageTitle.AddRule(LayoutRules.Below, _messageTitle.Id);
            layoutParamForSubMessageTitle.SetMargins(
                 0,
                 (int)Math.Round(TypedValue.ApplyDimension(ComplexUnitType.Dip, 20, this.Resources.DisplayMetrics)),
                 0,
                 0);

            TextView _subMessageTitle = new TextView(this);
            _subMessageTitle.Id = 3;
            _subMessageTitle.Text = "Tipp has been shared with:";
            _subMessageTitle.LayoutParameters = layoutParamForSubMessageTitle;
            _subMessageTitle.SetTextColor(Color.Black);
            _subMessageTitle.SetTextSize(ComplexUnitType.Dip, 14);
            _subMessageTitle.SetTypeface(Typeface.Default, TypefaceStyle.Bold);





            RelativeLayout.LayoutParams layoutParamForSubMessageContent = new RelativeLayout.LayoutParams(
                    ViewGroup.LayoutParams.WrapContent,
                    ViewGroup.LayoutParams.WrapContent);
            layoutParamForSubMessageContent.AddRule(LayoutRules.CenterHorizontal);
            layoutParamForSubMessageContent.AddRule(LayoutRules.Below, _subMessageTitle.Id);
            layoutParamForSubMessageContent.SetMargins(
                 0,
                 (int)Math.Round(TypedValue.ApplyDimension(ComplexUnitType.Dip, 15, this.Resources.DisplayMetrics)),
                 0,
                 0);

            TextView _subMessageContent = new TextView(this);
            _subMessageContent.Id = 4;
            _subMessageContent.Text = "9761235261";
            _subMessageContent.LayoutParameters = layoutParamForSubMessageContent;
            _subMessageContent.SetTextColor(Color.Black);
            _subMessageContent.SetTextSize(ComplexUnitType.Dip, 20);
            _subMessageContent.SetTypeface(Typeface.Default, TypefaceStyle.Bold);




            RelativeLayout.LayoutParams layoutParamForButton = new RelativeLayout.LayoutParams(
                    ViewGroup.LayoutParams.MatchParent,
                    ViewGroup.LayoutParams.WrapContent);
            layoutParamForButton.AddRule(LayoutRules.CenterHorizontal);
            layoutParamForButton.AddRule(LayoutRules.Below, _subMessageContent.Id);
            layoutParamForButton.SetMargins(
                 0,
                 (int)Math.Round(TypedValue.ApplyDimension(ComplexUnitType.Dip, 15, this.Resources.DisplayMetrics)),
                 0,
                 (int)Math.Round(TypedValue.ApplyDimension(ComplexUnitType.Dip, 10, this.Resources.DisplayMetrics)));

            Button btn_GoBack = new Button(this);
            btn_GoBack.Text = "Return home";
            btn_GoBack.LayoutParameters = layoutParamForButton;



            container.AddView(_headerBackgoundImage);
            container.AddView(_headerCenterIconImage);
            container.AddView(_messageTitle);
            container.AddView(_subMessageTitle);
            container.AddView(_subMessageContent);
            container.AddView(btn_GoBack);

            relativeLayout.AddView(container);

            //// Replacing the XF Controls and setting our Native Layout
            SetContentView(relativeLayout);

        }
    }
}