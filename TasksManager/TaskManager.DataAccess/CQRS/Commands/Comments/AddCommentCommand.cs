using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Commands.Comments
{
    public class AddCommentCommand : CommandBase<Comment, Comment>
    {
        public async override Task<Comment> Execute(TaskManagerContext context)
        {
            await context.Comments.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
