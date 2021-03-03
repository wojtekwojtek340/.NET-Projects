using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DataAccess.CQRS.Commands.Managers
{
    public class DeleteManagerCommand : CommandBase<int, int>
    {
        public async override Task<int> Execute(TaskManagerContext context)
        {
            var entity = await context.Managers.FindAsync(Parameter);
            context.Managers.Remove(entity);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
