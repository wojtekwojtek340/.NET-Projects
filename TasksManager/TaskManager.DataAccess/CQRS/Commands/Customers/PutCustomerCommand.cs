using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Commands.Customers
{
    public class PutCustomerCommand : CommandBase<Customer, Customer>
    {
        public async override Task<Customer> Execute(TaskManagerContext context)
        {
            context.Customers.Update(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
