using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<Employee> EmployeesList { get; set; }
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
    }
}
