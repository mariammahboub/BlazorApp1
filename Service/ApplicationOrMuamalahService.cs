using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ApplicationOrMuamalahService
    {
        private readonly HttpClient _httpClient;

        public ApplicationOrMuamalahService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddApplicationOrMuamalahAsync(ApplicationOrMuamalah applicationOrMuamalah)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/ApplicationOrMuamalah", applicationOrMuamalah);
                response.EnsureSuccessStatusCode(); // Throws an exception for non-success status codes
            }
            catch (HttpRequestException ex)
            {
                // Log or handle exception as needed
                Console.WriteLine($"HttpRequestException: {ex.Message}");
                throw;
            }
        }



    public async Task<List<ApplicationOrMuamalah>> GetAllApplicationsOrMuamalahsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ApplicationOrMuamalah>>("api/ApplicationOrMuamalah");
        }
    }

}
