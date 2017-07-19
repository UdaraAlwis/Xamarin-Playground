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
    public partial class TextInputView : ContentView
    {
        // public event handler to expose 
        // the Ok button's click event
        public EventHandler CloseButtonEventHandler { get; set; }

        // public string to expose the 
        // text Entry input's value
        public string TextInputResult { get; set; }
        
        public static readonly BindableProperty IsValidationLabelVisibleProperty =
            BindableProperty.Create(
                nameof(IsValidationLabelVisible),
                typeof(bool),
                typeof(TextInputView),
                false, BindingMode.OneWay, null,
                (bindable, value, newValue) =>
                {
                    if ((bool)newValue)
                    {
                        ((TextInputView)bindable).ValidationLabel
                            .IsVisible = true;
                    }
                    else
                    {
                        ((TextInputView)bindable).ValidationLabel
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

        public TextInputView(string titleText, string placeHolderText, 
            string closeButtonText, string validationLabelText)
        {
            InitializeComponent();

            // update the Element's textual values
            TitleLabel.Text = titleText;
            InputEntry.Placeholder = placeHolderText;
            CloseButton.Text = closeButtonText;
            ValidationLabel.Text = validationLabelText;

            // handling events to expose to public
            CloseButton.Clicked += CloseButton_Clicked;
            InputEntry.TextChanged += InputEntry_TextChanged;
        }

        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            // invoke the event handler if its being subscribed
            CloseButtonEventHandler?.Invoke(this, e);
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