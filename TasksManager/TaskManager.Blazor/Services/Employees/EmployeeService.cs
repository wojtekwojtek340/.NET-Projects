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
        private IHttpService _httpService;

        public EmployeeService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _httpService.Get<IEnumerable<Employee>>("/Employees");
        }
    }
}
