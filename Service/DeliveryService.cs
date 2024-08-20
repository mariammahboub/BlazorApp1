using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DeliveryService
    {
        private readonly HttpClient _httpClient;

        public DeliveryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddDeliveryAsync(Delivery delivery)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/deliveries", delivery);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}"); // Debug output
                throw; // Re-throw the exception if you want to handle it further up the stack
            }
        }

        public async Task<List<Delivery>> GetDeliveriesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Delivery>>("api/deliveries");
        }
    }

}


