using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFFlipViewNative;
using XFFlipViewNative.iOS;

[assembly: ExportRenderer(typeof(FilppableContentViewXF), typeof(FilppableContentViewXFRenderer))]
namespace XFFlipViewNative.iOS
{
    public class FilppableContentViewXFRenderer : ViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);


            if (((FilppableContentViewXF)e.NewElement) != null)
            {

                ((FilppableContentViewXF)e.NewElement).FlipThisShyiatFrontToBack
                    = AndroidNativeFlipFrontToBack(((FilppableContentViewXF)e.NewElement));

                ((FilppableContentViewXF)e.NewElement).FlipThisShyiatBackToFront
                    = AndroidNativeFlipBackToFront(((FilppableContentViewXF)e.NewElement));
            }
        }


        private Command AndroidNativeFlipFrontToBack(FilppableContentViewXF newElementInstance)
        {
            return new Command(() =>
            {
                UIView.Transition(
                    fromView: ConvertFormsToNative(newElementInstance.BackView, new CGRect(0,0, newElementInstance.BackView.Width, newElementInstance.BackView.Height)),
                    toView: ConvertFormsToNative(newElementInstance.FrontView, new CGRect(0, 0, newElementInstance.FrontView.Width, newElementInstance.FrontView.Height)),
                    duration: 2,
                    options: UIViewAnimationOptions.TransitionFlipFromTop |
                             UIViewAnimationOptions.CurveEaseInOut,
                    completion: () =>
                    {
                        Console.WriteLine("transition complete");
                    });
            });
        }

        private Command AndroidNativeFlipBackToFront(FilppableContentViewXF newElementInstance)
        {
            return new Command(() =>
            {
                UIView.Transition(
                    fromView: ConvertFormsToNative(newElementInstance.FrontView, new CGRect(0, 0, newElementInstance.FrontView.Width, newElementInstance.FrontView.Height)),
                    toView: ConvertFormsToNative(newElementInstance.BackView, new CGRect(0, 0, newElementInstance.BackView.Width, newElementInstance.BackView.Height)),
                    duration: 2,
                    options: UIViewAnimationOptions.TransitionFlipFromTop |
                             UIViewAnimationOptions.CurveEaseInOut,
                    completion: () =>
                    {
                        Console.WriteLine("transition complete");
                    });
            });
        }

        public static UIView ConvertFormsToNative(Xamarin.Forms.View view, CGRect size)
        {
            var renderer = Platform.CreateRenderer(view);

            renderer.NativeView.Frame = size;

            renderer.NativeView.AutoresizingMask = UIViewAutoresizing.All;
            renderer.NativeView.ContentMode = UIViewContentMode.ScaleToFill;

            renderer.Element.Layout(size.ToRectangle());

            var nativeView = renderer.NativeView;

            nativeView.SetNeedsLayout();

            return nativeView;
        }
    }
}