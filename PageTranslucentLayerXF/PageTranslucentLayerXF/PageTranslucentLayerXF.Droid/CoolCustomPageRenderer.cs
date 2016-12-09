using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PageTranslucentLayerXF;
using PageTranslucentLayerXF.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Image = Android.Media.Image;

[assembly: ExportRenderer(typeof(CoolCustomPage), typeof(CoolCustomPageRenderer))]
namespace PageTranslucentLayerXF.Droid
{
    public class CoolCustomPageRenderer : PageRenderer
    {
        private ProgressDialog progressDialog;

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            //if (e.NewElement != null)
            //{
            //    ((CoolCustomPage)e.NewElement).PropertyChanged += OnPropertyChanged;

            //    Toolbar toolBar = new Toolbar(this.Context);

            //    if (((Activity) Context).ActionBar != null)
            //    {
            //        ((Activity) Context).ActionBar.DisplayOptions = ActionBarDisplayOptions.ShowCustom;
            //    }
            //}
            //if (e.OldElement != null)
            //{
            //    ((CoolCustomPage)e.OldElement).PropertyChanged -= OnPropertyChanged;
            //}
        }

        public override void BringToFront()
        {
            base.BringToFront();
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "Renderer")
            {

                //var actionBar = ((Activity)Context).ActionBar;
                //actionBar.Hide();
                //actionBar.SetIcon(new ColorDrawable(Xamarin.Forms.Color.Transparent.ToAndroid()));

            }

            if (propertyChangedEventArgs.PropertyName == "TranslucentPageBlock")
            {
                //var pageView = ((Activity)Context).Window.DecorView.RootView;


                //ImageView hoverLayout = new ImageView(this.Context);

                //hoverLayout.LayoutParameters =
                //    new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent,
                //        ViewGroup.LayoutParams.MatchParent);
                //hoverLayout.Background = new ColorDrawable(Android.Graphics.Color.ParseColor("#ff305d"));
                

                //var RootView = this.RootView;

                //var firstChild = this.ViewGroup.GetChildAt(0);

                //this.ViewGroup.ChildViewAdded += ViewGroup_ChildViewAdded;
                //this.ViewGroup.AddView(hoverLayout, 1);

                //hoverLayout.BringToFront();


                //((Activity)Context).SetContentView(hoverLayout);


                ////Create a new progress dialog  
                //progressDialog = new ProgressDialog(this.Context);
                ////Set the progress dialog to display a horizontal progress bar  
                //progressDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
                ////Set the dialog title to 'Loading...'  
                //progressDialog.SetTitle("Loading...");
                ////Set the dialog message to 'Loading application View, please wait...'  
                //progressDialog.SetMessage("Loading application View, please wait...");
                ////This dialog can't be canceled by pressing the back key  
                //progressDialog.SetCancelable(false);
                ////This dialog isn't indeterminate  
                //progressDialog.Indeterminate = false;
                ////The maximum number of items is 100  
                //progressDialog.Max = 100;
                ////Set the current progress to zero  
                //progressDialog.Progress = 0;
                ////Display the progress dialog  
                //progressDialog.Show();
            }
        }

        private void ViewGroup_ChildViewAdded(object sender, ChildViewAddedEventArgs e)
        {

        }
    }
}