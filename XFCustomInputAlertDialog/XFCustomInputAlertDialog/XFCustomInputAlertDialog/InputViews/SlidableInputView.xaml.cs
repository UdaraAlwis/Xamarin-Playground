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
	public partial class SlidableInputView : ContentView
	{
	    // public event handler to expose 
	    // the Save button's click event
	    public EventHandler SaveButtonEventHandler { get; set; }

	    // public event handler to expose 
	    // the Cancel button's click event
	    public EventHandler CancelButtonEventHandler { get; set; }

	    // public string to expose the 
	    // text Entry input's value
	    public double SliderInputResult { get; set; }

	    public static readonly BindableProperty IsValidationLabelVisibleProperty =
	        BindableProperty.Create(
	            nameof(IsValidationLabelVisible),
	            typeof(bool),
	            typeof(SlidableInputView),
	            false, BindingMode.OneWay, null,
	            (bindable, value, newValue) =>
	            {
	                if ((bool)newValue)
	                {
	                    ((SlidableInputView)bindable).ValidationLabel
	                        .IsVisible = true;
	                }
	                else
	                {
	                    ((SlidableInputView)bindable).ValidationLabel
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

        public SlidableInputView (string titleText, double minValue, double maxValue,
            string saveButtonText, string cancelButtonText, string validationText)
		{
			InitializeComponent ();

		    // update the Element's textual values
		    TitleLabel.Text = titleText;
		    SaveButton.Text = saveButtonText;
		    InputSlider.Minimum = minValue;
		    InputSlider.Maximum = maxValue;
            CancelButton.Text = cancelButtonText;
		    ValidationLabel.Text = validationText;

		    // handling events to expose to public
		    SaveButton.Clicked += SaveButton_Clicked;
		    CancelButton.Clicked += CancelButton_Clicked;
		    InputSlider.ValueChanged += InputEntryOnValueChanged;
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

	    private void InputEntryOnValueChanged(object sender, ValueChangedEventArgs valueChangedEventArgs)
	    {
	        InputSliderValueLabel.Text = $"[ {InputSlider.Value.ToString("##.##")} ]";
            SliderInputResult = Math.Round(InputSlider.Value, 2, MidpointRounding.AwayFromZero);
	    }

    }
}