using System;
using System.Collections.Generic;
using System.Text;
using XFSimpleDiDemo.Services;

namespace XFSimpleDiDemo.ViewModel
{
    public class MainPageViewModel
    {
        private readonly IDataService _dataService;

        public MainPageViewModel(IDataService dataService)
        {
            _dataService = dataService;
        }

        public void DoIt()
        {
            _dataService.DoStuff();
        }
    }
}
