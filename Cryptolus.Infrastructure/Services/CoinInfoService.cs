using Cryptolus.Application.Common.Interfaces;
using Cryptolus.Domain.Entities.CoinInfo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Cryptolus.Infrastructure.Services
{
    public class CoinInfoService : ICoinInfoService
    {
        private const string BaseUri = "https://api.coingecko.com/api/v3/";
        private readonly HttpClient _httpClient;

        public CoinInfoService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUri)
            };
            _httpClient.DefaultRequestHeaders.Add("User-Agent","Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3");
        }

        public async Task<List<CoinData>> GetCoinData(string currency = "usd")
        {
            var response = await _httpClient.GetAsync($"coins/markets?vs_currency={currency}&precision=3");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<CoinData>>(content);
        }


        public async Task<List<CoinData>> GetSeveralCoins(string currency = "usd", int count = 10)
        {
            var response = await _httpClient.GetAsync($"coins/markets?vs_currency={currency}&per_page={count}&precision=3");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<CoinData>>(content);
        }

    }
}
