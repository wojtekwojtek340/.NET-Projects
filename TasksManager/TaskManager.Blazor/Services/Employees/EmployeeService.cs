using BlazorApp.Models;
using BlazorApp.Services.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IHttpService _httpService;

        public EmployeeService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _httpService.Get<IEnumerable<Employee>>("/Employees");
        }
        public async Task<UserData> Add(UserData userData)
        {
            var result = await _httpService.Post<UserData>("/Employees", userData);
            return result;
        }
        public async Task<bool> Delete(int id)
        {
            await _httpService.Delete($"/Employees/{id}");
            return true;            
        }

        public async Task<Employee> Update(Employee employee)
        {
            var result = await _httpService.Put<Employee>("/Employees", employee);
            return result;
        }

        public async Task<Employee> GetById(int id)
        {
            return await _httpService.Get<Employee>($"/Employees/{id}");
        }
    }
}
