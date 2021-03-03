using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DataAccess.CQRS.Commands.Boards
{
    public class DeleteBoardCommand : CommandBase<int, int>
    {
        public async override Task<int> Execute(TaskManagerContext context)
        {
            var entity = await context.Boards.FindAsync(Parameter);
            context.Boards.Remove(entity);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
