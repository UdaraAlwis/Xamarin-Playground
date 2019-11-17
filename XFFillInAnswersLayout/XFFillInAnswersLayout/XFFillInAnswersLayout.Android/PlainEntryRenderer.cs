using Android.Content;
using XFFillInAnswersLayout;
using XFFillInAnswersLayout.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(PlainEntry), typeof(PlainEntryRenderer))]
namespace XFFillInAnswersLayout.Droid
{
    public class PlainEntryRenderer : EntryRenderer
    {
        public PlainEntryRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
                return;
            }

            Control.SetPadding(0, 0, 0, 0); // remove the padding
            Control.SetBackgroundResource(Android.Resource.Color.Transparent); // remove the horizontal stroke
        }
    }
}