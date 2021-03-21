using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Queries.Comments
{
    public class GetCommentQuery : QueryBase<Comment>
    {
        public int CompanyId { get; set; }
        public int Id { get; set; }
        public override async Task<Comment> Execute(TaskManagerContext context)
        {
            var comment = await context.Comments.Where(x=> x.Assignment.Board.Employee.CompanyId == CompanyId).Include(x => x.Assignment).SingleOrDefaultAsync(x => x.Id == Id);
            return comment;
        }
    }
}
