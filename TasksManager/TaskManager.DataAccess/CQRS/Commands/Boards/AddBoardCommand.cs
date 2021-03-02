using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Commands.Boards
{
    public class AddBoardCommand : CommandBase<Board, Board>
    {
        public async override Task<Board> Execute(TaskManagerContext context)
        {
            await context.Boards.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
