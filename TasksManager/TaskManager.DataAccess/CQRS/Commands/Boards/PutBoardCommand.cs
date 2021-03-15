using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Commands.Boards
{
    public class PutBoardCommand : CommandBase<Board, Board>
    {
        public async override Task<Board> Execute(TaskManagerContext context)
        {
            context.ChangeTracker.Clear();
            context.Boards.Update(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
