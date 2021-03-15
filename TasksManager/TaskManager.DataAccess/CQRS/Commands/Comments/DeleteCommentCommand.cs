using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Commands.Comments
{
    public class DeleteCommentCommand : CommandBase<Comment, bool>
    {
        public async override Task<bool> Execute(TaskManagerContext context)
        {
            context.Comments.Remove(Parameter);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
