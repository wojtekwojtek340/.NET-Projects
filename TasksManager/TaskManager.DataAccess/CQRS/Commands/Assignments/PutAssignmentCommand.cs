using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Commands.Assignments
{
    public class PutAssignmentCommand : CommandBase<Assignment, Assignment>
    {
        public async override Task<Assignment> Execute(TaskManagerContext context)
        {
            context.Assignments.Update(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
