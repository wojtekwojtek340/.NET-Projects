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

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _httpService.Get<IEnumerable<Customer>>("/Customers");
        }
    }
}
