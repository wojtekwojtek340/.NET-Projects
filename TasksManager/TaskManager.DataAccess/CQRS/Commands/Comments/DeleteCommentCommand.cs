using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DataAccess.CQRS.Commands.Comments
{
    public class DeleteCommentCommand : CommandBase<int, int>
    {
        public async override Task<int> Execute(TaskManagerContext context)
        {
            var entity = await context.Comments.FindAsync(Parameter);
            context.Comments.Remove(entity);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
