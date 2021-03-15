using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Commands.Employees
{
    public class DeleteEmployeeCommand : CommandBase<Employee, bool>
    {
        public async override Task<bool> Execute(TaskManagerContext context)
        {
            context.Employees.Remove(Parameter);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
