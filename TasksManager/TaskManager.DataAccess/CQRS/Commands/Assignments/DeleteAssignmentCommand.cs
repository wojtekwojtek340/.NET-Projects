using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Commands.Assignments
{
    public class DeleteAssignmentCommand : CommandBase<int, int>
    {
        public override async Task<int> Execute(TaskManagerContext context)
        {
            var entity = await context.Assignments.FindAsync(Parameter);
            context.Assignments.Remove(entity);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
