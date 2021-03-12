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
                return await context.Employees.Where(x => x.Name == Name && x.Surname == Surname).Include(x => x.Company.Manager).Include(x => x.Board).ToListAsync();
            }
            else if(Name == null && Surname != null)
            {
                return  await context.Employees.Where(x => x.Surname == Surname).Include(x => x.Company.Manager).Include(x => x.Board).ToListAsync();
            }
            else if (Name != null && Surname == null)
            {
                return await context.Employees.Where(x => x.Name == Name).Include(x => x.Company.Manager).Include(x => x.Board).ToListAsync();
            }
            else
            {
                return await context.Employees.Include(x => x.Company.Manager).Include(x => x.Board).ToListAsync();

            }

            
        }
    }
}
