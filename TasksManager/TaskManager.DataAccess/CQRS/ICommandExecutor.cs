using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.CQRS.Commands;

namespace TaskManager.DataAccess.CQRS
{
    public interface ICommandExecutor
    {
        Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command);
    }
}
