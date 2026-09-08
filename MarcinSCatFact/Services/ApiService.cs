using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcinSCatFact.Services
{
    internal class ApiService : IApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string _baseApiAddress;

        public ApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
    }
}
