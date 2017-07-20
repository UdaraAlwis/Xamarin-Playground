using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFCustomInputAlertDialog.InputViews;

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
            InputResultLabel.Text = "Waiting for result...";
            var result = await OpenTextInputAlertDialog();
            InputResultLabel.Text = $"-{result}-";
        }

        private async void OpenCancellableTextInputAlertDialogButton_OnClicked(object sender, EventArgs e)
        {
            InputResultLabel.Text = "Waiting for result...";
            var result = await OpenCancellableTextInputAlertDialog();
            InputResultLabel.Text = $"-{result}-";
        }


        private async Task<string> OpenTextInputAlertDialog()
        {
            // create the TextInputView
            var inputView = new TextInputView(
                "What's your name?", "enter here...", "Ok", "Ops! Can't leave this empty!");

            // create the Transparent Popup Page
            // of type string since we need a string return
            var popup = new InputAlertDialogBase<string>(inputView);

            // subscribe to the TextInputView's Button click event
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

            // Push the page to Navigation Stack
            await PopupNavigation.PushAsync(popup);

            // await for the user to enter the text input
            var result = await popup.PageClosedTask;

            // Pop the page from Navigation Stack
            await PopupNavigation.PopAsync();

            // return user inserted text value
            return result;
        }

        private async Task<string> OpenCancellableTextInputAlertDialog()
        {
            // create the TextInputView
            var inputView = new TextInputCancellableView(
                "How's your day mate?", "enter here...", "Save", "Cancel", "Ops! Can't leave this empty!");

            // create the Transparent Popup Page
            // of type string since we need a string return
            var popup = new InputAlertDialogBase<string>(inputView);

            // subscribe to the TextInputView's Button click event
            inputView.SaveButtonEventHandler +=
                (sender, obj) =>
                {
                    if (!string.IsNullOrEmpty(((TextInputCancellableView)sender).TextInputResult))
                    {
                        ((TextInputCancellableView)sender).IsValidationLabelVisible = false;
                        popup.PageClosedTaskCompletionSource.SetResult(((TextInputCancellableView)sender).TextInputResult);
                    }
                    else
                    {
                        ((TextInputCancellableView)sender).IsValidationLabelVisible = true;
                    }
                };

            // subscribe to the TextInputView's Button click event
            inputView.CancelButtonEventHandler +=
                (sender, obj) =>
                {
                    popup.PageClosedTaskCompletionSource.SetResult(null);
                };

            // Push the page to Navigation Stack
            await PopupNavigation.PushAsync(popup);

            // await for the user to enter the text input
            var result = await popup.PageClosedTask;

            // Pop the page from Navigation Stack
            await PopupNavigation.PopAsync();

            // return user inserted text value
            return result;
        }
    }
}
