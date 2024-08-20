using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MerchantService
    {

            private readonly HttpClient _httpClient;

            public MerchantService(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }

            public async Task AddMerchantAsync(Merchant merchant)
            {
                var response = await _httpClient.PostAsJsonAsync("api/merchants", merchant);
                response.EnsureSuccessStatusCode();
            }

            public async Task<List<Merchant>> GetMerchantsAsync()
            {
                return await _httpClient.GetFromJsonAsync<List<Merchant>>("api/merchants");
            }
        }

    
}
