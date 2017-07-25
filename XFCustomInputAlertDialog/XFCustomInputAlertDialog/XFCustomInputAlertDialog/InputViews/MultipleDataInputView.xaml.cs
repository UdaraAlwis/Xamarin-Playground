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
	public partial class MultipleDataInputView : ContentView
	{

        // public event handler to expose 
        // the Save button's click event
        public EventHandler SaveButtonEventHandler { get; set; }

        // public event handler to expose 
        // the Cancel button's click event
        public EventHandler CancelButtonEventHandler { get; set; }

        // public string to expose the 
        // text Entry input's value
        public MyDataModel MultipleDataResult { get; set; }



        public static readonly BindableProperty ValidationLabelTextProperty =
            BindableProperty.Create(
                nameof(ValidationLabelText),
                typeof(string),
                typeof(MultipleDataInputView),
                string.Empty, BindingMode.OneWay, null,
                (bindable, value, newValue) =>
                {
                    ((MultipleDataInputView)bindable).ValidationLabel
                        .Text = (string)newValue;
                });

        /// <summary>
        /// Gets or Sets the ValidationLabel Text
        /// </summary>
        public string ValidationLabelText
        {
            get
            {
                return (string)GetValue(ValidationLabelTextProperty);
            }
            set
            {
                SetValue(ValidationLabelTextProperty, value);
            }
        }



        public static readonly BindableProperty IsValidationLabelVisibleProperty =
            BindableProperty.Create(
                nameof(IsValidationLabelVisible),
                typeof(bool),
                typeof(MultipleDataInputView),
                false, BindingMode.OneWay, null,
                (bindable, value, newValue) =>
                {
                    if ((bool)newValue)
                    {
                        ((MultipleDataInputView)bindable).ValidationLabel
                            .IsVisible = true;
                    }
                    else
                    {
                        ((MultipleDataInputView)bindable).ValidationLabel
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


        public MultipleDataInputView
            (string title1Text, string title2Text,
            string entry1PlaceholderValue, string entry2PlaceholderValue,
            double sliderMinValue, double sliderMaxValue,
            string saveButtonText, string cancelButtonText)
        {
			InitializeComponent ();

            // update the Element's textual values
            TitleLabel1.Text = title1Text;
            TitleLabel2.Text = title2Text;
            TextEntry1.Placeholder = entry1PlaceholderValue;
            TextEntry2.Placeholder = entry2PlaceholderValue;
            AgeSlider.Minimum = sliderMinValue;
            AgeSlider.Maximum = sliderMaxValue;
            SaveButton.Text = saveButtonText;
            CancelButton.Text = cancelButtonText;

            // handling events to expose to public
            SaveButton.Clicked += SaveButton_Clicked;
            CancelButton.Clicked += CancelButton_Clicked;
            TextEntry1.TextChanged += TextEntry1_TextChanged;
            TextEntry2.TextChanged += TextEntry2_TextChanged;
            AgeSlider.ValueChanged += InputEntryOnValueChanged;

            MultipleDataResult = new MyDataModel();
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

        private void TextEntry1_TextChanged(object sender, TextChangedEventArgs e)
        {
            MultipleDataResult.FirstName = TextEntry1.Text;
        }

        private void TextEntry2_TextChanged(object sender, TextChangedEventArgs e)
        {
            MultipleDataResult.LastName = TextEntry2.Text;
        }

        private void InputEntryOnValueChanged(object sender, ValueChangedEventArgs valueChangedEventArgs)
        {
            InputSliderValueLabel.Text = $"[ { Math.Round(AgeSlider.Value).ToString()} ]";
            MultipleDataResult.Age = (int)Math.Round(AgeSlider.Value);
        }
    }

    public class MyDataModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}