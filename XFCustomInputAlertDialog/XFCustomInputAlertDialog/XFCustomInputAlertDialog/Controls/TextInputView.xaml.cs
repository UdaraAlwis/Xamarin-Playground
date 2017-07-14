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

        public TextInputView(string titleText, string placeHolderText, string closeButtonText)
        {
            InitializeComponent();

            TitleLabel.Text = titleText;
            InputEntry.Placeholder = placeHolderText;
            CloseButton.Text = closeButtonText;

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