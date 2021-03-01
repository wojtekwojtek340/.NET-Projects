using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.CQRS.Queries;

namespace TaskManager.DataAccess.CQRS
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly TaskManagerContext context;

        public QueryExecutor(TaskManagerContext context)
        {
            this.context = context;
        }
        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(context);
        }
    }
}
