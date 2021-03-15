using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Commands.Assignments
{
    public class DeleteAssignmentCommand : CommandBase<Assignment, bool>
    {
        public override async Task<bool> Execute(TaskManagerContext context)
        {
            context.Assignments.Remove(Parameter);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
