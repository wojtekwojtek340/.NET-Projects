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
        public override async Task<List<Customer>> Execute(TaskManagerContext context)
        {
            var customers = await context.Customers.Include(x => x.AssignmentList).ToListAsync();
            return customers;
        }
    }
}
