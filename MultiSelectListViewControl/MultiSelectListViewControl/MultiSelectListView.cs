using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MultiSelectListViewControl
{
    public class MultiSelectListView : ListView
    {

        public static readonly BindableProperty SelectedItemsProperty =
            BindableProperty.Create(
                nameof(SelectedItems),
                typeof(ObservableCollection<object>),
                typeof(MultiSelectListView),
                new ObservableCollection<object>(), BindingMode.TwoWay);

        public ObservableCollection<object> SelectedItems
        {
            get
            {
                return (ObservableCollection<object>)GetValue(SelectedItemsProperty);
            }
            set
            {
                SetValue(SelectedItemsProperty, value);
            }
        }


        public static readonly BindableProperty ItemSelectedCommandProperty =
            BindableProperty.Create(
                nameof(ItemSelectedCommand),
                typeof(ICommand),
                typeof(MultiSelectListView));
        /// <summary>
        /// Command for handling Item Selected event
        /// </summary>
        public ICommand ItemSelectedCommand
        {
            get
            {
                return (ICommand)GetValue(ItemSelectedCommandProperty);
            }
            set
            {
                SetValue(ItemSelectedCommandProperty, value);
            }
        }

        public MultiSelectListView()
        {
            SelectedItems = new ObservableCollection<object>();
            this.ItemTapped += OnItemTapped;
        }
        
        private void OnItemTapped(object sender, ItemTappedEventArgs itemTappedEventArgs)
        {
            if (itemTappedEventArgs.Item != null)
            {
                if (SelectedItems.All(x => x != itemTappedEventArgs.Item))
                {
                    SelectedItems.Add(itemTappedEventArgs.Item);
                }
                else
                {
                    SelectedItems.Remove(itemTappedEventArgs.Item);
                }

                this.SelectedItem = null;
            }
        }
    }
}
