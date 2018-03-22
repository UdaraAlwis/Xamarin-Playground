using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MultiSelectListViewControl
{
    public class MainPageViewModel
    {
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

    public class User
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}
