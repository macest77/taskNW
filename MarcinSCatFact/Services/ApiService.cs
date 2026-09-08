using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MarcinSCatFact.Model;

namespace MarcinSCatFact.Services
{
    internal class ApiService : IApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string _apiAddress = "https://catfact.ninja/fact";

        public ApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<CatFact> GetCatFactAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var json = await client.GetStringAsync(_apiAddress);

            var catFact = JsonSerializer.Deserialize<CatFact>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (catFact is null)
            {
                throw new InvalidOperationException("Nie udało się odczytać odpowiedzi z catfact.ninja/fact.");
            }

            return catFact;
        }
    }
}
