using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Queries.Employees
{
    public class GetEmployeeQuery : QueryBase<Employee>
    {
        public int CompanyId { get; set; }
        public int Id { get; set; }
        public override async Task<Employee> Execute(TaskManagerContext context)
        {
            var employee = await context.Employees.Where(x => x.CompanyId == CompanyId).Include(x => x.Company).Include(x => x.Board).SingleOrDefaultAsync(x => x.Id == Id);
            return employee;
        }
    }
}
