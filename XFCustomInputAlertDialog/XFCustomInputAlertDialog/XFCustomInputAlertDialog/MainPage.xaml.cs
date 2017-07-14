using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFCustomInputAlertDialog.Controls;

namespace XFCustomInputAlertDialog
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OpenTextInputAlertDialogButton_OnClicked(object sender, EventArgs e)
        {
            var result = await GetUserInput();
        }

        private async Task<string> GetUserInput()
        {
            var inputView = new TextInputView(
                "What's your name?", "enter here...", "Ok", "Ops! Can't leave this empty!");

            var popup = new InputAlertDialogBase<string>(inputView);

            inputView.CloseButtonEventHandler +=
                (sender, obj) =>
                {
                    if (!string.IsNullOrEmpty(((TextInputView)sender).TextInputResult))
                    {
                        ((TextInputView)sender).IsValidationLabelVisible = false;
                        popup.PageClosedTaskCompletionSource.SetResult(((TextInputView)sender).TextInputResult);
                    }
                    else
                    {
                        ((TextInputView)sender).IsValidationLabelVisible = true;
                    }
                };

            await PopupNavigation.PushAsync(popup);

            var result = await popup.PageClosedTask;

            await PopupNavigation.PopAsync();

            return result;
        }

    }
}
