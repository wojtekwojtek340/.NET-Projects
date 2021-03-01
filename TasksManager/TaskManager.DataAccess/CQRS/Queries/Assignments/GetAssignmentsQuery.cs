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
            var assignments = await context.Assignments.ToListAsync();
            return assignments;
        }
    }
}
