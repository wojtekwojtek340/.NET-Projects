using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Commands.Employees
{
    public class PutEmployeeCommand : CommandBase<Employee, Employee>
    {
        public async override Task<Employee> Execute(TaskManagerContext context)
        {
            context.Employees.Update(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
