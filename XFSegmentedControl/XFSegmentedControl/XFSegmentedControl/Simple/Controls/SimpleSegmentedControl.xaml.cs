using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSegmentedControl.Simple.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SimpleSegmentedControl : ContentView
    {
        public static readonly BindableProperty PrimaryColorProperty
            = BindableProperty.Create(
                nameof(PrimaryColor),
                typeof(Color),
                typeof(SimpleSegmentedControl),
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
	            typeof(SimpleSegmentedControl),
	            Color.White);

	    public Color SecondaryColor
	    {
	        get { return (Color)GetValue(SecondaryColorProperty); }
	        set { SetValue(SecondaryColorProperty, value); }
	    }


        public static readonly BindableProperty Tab1TextProperty
            = BindableProperty.Create(
                nameof(Tab1Text),
                typeof(string),
                typeof(SimpleSegmentedControl),
                "Tab 1");

        public string Tab1Text
        {
            get { return (string)GetValue(Tab1TextProperty); }
            set { SetValue(Tab1TextProperty, value); }
        }


        public static readonly BindableProperty Tab2TextProperty
            = BindableProperty.Create(
                nameof(Tab2Text),
                typeof(string),
                typeof(SimpleSegmentedControl),
                "Tab 2");

        public string Tab2Text
        {
            get { return (string)GetValue(Tab2TextProperty); }
            set { SetValue(Tab2TextProperty, value); }
        }


        public static readonly BindableProperty SelectedTabIndexProperty
            = BindableProperty.Create(
                nameof(SelectedTabIndex),
                typeof(int),
                typeof(SimpleSegmentedControl),
                0);
        
        public int SelectedTabIndex
        {
            get { return (int)GetValue(SelectedTabIndexProperty); }
            private set { SetValue(SelectedTabIndexProperty, value); }
        }

        public event EventHandler<SelectedTabIndexEventArgs> SelectedTabIndexChanged;

        public SimpleSegmentedControl()
		{
			InitializeComponent();
        }

        /// <summary>
        /// load up the customizations and applying
        /// properties when the element has rendered
        /// </summary>
        protected override void OnParentSet()
        {
            base.OnParentSet();
            
            // Setting up platform specific properties for Android and iOS
            if (Device.RuntimePlatform == Device.Android)
            {
                Tab1LabelView.FontSize
                    = Device.GetNamedSize(NamedSize.Medium, Tab1LabelView);
                Tab2LabelView.FontSize
                    = Device.GetNamedSize(NamedSize.Medium, Tab1LabelView);

                Tab1ButtonView.BackgroundColor = PrimaryColor;
                Tab2ButtonView.BackgroundColor = PrimaryColor;

                Tab1BoxView.Color =
                Tab2BoxView.Color =
                Tab1LabelView.TextColor =
                Tab2LabelView.TextColor = SecondaryColor;
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                Tab1LabelView.FontSize
                    = Device.GetNamedSize(NamedSize.Small, Tab1LabelView);
                Tab2LabelView.FontSize
                    = Device.GetNamedSize(NamedSize.Small, Tab1LabelView);

                Tab1ButtonView.BackgroundColor =
                Tab2ButtonView.BackgroundColor = PrimaryColor;

                FrameView.BorderColor =
                Tab1LabelView.TextColor =
                Tab2LabelView.TextColor = SecondaryColor;
            }

            Tab1LabelView.Text = Tab1Text;
            Tab2LabelView.Text = Tab2Text;

            // setting up default values
            SelectTab1();
            SelectedTabIndex = 0;
            SendSelectedTabIndexChangedEvent();
        }

        private void Tab1Button_OnClicked(object sender, EventArgs e)
	    {
            SelectTab1();
	        SelectedTabIndex = 0;
            SendSelectedTabIndexChangedEvent();
        }

        private void Tab2Button_OnClicked(object sender, EventArgs e)
        {
            SelectTab2();
            SelectedTabIndex = 1;
            SendSelectedTabIndexChangedEvent();
        }
        
        private void SelectTab1()
        {
            // set up platform specific
            // properties for SelectTab1 event
            if (Device.RuntimePlatform == Device.Android)
            {
                Tab1BoxView.IsVisible = true;
                Tab2BoxView.IsVisible = false;
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                Tab1ButtonView.BackgroundColor = SecondaryColor;
                Tab2ButtonView.BackgroundColor = PrimaryColor;

                Tab1LabelView.TextColor = PrimaryColor;
                Tab2LabelView.TextColor = SecondaryColor;
            }
        }

        private void SelectTab2()
        {
            // set up platform specific
            // properties for SelectTab2 event
            if (Device.RuntimePlatform == Device.Android)
            {
                Tab1BoxView.IsVisible = false;
                Tab2BoxView.IsVisible = true;
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                Tab1ButtonView.BackgroundColor = PrimaryColor;
                Tab2ButtonView.BackgroundColor = SecondaryColor;

                Tab1LabelView.TextColor = SecondaryColor;
                Tab2LabelView.TextColor = PrimaryColor;
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

    public class SelectedTabIndexEventArgs : EventArgs
    {
        public int SelectedTabIndex { get; set; }
    }
}