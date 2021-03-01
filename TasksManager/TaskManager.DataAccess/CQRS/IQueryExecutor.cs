using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.CQRS.Queries;

namespace TaskManager.DataAccess.CQRS
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TResult>(QueryBase<TResult> query);
    }
}
