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

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var result = await GetUserInput();
        }

        private async Task<string> GetUserInput()
        {
            var inputView = new TextInputView(
                "What's your name?", "enter here...", "Ok");

            var popup = new InputAlertDialogBase<string>(inputView);

            inputView.CloseButtonEventHandler +=
            (sender, obj) =>
            {
                popup.PageClosedTaskCompletionSource.SetResult(((TextInputView)sender).TextInputResult);
            };

            await PopupNavigation.PushAsync(popup);

            var result = await popup.PageClosedTask;

            await PopupNavigation.PopAsync();

            return result;
        }
    }
}
