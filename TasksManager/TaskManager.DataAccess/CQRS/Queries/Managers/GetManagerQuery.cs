using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Queries.Managers
{
    public class GetManagerQuery : QueryBase<Manager>
    {
        public int Id { get; set; }
        public override async Task<Manager> Execute(TaskManagerContext context)
        {
            var manager = await context.Managers.FindAsync(Id);
            return manager;
        }
    }
}
