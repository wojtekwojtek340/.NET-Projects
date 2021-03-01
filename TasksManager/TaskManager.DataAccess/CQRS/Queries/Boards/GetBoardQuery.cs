using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Queries.Boards
{
    public class GetBoardQuery : QueryBase<Board>
    {
        public int Id { get; set; }
        public override async Task<Board> Execute(TaskManagerContext context)
        {
            var board = await context.Boards.FindAsync(Id);
            return board;
        }
    }
}
