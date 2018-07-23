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
	    public static readonly BindableProperty PrimaryColorProperty
	        = BindableProperty.Create(
	            nameof(PrimaryColor),
	            typeof(Color),
	            typeof(SegmentedControlV2),
	            Color.CornflowerBlue);

	    public Color PrimaryColor
	    {
	        get { return (Color)GetValue(PrimaryColorProperty); }
	        set { SetValue(PrimaryColorProperty, value); }
	    }


	    public static readonly BindableProperty SecondaryColorProperty
	        = BindableProperty.Create(
	            nameof(SecondaryColor),
	            typeof(Color),
	            typeof(SegmentedControlV2),
	            Color.White);

	    public Color SecondaryColor
	    {
	        get { return (Color)GetValue(SecondaryColorProperty); }
	        set { SetValue(SecondaryColorProperty, value); }
	    }


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
            if (newValue != null)
            {
                // handle new items
                
                ((SegmentedControlV2)bindable).TabButtonHolder.Children?.Clear();

                int index = 0;
                foreach (var item in (IEnumerable) newValue)
                {
                    var newTab = new TabButton(
                        item.ToString(),
                        index, 
                        ((SegmentedControlV2)bindable).PrimaryColor, 
                        ((SegmentedControlV2)bindable).SecondaryColor,
                        (index == 0));

                    newTab.TabButtonClicked += (sender, args) =>
                    {
                        foreach (var tabButton in ((SegmentedControlV2)bindable).TabButtonHolder.Children)
                            ((TabButton) tabButton).UpdateTabButtonState(((TabButton) sender).TabIndex);
                        
                        ((SegmentedControlV2)bindable).SelectedTabIndex = ((TabButton)sender).TabIndex;
                        ((SegmentedControlV2)bindable).SendSelectedTabIndexChangedEvent();
                    };
                    
                    Grid.SetColumn(newTab, index++);

                    ((SegmentedControlV2)bindable).TabButtonHolder.Children.Add(newTab);
                }


            }
        }


	    public event EventHandler<SelectedTabIndexEventArgs> SelectedTabIndexChanged;

        
        public SegmentedControlV2 ()
		{
			InitializeComponent ();
            
		    if (Device.RuntimePlatform == Device.iOS)
		    {
		        FrameView.BorderColor = SecondaryColor;
		    }
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