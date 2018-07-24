using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSegmentedControl.Advanced
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TabButton : Grid
	{
        public event EventHandler<EventArgs> TabButtonClicked;

	    public string TabText { get; private set; }

        public int TabIndex { get; private set; }

	    public Color PrimaryColor { get; private set; }

	    public Color SecondaryColor { get; private set; }

	    public TabButton(string tabText, int tabIndex, Color primaryColor,
	        Color secondaryColor, bool isSelectedByDefault)
        {
			InitializeComponent ();

            TabText = tabText;
            TabIndex = tabIndex;
            PrimaryColor = primaryColor;
            SecondaryColor = secondaryColor;
            
            TabLabelView.Text = TabText;

            SetUpColorScheme();

            if (isSelectedByDefault)
                TabButtonView.SendClicked();
        }

	    private void SetUpColorScheme()
	    {
	        // Setting up platform specific properties for Android and iOS
	        if (Device.RuntimePlatform == Device.Android)
	        {
	            TabLabelView.FontSize
	                = Device.GetNamedSize(NamedSize.Medium, TabLabelView);

	            TabButtonView.BackgroundColor = PrimaryColor;

	            TabBoxView.Color =
	                TabLabelView.TextColor = SecondaryColor;
	        }
	        else if (Device.RuntimePlatform == Device.iOS)
	        {
	            TabLabelView.FontSize
	                = Device.GetNamedSize(NamedSize.Small, TabLabelView);

	            TabButtonView.BackgroundColor = PrimaryColor;
	            TabLabelView.TextColor = SecondaryColor;
	        }
        }

        private void TabButton_OnClicked(object sender, EventArgs e)
        {
            // set up platform specific
            // properties for SelectTab2 event
            if (Device.RuntimePlatform == Device.Android)
            {
                TabBoxView.IsVisible = true;
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                TabButtonView.BackgroundColor = SecondaryColor;

                TabLabelView.TextColor = PrimaryColor;
            }

            SendTabButtonClicked();
        }

	    private void SendTabButtonClicked()
	    {
	        TabButtonClicked?.Invoke(this, EventArgs.Empty);
        }

	    public void UpdateTabButtonState(int selectedTabIndex)
	    {
	        if (selectedTabIndex != TabIndex)
	        {
	            // set up platform specific
	            // properties for SelectTab1 event
	            if (Device.RuntimePlatform == Device.Android)
	            {
	                TabBoxView.IsVisible = false;
	            }
	            else if (Device.RuntimePlatform == Device.iOS)
	            {
	                TabButtonView.BackgroundColor = PrimaryColor;
                    
	                TabLabelView.TextColor = SecondaryColor;
	            }
            }
	    }

	    public void UpdateTabButtonColors(Color primaryColor, Color secondaryColor)
	    {
	        PrimaryColor = primaryColor;
	        SecondaryColor = secondaryColor;

	        SetUpColorScheme();
	    }
    }
}