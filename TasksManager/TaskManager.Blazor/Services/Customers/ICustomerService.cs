using BlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services.Customers
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> Add(Customer customer);
        Task<Customer> Update(Customer customer);
        Task<Customer> GetById(int id);
        Task<bool> Delete(int id);
    }
}
