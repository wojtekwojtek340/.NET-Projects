using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Queries.Employees
{
    public class GetEmployeesQuery : QueryBase<List<Employee>>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public override async Task<List<Employee>> Execute(TaskManagerContext context)
        {
            if (Name != null && Surname != null)
            {
                var employees =  await context.Employees.Where(x => x.Name == Name && x.Surname == Surname).Include(x => x.Company).Include(x => x.Board).ToListAsync();
                employees.ForEach(x => x.Company.EmployeesList = null);
                return employees;
            }
            else if(Name == null && Surname != null)
            {
                var employees = await context.Employees.Where(x => x.Surname == Surname).Include(x => x.Company).Include(x => x.Board).ToListAsync();
                employees.ForEach(x => x.Company.EmployeesList = null);
                return employees;
            }
            else if (Name != null && Surname == null)
            {
                var employees = await context.Employees.Where(x => x.Name == Name).Include(x => x.Company).Include(x => x.Board).ToListAsync();
                employees.ForEach(x => x.Company.EmployeesList = null);
                return employees;
            }
            else
            {
                var employees = await context.Employees.Include(x => x.Company).Include(x => x.Board).ToListAsync();
                employees.ForEach(x => x.Company.EmployeesList = null);
                return employees;

            }

            
        }
    }
}
