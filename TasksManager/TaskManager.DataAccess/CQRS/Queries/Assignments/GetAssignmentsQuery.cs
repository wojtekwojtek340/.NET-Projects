using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Queries.Assignments
{
    public class GetAssignmentsQuery : QueryBase<List<Assignment>>
    {
        public override async Task<List<Assignment>> Execute(TaskManagerContext context)
        {
            var assignments = await context.Assignments
                .Include(x => x.Customer)
                .Include(x => x.Board.Employee)
                .Include(x => x.CommentsList)
                .ToListAsync();
            assignments.ForEach(x => x.Customer.AssignmentList = null);
            assignments.ForEach(x => x.Board.AssignmentList = null);
            return assignments;
        }
    }
}
