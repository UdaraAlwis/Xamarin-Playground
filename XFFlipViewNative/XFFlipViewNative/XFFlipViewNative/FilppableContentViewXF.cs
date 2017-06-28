using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XFFlipViewNative
{
    /// <summary>
    /// Behold the cool Flip animated View
    /// handle with care! explosive awesomeness!
    /// </summary>
    public class FilppableContentViewXF : ContentView
    {
        private readonly RelativeLayout _contentHolder;

        public ICommand FlipThisShyiatFrontToBack;

        public ICommand FlipThisShyiatBackToFront;

        public FilppableContentViewXF()
        {
            _contentHolder = new RelativeLayout();
            Content = _contentHolder;
        }

        public static readonly BindableProperty FrontViewProperty =
        BindableProperty.Create(
            nameof(FrontView),
            typeof(View),
            typeof(FilppableContentViewXF),
            null,
            BindingMode.Default,
            null,
            FrontViewPropertyChanged);

        private static void FrontViewPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                ((FilppableContentViewXF)bindable)
                    ._contentHolder
                    .Children
                    .Add(((FilppableContentViewXF)bindable).FrontView,
                    Constraint.RelativeToParent((parent) => 0)
                    );
            }
        }

        /// <summary>
        /// Gets or Sets the front view
        /// </summary>
        public View FrontView
        {
            get { return (View)this.GetValue(FrontViewProperty); }
            set { this.SetValue(FrontViewProperty, value); }
        }



        public static readonly BindableProperty BackViewProperty =
        BindableProperty.Create(
            nameof(BackView),
            typeof(View),
            typeof(FilppableContentViewXF),
            null,
            BindingMode.Default,
            null,
            BackViewPropertyChanged);

        private static void BackViewPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            //Set BackView Rotation before rotating
            if (newvalue != null)
            {
                ((FilppableContentViewXF)bindable)
                       ._contentHolder
                       .Children
                       .Add(((FilppableContentViewXF)bindable).BackView,
                       Constraint.RelativeToParent((parent) => 0)
                       );

                ((FilppableContentViewXF)bindable).BackView.IsVisible = false;
            }
        }

        /// <summary>
        /// Gets or Sets the back view
        /// </summary>
        public View BackView
        {
            get { return (View)this.GetValue(BackViewProperty); }
            set { this.SetValue(BackViewProperty, value); }
        }



        public static readonly BindableProperty IsFlippedProperty =
        BindableProperty.Create(
            nameof(IsFlipped),
            typeof(bool),
            typeof(FilppableContentViewXF),
            false,
            BindingMode.Default,
            null,
            IsFlippedPropertyChanged);

        /// <summary>
        /// Gets or Sets whether the view is already flipped
        /// ex : 
        /// </summary>
        public bool IsFlipped
        {
            get { return (bool)this.GetValue(IsFlippedProperty); }
            set { this.SetValue(IsFlippedProperty, value); }
        }

        private static void IsFlippedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if ((bool)newValue)
            {
                ((FilppableContentViewXF)bindable).FlipFromFrontToBack();
            }
            else
            {
                ((FilppableContentViewXF)bindable).FlipFromBackToFront();
            }
        }


        #region Android Animation Stuff

        public void SwitchViewsFlipFromFrontToBack()
        {
            this.FrontView.IsVisible = false;
            this.BackView.IsVisible = true;
        }

        public void SwitchViewsFlipFromBackToFront()
        {
            this.FrontView.IsVisible = true;
            this.BackView.IsVisible = false;
        }

        private void FlipFromFrontToBack()
        {
            FlipThisShyiatFrontToBack?.Execute(null);
        }

        private void FlipFromBackToFront()
        {
            FlipThisShyiatBackToFront?.Execute(null);
        }

        #endregion



        #region iOS Animation Stuff

        private async Task<bool> FrontToBackRotate()
        {
            this.RotationY = 360;

            await this.RotateYTo(270, 250, Easing.Linear);

            return true;
        }

        private async Task<bool> BackToFrontRotate()
        {
            ViewExtensions.CancelAnimations(this);

            this.RotationY = 90;

            await this.RotateYTo(0, 250, Easing.Linear);

            return true;
        }

        #endregion
    }
}
