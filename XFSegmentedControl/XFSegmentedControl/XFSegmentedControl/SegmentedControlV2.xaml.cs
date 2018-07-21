using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSegmentedControl
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SegmentedControlV2 : ContentView
	{
        public static readonly BindableProperty SelectedTabIndexProperty
            = BindableProperty.Create(
                nameof(SelectedTabIndex),
                typeof(int),
                typeof(SegmentedControlV2),
                1);

        public int SelectedTabIndex
        {
            get { return (int)GetValue(SelectedTabIndexProperty); }
            private set { SetValue(SelectedTabIndexProperty, value); }
        }


        public static readonly BindableProperty TabButtonsProperty 
            = BindableProperty.Create(
                nameof(TabButtons),
                typeof(IEnumerable), 
                typeof(SegmentedControlV2),
                null,
        propertyChanged: OnTabButtonsPropertyChanged);

        public IEnumerable TabButtons
        {
            get { return (IEnumerable)GetValue(TabButtonsProperty); }
            set { SetValue(TabButtonsProperty, value); }
        }

        static void OnTabButtonsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (oldValue != null)
            {
                // handle old items if you need
            }

            if (newValue != null)
            {
                // handle new items
            }
        }


        public event EventHandler<SelectedTabIndexEventArgs> SelectedTabIndexChanged;



        public SegmentedControlV2 ()
		{
			InitializeComponent ();
		}

        /// <summary>
        /// Invoke the SelectedTabIndexChanged event
        /// for whoever has subscribed so they can
        /// use it for any reative action
        /// </summary>
        private void SendSelectedTabIndexChangedEvent()
        {
            var eventArgs = new SelectedTabIndexEventArgs();
            eventArgs.SelectedTabIndex = SelectedTabIndex;

            SelectedTabIndexChanged?.Invoke(this, eventArgs);
        }
    }
}