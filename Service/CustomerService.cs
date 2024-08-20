using Core.Models;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddCustomerAsync(Customer customer)
        {
            await _httpClient.PostAsJsonAsync("api/customers", customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/customers/{id}");
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Customer>($"api/customers/{id}");
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Customer>>("api/customers");
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            await _httpClient.PutAsJsonAsync($"api/customers/{customer.CustomerId}", customer);
        }


    }
}