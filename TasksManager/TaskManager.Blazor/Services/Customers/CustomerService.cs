using BlazorApp.Models;
using BlazorApp.Services.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly IHttpService _httpService;

        public CustomerService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<Customer> Add(Customer customer)
        {
            return await _httpService.Post<Customer>("/Customers", customer);
        }

        public async Task<bool> Delete(int id)
        {
            await _httpService.Delete($"/Customers/{id}");
            return true;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _httpService.Get<IEnumerable<Customer>>("/Customers");
        }
        public async Task<Customer> GetById(int id)
        {
            return await _httpService.Get<Customer>($"/Customers/{id}");
        }
        public async Task<Customer> Update(Customer customer)
        {
            var result = await _httpService.Put<Customer>("/Customers", customer);
            return result;
        }
    }
}
