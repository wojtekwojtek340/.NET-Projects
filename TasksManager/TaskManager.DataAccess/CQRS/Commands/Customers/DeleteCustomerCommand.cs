using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DataAccess.CQRS.Commands.Customers
{
    public class DeleteCustomerCommand : CommandBase<int, int>
    {
        public async override Task<int> Execute(TaskManagerContext context)
        {
            var entity = await context.Customers.FindAsync(Parameter);
            context.Customers.Remove(entity);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
