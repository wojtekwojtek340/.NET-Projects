using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Queries.Boards
{
    public class GetBoardsQuery : QueryBase<List<Board>>
    {
        public override async Task<List<Board>> Execute(TaskManagerContext context)
        {
            var boards = await context.Boards.ToListAsync();
            return boards;
        }
    }
}
