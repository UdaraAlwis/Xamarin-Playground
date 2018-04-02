using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MultiSelectListViewControl
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private User _selectedItem;

        public User SelectedItem
        {
            get => _selectedItem;

            set
            {
                _selectedItem = value;

                if (_selectedItem != null)
                {
                    var result = Data.First(x => x.Name == _selectedItem.Name);
                    result.IsSelected = !result.IsSelected;
                }

                NotifyPropertyChanged(nameof(SelectedItem));
            }
        }

        public MainPageViewModel()
        {
            Data = new ObservableCollection<User>()
            {
                new User{ Name = "Eliana Hood"},
                new User{ Name = "Miranda Martinez"},
                new User{ Name = "Ahmed Marsh"},
                new User{ Name = "Karina Barr"},
                new User{ Name = "Forrest Grimes"},
                new User{ Name = "Yetta Alexander"},
                new User{ Name = "Finn Cobb"},
                new User{ Name = "Cheyenne Cochran"},
                new User{ Name = "Galena Mckinney"},
                new User{ Name = "Perry Daniels"},
                new User{ Name = "Lucy Ward"},
                new User{ Name = "Savannah Murray"},
                new User{ Name = "Harrison Calhoun"},
                new User{ Name = "Zorita Horn"},
                new User{ Name = "Maia Stanley"},
                new User{ Name = "Blake Morgan"},
                new User{ Name = "Nicole Pena"},
                new User{ Name = "Vance Pacheco"},
            };
        }

        public ObservableCollection<User> Data { get; set; }
    }

    public class User : INotifyPropertyChanged
    {
        private bool _isSelected;

        public string Name { get; set; }

        public bool IsSelected
        {
            get => _isSelected;

            set {
                _isSelected = value;
                NotifyPropertyChanged(nameof(IsSelected));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
