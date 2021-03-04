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
            var board = await context.Boards.Include(x => x.AssignmentList).Include(x => x.Employee).SingleOrDefaultAsync(x => x.Id == Id);
            return board;
        }
    }
}
