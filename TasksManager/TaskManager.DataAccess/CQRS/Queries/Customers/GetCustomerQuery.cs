using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Queries.Customers
{
    public class GetCustomerQuery : QueryBase<Customer>
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }

        public override async Task<Customer> Execute(TaskManagerContext context)
        {
            var customer = await context.Customers.Where(x => x.CompanyId == CompanyId).Include(x => x.AssignmentList).SingleOrDefaultAsync(x => x.Id == Id);
            return customer;
        }
    }
}
