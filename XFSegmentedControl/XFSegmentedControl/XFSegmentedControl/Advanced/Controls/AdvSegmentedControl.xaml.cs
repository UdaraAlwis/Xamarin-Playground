using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFSegmentedControl.Simple;
using XFSegmentedControl.Simple.Controls;

namespace XFSegmentedControl.Advanced.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdvSegmentedControl : ContentView
	{
	    public static readonly BindableProperty PrimaryColorProperty
	        = BindableProperty.Create(
	            nameof(PrimaryColor),
	            typeof(Color),
	            typeof(AdvSegmentedControl),
	            Color.CornflowerBlue,
	            propertyChanged: (bindable, value, newValue) =>
	            {
	                foreach (var tabButton in ((AdvSegmentedControl) bindable).TabButtonHolder.Children)
	                {
	                    ((TabButton) tabButton).UpdateTabButtonColors(((Color) newValue),
	                        ((AdvSegmentedControl) bindable).SecondaryColor);

	                    ((TabButton) tabButton).UpdateTabButtonState(
	                        ((AdvSegmentedControl) bindable).SelectedTabIndex);
	                }
	            },
	            defaultBindingMode: BindingMode.TwoWay);

        public Color PrimaryColor
	    {
	        get { return (Color)GetValue(PrimaryColorProperty); }
	        set { SetValue(PrimaryColorProperty, value); }
	    }


	    public static readonly BindableProperty SecondaryColorProperty
	        = BindableProperty.Create(
	            nameof(SecondaryColor),
	            typeof(Color),
	            typeof(AdvSegmentedControl),
	            Color.White,
	            propertyChanged: (bindable, value, newValue) =>
	            {
                    if (Device.RuntimePlatform == Device.iOS)
	                {
	                    ((AdvSegmentedControl)bindable).FrameView.BorderColor = ((Color)newValue);
	                }

	                foreach (var tabButton in ((AdvSegmentedControl) bindable).TabButtonHolder.Children)
	                {
	                    ((TabButton) tabButton).UpdateTabButtonColors(
	                        ((AdvSegmentedControl) bindable).PrimaryColor, ((Color) newValue));

	                    ((TabButton) tabButton).UpdateTabButtonState(
	                        ((AdvSegmentedControl) bindable).SelectedTabIndex);
	                }
	            },
	            defaultBindingMode:BindingMode.TwoWay);

        public Color SecondaryColor
	    {
	        get { return (Color)GetValue(SecondaryColorProperty); }
	        set { SetValue(SecondaryColorProperty, value); }
	    }


        public static readonly BindableProperty SelectedTabIndexProperty
            = BindableProperty.Create(
                nameof(SelectedTabIndex),
                typeof(int),
                typeof(AdvSegmentedControl),
                0);

        public int SelectedTabIndex
        {
            get { return (int)GetValue(SelectedTabIndexProperty); }
            private set { SetValue(SelectedTabIndexProperty, value); }
        }


        public static readonly BindableProperty TabButtonsSourceProperty
            = BindableProperty.Create(
                nameof(TabButtonsSource),
                typeof(IEnumerable), 
                typeof(AdvSegmentedControl),
                null,
        propertyChanged: OnTabButtonsPropertyChanged,
        defaultBindingMode: BindingMode.TwoWay);

        public IEnumerable TabButtonsSource
        {
            get { return (IEnumerable)GetValue(TabButtonsSourceProperty); }
            set { SetValue(TabButtonsSourceProperty, value); }
        }

        static void OnTabButtonsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                // handle new items
                
                ((AdvSegmentedControl)bindable).TabButtonHolder.Children?.Clear();

                int index = 0;
                foreach (var item in (IEnumerable) newValue)
                {
                    var newTab = new TabButton(
                        item.ToString(),
                        index, 
                        ((AdvSegmentedControl)bindable).PrimaryColor, 
                        ((AdvSegmentedControl)bindable).SecondaryColor,
                        (index == ((AdvSegmentedControl)bindable).SelectedTabIndex));

                    newTab.TabButtonClicked += (sender, args) =>
                    {
                        foreach (var tabButton in ((AdvSegmentedControl)bindable).TabButtonHolder.Children)
                            ((TabButton) tabButton).UpdateTabButtonState(((TabButton) sender).TabIndex);
                        
                        ((AdvSegmentedControl)bindable).SelectedTabIndex = ((TabButton)sender).TabIndex;
                        ((AdvSegmentedControl)bindable).SendSelectedTabIndexChangedEvent();
                    };
                    
                    Grid.SetColumn(newTab, index++);

                    ((AdvSegmentedControl)bindable).SelectedTabIndex = 0;
                    ((AdvSegmentedControl)bindable).SendSelectedTabIndexChangedEvent();
                }
                
                ((AdvSegmentedControl)bindable).SelectedTabIndex = 0;
            }
            else
            {
                ((AdvSegmentedControl)bindable).TabButtonHolder.Children?.Clear();
            }
        }

        public AdvSegmentedControl ()
		{
			InitializeComponent ();

		    if (Device.RuntimePlatform == Device.iOS)
		    {
		        FrameView.BorderColor = SecondaryColor;
		    }
        }
        
	    public event EventHandler<SelectedTabIndexEventArgs> SelectedTabIndexChanged;

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