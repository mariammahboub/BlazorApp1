using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class StoreService
    {
        private readonly HttpClient _httpClient;

        public StoreService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddStoreAsync(Store store)
        {
            var response = await _httpClient.PostAsJsonAsync("api/stores", store);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error {response.StatusCode}: {errorContent}");
            }
        }

        public async Task<List<Store>> GetStoresAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Store>>("api/stores");
        }

        public async Task<Store> GetStoreByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Store>($"api/stores/{id}");
        }
        public async Task<List<StoreCustomerLocation>> GetStoreCustomerLocationsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<StoreCustomerLocation>>("api/storecustomerlocations");
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it, show a user-friendly message)
                Console.WriteLine($"An error occurred while retrieving store customer locations: {ex.Message}");
                return new List<StoreCustomerLocation>();
            }
        }
    }
}
