using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Commands.Managers
{
    public class PutManagerCommand : CommandBase<Manager, Manager>
    {
        public async override Task<Manager> Execute(TaskManagerContext context)
        {
            context.Managers.Update(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
