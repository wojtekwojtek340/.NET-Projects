using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.CQRS.Commands;

namespace TaskManager.DataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly TaskManagerContext context;

        public CommandExecutor(TaskManagerContext context)
        {
            this.context = context;
        }
        public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
        {
            return command.Execute(context);
        }
    }
}
