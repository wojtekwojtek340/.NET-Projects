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
        public override async Task<List<Employee>> Execute(TaskManagerContext context)
        {
            var employees = await context.Employees.ToListAsync();
            return employees;
        }
    }
}
