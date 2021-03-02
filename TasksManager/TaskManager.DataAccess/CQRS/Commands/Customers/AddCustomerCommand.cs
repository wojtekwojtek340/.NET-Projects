using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Commands.Customers
{
    public class AddCustomerCommand : CommandBase<Customer, Customer>
    {
        public async override Task<Customer> Execute(TaskManagerContext context)
        {
            await context.Customers.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
