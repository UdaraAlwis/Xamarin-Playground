using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFShellAppTryOut.Models;

namespace XFShellAppTryOut.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        public Item Item { get; set; }

        public NewItemViewModel()
        {
            Item = new Item
            {
                Id = Guid.NewGuid().ToString(),
                Text = "Item name",
                Description = "This is an item description."
            };;
        }
    }
}
