using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Queries.Assignments
{
    public class GetAssignmentQuery : QueryBase<Assignment>
    {
        public int Id { get; set; }
        public override async Task<Assignment> Execute(TaskManagerContext context)
        {
            var assignment = await context.Assignments
                .Include(x => x.Customer)
                .Include(x => x.Board.Employee)
                .Include(x => x.CommentsList)
                .SingleOrDefaultAsync(x => x.Id == Id);
            return assignment;
        }
    }
}
