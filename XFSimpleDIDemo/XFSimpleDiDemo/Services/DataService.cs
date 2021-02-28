using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Logging;

namespace XFSimpleDiDemo.Services
{
    public class DataService : IDataService
    {
        private readonly ILogger<DataService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public DataService(ILogger<DataService> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient();
        }

        public void DoStuff()
        {
            _logger.LogCritical("You just called DoStuff from DataService object!");
        }
    }
}
