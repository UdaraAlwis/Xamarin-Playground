using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFLaserScanAnimation
{
    public partial class MainPage : ContentPage
    {
        private double _screenHeight;
        public MainPage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(() =>
            {
            });
        }


        //void animate1()
        //{
        //    var a = new Animation();
        //    a.Add(0, 0.5, new Animation((v) =>
        //    {
        //        Ray1.TranslationY = v;
        //    }, _screenHeight, -50, Easing.Linear, () => { System.Diagnostics.Debug.WriteLine("ANIMATION A"); }));

        //    a.Add(0.5, 1, new Animation((v) =>
        //    {
        //        Ray1.TranslationY = v;
        //    }, -50, _screenHeight, Easing.Linear, () => { System.Diagnostics.Debug.WriteLine("ANIMATION B"); }));

        //    a.Commit(Ray1, "animation", 16, 5000, null, (d, f) =>
        //    {
        //        Ray1.TranslationY = _screenHeight;
        //        System.Diagnostics.Debug.WriteLine("ANIMATION ALL");
        //        animate1();
        //    });
        //}

        //void animate2()
        //{
        //    var a = new Animation();
        //    a.Add(0, 0.5, new Animation((v) =>
        //    {
        //        Ray2.TranslationY = v;
        //    }, _screenHeight, -50, Easing.Linear, () => { System.Diagnostics.Debug.WriteLine("ANIMATION A"); }));

        //    a.Add(0.5, 1, new Animation((v) =>
        //    {
        //        Ray2.TranslationY = v;
        //    }, -50, _screenHeight, Easing.Linear, () => { System.Diagnostics.Debug.WriteLine("ANIMATION B"); }));

        //    a.Commit(Ray2, "animation", 16, 5000, null, (d, f) =>
        //    {
        //        Ray2.TranslationY = _screenHeight;
        //        System.Diagnostics.Debug.WriteLine("ANIMATION ALL");
        //        animate2();
        //    });
        //}


        //void animate3()
        //{
        //    var a = new Animation();
        //    a.Add(0, 0.5, new Animation((v) =>
        //    {
        //        Ray3.TranslationY = v;
        //    }, _screenHeight, -50, Easing.Linear, () => { System.Diagnostics.Debug.WriteLine("ANIMATION A"); }));

        //    a.Add(0.5, 1, new Animation((v) =>
        //    {
        //        Ray3.TranslationY = v;
        //    }, -50, _screenHeight, Easing.Linear, () => { System.Diagnostics.Debug.WriteLine("ANIMATION B"); }));

        //    a.Commit(Ray3, "animation", 16, 5000, null, (d, f) =>
        //    {
        //        Ray3.TranslationY = _screenHeight;
        //        System.Diagnostics.Debug.WriteLine("ANIMATION ALL");
        //        animate3();
        //    });
        //}


        //void animate4()
        //{
        //    var a = new Animation();
        //    a.Add(0, 0.5, new Animation((v) =>
        //    {
        //        Ray4.TranslationY = v;
        //    }, _screenHeight, -50, Easing.Linear, () => { System.Diagnostics.Debug.WriteLine("ANIMATION A"); }));

        //    a.Add(0.5, 1, new Animation((v) =>
        //    {
        //        Ray4.TranslationY = v;
        //    }, -50, _screenHeight, Easing.Linear, () => { System.Diagnostics.Debug.WriteLine("ANIMATION B"); }));

        //    a.Commit(Ray4, "animation", 16, 5000, null, (d, f) =>
        //    {
        //        Ray4.TranslationY = _screenHeight;
        //        System.Diagnostics.Debug.WriteLine("ANIMATION ALL");
        //        animate4();
        //    });
        //}


        //void animate5()
        //{
        //    var a = new Animation();
        //    a.Add(0, 0.5, new Animation((v) =>
        //    {
        //        Ray5.TranslationY = v;
        //    }, _screenHeight, -50, Easing.Linear, () => { System.Diagnostics.Debug.WriteLine("ANIMATION A"); }));

        //    a.Add(0.5, 1, new Animation((v) =>
        //    {
        //        Ray5.TranslationY = v;
        //    }, -50, _screenHeight, Easing.Linear, () => { System.Diagnostics.Debug.WriteLine("ANIMATION B"); }));

        //    a.Commit(Ray5, "animation", 16, 5000, null, (d, f) =>
        //    {
        //        Ray5.TranslationY = _screenHeight;
        //        System.Diagnostics.Debug.WriteLine("ANIMATION ALL");
        //        animate5();
        //    });
        //}
    }
}
