using Core.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Service
{
    public class StoreCustomerLocationService
    {
        private readonly HttpClient _httpClient;

        public StoreCustomerLocationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddStoreCustomerLocationAsync(StoreCustomerLocation storeCustomerLocation)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/StoreCustomerLocations", storeCustomerLocation);
                response.EnsureSuccessStatusCode(); // Throws exception if the status code is not success
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}"); // Debug output
                throw; // Re-throw the exception if you want to handle it further up the stack
            }
        }

        public async Task<List<StoreCustomerLocation>> GetStoreCustomerLocationsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<StoreCustomerLocation>>("api/StoreCustomerLocations");
        }
    }
}
