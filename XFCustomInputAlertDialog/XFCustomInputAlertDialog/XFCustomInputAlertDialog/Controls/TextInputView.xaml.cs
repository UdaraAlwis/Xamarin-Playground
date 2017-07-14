using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFCustomInputAlertDialog.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TextInputView : ContentView
    {
        public EventHandler CloseButtonEventHandler { get; set; }

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
                        ((TextInputView)bindable).ValidationLabel.IsVisible = true;
                    }
                    else
                    {
                        ((TextInputView)bindable).ValidationLabel.IsVisible = false;
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

        public TextInputView(string titleText, string placeHolderText, string closeButtonText, string validationLabelText)
        {
            InitializeComponent();

            TitleLabel.Text = titleText;
            InputEntry.Placeholder = placeHolderText;
            CloseButton.Text = closeButtonText;
            ValidationLabel.Text = validationLabelText;

            CloseButton.Clicked += CloseButton_Clicked;
            InputEntry.TextChanged += InputEntry_TextChanged;
        }

        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            CloseButtonEventHandler?.Invoke(this, e);
        }

        private void InputEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextInputResult = InputEntry.Text;
        }
    }
}