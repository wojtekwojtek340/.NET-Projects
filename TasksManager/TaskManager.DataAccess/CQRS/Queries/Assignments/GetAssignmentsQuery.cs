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
        public int? CustomerId { get; set; }
        public int CompanyId { get; set; }

        public override async Task<List<Assignment>> Execute(TaskManagerContext context)
        {
            if(CustomerId != null)
            {
                var assignments2 = await context.Assignments                    
                    .Include(x => x.Customer)
                    .Include(x => x.Board.Employee)
                    .Include(x => x.CommentsList)
                    .Where(x => x.CustomerId == CustomerId && x.Board.Employee.CompanyId == CompanyId)
                    .ToListAsync();
                assignments2.ForEach(x => x.Customer.AssignmentList = null);
                assignments2.ForEach(x => x.Board.AssignmentList = null);
                assignments2.ForEach(x => x.Board.Employee.Company.EmployeesList = null);
                return assignments2;
            }

            var assignments = await context.Assignments
                .Include(x => x.Customer)
                .Include(x => x.Board.Employee)
                .Include(x => x.CommentsList)
                .Where(x => x.Board.Employee.CompanyId == CompanyId)
                .ToListAsync();
            assignments.ForEach(x => x.Customer.AssignmentList = null);
            assignments.ForEach(x => x.Board.AssignmentList = null);
            assignments.ForEach(x => x.Board.Employee.Company.EmployeesList = null);
            return assignments;
        }
    }
}
