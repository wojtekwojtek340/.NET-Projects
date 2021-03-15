using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Commands.Boards
{
    public class DeleteBoardCommand : CommandBase<Board, bool>
    {
        public async override Task<bool> Execute(TaskManagerContext context)
        {
            context.Boards.Remove(Parameter);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
