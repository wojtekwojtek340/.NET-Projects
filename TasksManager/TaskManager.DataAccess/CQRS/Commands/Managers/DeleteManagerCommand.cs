using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Commands.Managers
{
    public class DeleteManagerCommand : CommandBase<Manager, bool>
    {
        public async override Task<bool> Execute(TaskManagerContext context)
        {
            context.Managers.Remove(Parameter);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
