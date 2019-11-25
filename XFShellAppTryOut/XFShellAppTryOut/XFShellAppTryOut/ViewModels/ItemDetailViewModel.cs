using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFShellAppTryOut.Models;

namespace XFShellAppTryOut.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public Command<string> LoadItemsCommand { get; set; }

        public ItemDetailViewModel(string itemId = null)
        {
            LoadItemsCommand = new Command<string>(async (obj) => await ExecuteLoadItemCommand(obj));

            LoadItemsCommand.Execute(itemId);
        }

        async Task ExecuteLoadItemCommand(string itemId)
        {
            var item = await DataStore.GetItemAsync(itemId.ToString());

            Title = item?.Text;
            Item = item;
        }
    }
}
