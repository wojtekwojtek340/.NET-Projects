using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DataAccess.CQRS.Commands.Employees
{
    public class DeleteEmployeeCommand : CommandBase<int, int>
    {
        public async override Task<int> Execute(TaskManagerContext context)
        {
            var entity = await context.Employees.FindAsync(Parameter);
            context.Employees.Remove(entity);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
