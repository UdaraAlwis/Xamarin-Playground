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

        private SelectableItemWrapper<User> _selectedUser;

        public SelectableItemWrapper<User> SelectedUser
        {
            get => _selectedUser;

            set
            {
                _selectedUser = value;

                if (_selectedUser != null)
                {
                    var result = UserList.First(x => x.Data.Name == _selectedUser.Data.Name);
                    result.IsSelected = !result.IsSelected;
                }

                NotifyPropertyChanged(nameof(SelectedUser));
            }
        }

        public MainPageViewModel()
        {
            UserList = new ObservableCollection<SelectableItemWrapper<User>>()
            {
                new SelectableItemWrapper<User>{ Data = new User{ Name = "Eliana Hood"} },
                new SelectableItemWrapper<User>{ Data = new User{ Name = "Miranda Martinez"} },
                new SelectableItemWrapper<User>{ Data = new User{ Name = "Ahmed Marsh"} },
                new SelectableItemWrapper<User>{ Data = new User{ Name = "Karina Barr"} },
                new SelectableItemWrapper<User>{ Data = new User{ Name = "Forrest Grimes"} },
                new SelectableItemWrapper<User>{ Data = new User{ Name = "Yetta Alexander"} },
                new SelectableItemWrapper<User>{ Data = new User{ Name = "Finn Cobb"} },
                new SelectableItemWrapper<User>{ Data = new User{ Name = "Cheyenne Cochran" } },
                new SelectableItemWrapper<User>{ Data = new User{ Name = "Galena Mckinney"} },
                new SelectableItemWrapper<User>{ Data = new User{ Name = "Perry Daniels"} },
                new SelectableItemWrapper<User>{ Data = new User{ Name = "Lucy Ward"} },
                new SelectableItemWrapper<User>{ Data = new User{ Name = "Savannah Murray" } },
                new SelectableItemWrapper<User>{ Data = new User{ Name = "Harrison Calhoun"} },
                new SelectableItemWrapper<User>{ Data = new User{ Name = "Zorita Horn"} },
                new SelectableItemWrapper<User>{ Data = new User{ Name = "Maia Stanley"} },
                new SelectableItemWrapper<User>{ Data = new User{ Name = "Blake Morgan"} },
                new SelectableItemWrapper<User>{ Data = new User{ Name = "Nicole Pena"} },
                new SelectableItemWrapper<User>{ Data = new User{ Name = "Vance Pacheco"} },
            };
        }

        public ObservableCollection<SelectableItemWrapper<User>> UserList { get; set; }
    }

    public class SelectableItemWrapper<T> : INotifyPropertyChanged
    {
        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;

            set
            {
                _isSelected = value;
                NotifyPropertyChanged(nameof(IsSelected));
            }
        }

        public T Data { get; set; }

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

    public class User 
    {
        public string Name { get; set; }
    }
}
