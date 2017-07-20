using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFCustomInputAlertDialog.InputViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TextInputCancellableView : ContentView
	{
	    // public event handler to expose 
	    // the Save button's click event
	    public EventHandler SaveButtonEventHandler { get; set; }

	    // public event handler to expose 
	    // the Cancel button's click event
        public EventHandler CancelButtonEventHandler { get; set; }

        // public string to expose the 
        // text Entry input's value
        public string TextInputResult { get; set; }

	    public static readonly BindableProperty IsValidationLabelVisibleProperty =
	        BindableProperty.Create(
	            nameof(IsValidationLabelVisible),
	            typeof(bool),
	            typeof(TextInputCancellableView),
	            false, BindingMode.OneWay, null,
	            (bindable, value, newValue) =>
	            {
	                if ((bool)newValue)
	                {
	                    ((TextInputCancellableView)bindable).ValidationLabel
	                        .IsVisible = true;
	                }
	                else
	                {
	                    ((TextInputCancellableView)bindable).ValidationLabel
	                        .IsVisible = false;
	                }
	            });

	    /// <summary>
	    /// Gets or Sets if the ValidationLabel is visible
	    /// </summary>
	    public bool IsValidationLabelVisible
	    {
	        get
	        {
	            return (bool)GetValue(IsValidationLabelVisibleProperty);
	        }
	        set
	        {
	            SetValue(IsValidationLabelVisibleProperty, value);
	        }
	    }

        public TextInputCancellableView(string titleText, string placeHolderText,
            string saveButtonText, string cancelButtonText, string validationText)
        {
            InitializeComponent();

            // update the Element's textual values
            TitleLabel.Text = titleText;
            InputEntry.Placeholder = placeHolderText;
            SaveButton.Text = saveButtonText;
            CancelButton.Text = cancelButtonText;
            ValidationLabel.Text = validationText;

            // handling events to expose to public
            SaveButton.Clicked += SaveButton_Clicked;
		    CancelButton.Clicked += CancelButton_Clicked;
            InputEntry.TextChanged += InputEntry_TextChanged;
	    }

	    private void SaveButton_Clicked(object sender, EventArgs e)
	    {
            // invoke the event handler if its being subscribed
	        SaveButtonEventHandler?.Invoke(this, e);
	    }

	    private void CancelButton_Clicked(object sender, EventArgs e)
	    {
            // invoke the event handler if its being subscribed
	        CancelButtonEventHandler?.Invoke(this, e);
	    }

        private void InputEntry_TextChanged(object sender,
	        TextChangedEventArgs e)
	    {
	        // update the public string value 
	        // accordingly to the text Entry's value
	        TextInputResult = InputEntry.Text;
	    }
    }
}