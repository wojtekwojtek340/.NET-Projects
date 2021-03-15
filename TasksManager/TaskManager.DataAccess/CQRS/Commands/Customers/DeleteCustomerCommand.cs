using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Commands.Customers
{
    public class DeleteCustomerCommand : CommandBase<Customer, bool>
    {
        public async override Task<bool> Execute(TaskManagerContext context)
        {
            context.Customers.Remove(Parameter);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
