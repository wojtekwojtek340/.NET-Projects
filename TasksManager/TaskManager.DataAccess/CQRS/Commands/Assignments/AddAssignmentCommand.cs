using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Commands.Assignments
{
    public class AddAssignmentCommand : CommandBase<Assignment, Assignment>
    {
        public override async Task<Assignment> Execute(TaskManagerContext context)
        {
            await context.Assignments.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
