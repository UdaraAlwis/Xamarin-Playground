using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace XFSimpleDiDemo.Services
{
    public class MockDataService : IDataService
    {
        private readonly ILogger<DataService> _logger;

        public MockDataService(ILogger<DataService> logger)
        {
            _logger = logger;
        }

        public void DoStuff()
        {
            _logger.LogCritical("You just called DoStuff from MockDataService object!");
        }
    }
}
