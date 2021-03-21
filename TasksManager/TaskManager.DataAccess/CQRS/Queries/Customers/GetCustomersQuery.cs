using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Queries.Customers
{
    public class GetCustomersQuery : QueryBase<List<Customer>>
    {
        public int CompanyId { get; set; }
        public override async Task<List<Customer>> Execute(TaskManagerContext context)
        {
            var customers = await context.Customers.Where(x => x.AssignmentList.FirstOrDefault().Board.Employee.CompanyId == CompanyId).Include(x => x.AssignmentList).ToListAsync();
            return customers;
        }
    }
}
