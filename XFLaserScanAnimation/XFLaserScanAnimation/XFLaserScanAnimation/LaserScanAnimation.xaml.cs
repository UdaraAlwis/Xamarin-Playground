using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XFLaserScanAnimation
{
    public partial class LaserScanAnimation : StackLayout
    {
        private double _thisContainerHeight;

        public LaserScanAnimation()
        {
            InitializeComponent();
        }
    
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (this.Height > 0)
            {
                _thisContainerHeight = this.Height;

                animate1();
            }
        }

        void animate1()
        {
            var a = new Animation();
            a.Add(0, 0.5, new Animation((v) =>
            {
                ParentLayout1.TranslationY = v;
            }, _thisContainerHeight, -10, Easing.CubicInOut, () =>
            {
                ParentLayout1.RotationX = 180;
                System.Diagnostics.Debug.WriteLine("ANIMATION UPWARDS");
            }));

            a.Add(0.5, 1, new Animation((v) =>
            {
                ParentLayout1.TranslationY = v;
            }, -10, _thisContainerHeight, Easing.CubicInOut, () =>
            {
                ParentLayout1.RotationX = 0;
                System.Diagnostics.Debug.WriteLine("ANIMATION DOWNWARDS");
            }));

            a.Commit(ParentLayout1, "animation", 16, 2500, null, (d, f) =>
            {
                ParentLayout1.TranslationY = _thisContainerHeight;
                System.Diagnostics.Debug.WriteLine("ANIMATION COMPLETED AND REPEATING NOW");

                animate1();
            });
        }
    }
}
