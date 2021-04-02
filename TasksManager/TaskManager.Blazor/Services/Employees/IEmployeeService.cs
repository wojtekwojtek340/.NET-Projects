using System;
using System.Collections.Generic;
using System.Linq;
using BlazorApp.Models;
using System.Threading.Tasks;

namespace BlazorApp.Services.Employees
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<UserData> Add(UserData userData);
        Task<bool> Delete(int id);
        Task<Employee> Update(Employee employee);
        Task<Employee> GetById(int Id);
    }
}
