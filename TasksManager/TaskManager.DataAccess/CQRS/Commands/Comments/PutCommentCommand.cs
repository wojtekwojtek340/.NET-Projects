using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Commands.Comments
{
    public class PutCommentCommand : CommandBase<Comment, Comment>
    {
        public async override Task<Comment> Execute(TaskManagerContext context)
        {
            context.ChangeTracker.Clear();
            context.Comments.Update(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
