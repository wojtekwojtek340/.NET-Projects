using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Queries.Comments
{
    public class GetCommentsQuery : QueryBase<List<Comment>>
    {
        public int CompanyId { get; set; }
        public override async Task<List<Comment>> Execute(TaskManagerContext context)
        {
            var comments = await context.Comments.Where(x => x.Assignment.Board.Employee.CompanyId == CompanyId).Include(x => x.Assignment).ToListAsync();
            comments.ForEach(x => x.Assignment.CommentsList = null);
            return comments;
        }
    }
}
