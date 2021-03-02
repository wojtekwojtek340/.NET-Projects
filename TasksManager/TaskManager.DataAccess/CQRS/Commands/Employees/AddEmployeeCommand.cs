using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Commands.Employees
{
    public class AddEmployeeCommand : CommandBase<Employee, Employee>
    {
        public async override Task<Employee> Execute(TaskManagerContext context)
        {
            await context.Employees.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
