using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XFShellAppTryOut.Models;
using XFShellAppTryOut.ViewModels;

namespace XFShellAppTryOut.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    [QueryProperty("ItemId", "itemId")]
    public partial class ItemDetailPage : ContentPage
    {
        private ItemDetailViewModel _viewModel;
        private string _itemId;

        public string ItemId
        {
            get => _itemId;
            set => _itemId = Uri.UnescapeDataString(value);
        }

        public ItemDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel = new ItemDetailViewModel(ItemId);
            BindingContext = _viewModel;
        }
    }
}