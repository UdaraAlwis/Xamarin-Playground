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
        private readonly ItemDetailViewModel _viewModel;

        public string ItemId { get; set; }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            _viewModel = new ItemDetailViewModel(item);
            BindingContext = _viewModel;
        }
    }
}