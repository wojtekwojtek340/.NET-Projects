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
        public int CompanyId { get; set; }
        public int Id { get; set; }
        public override async Task<Manager> Execute(TaskManagerContext context)
        {
            var manager = await context.Managers
                .Where(x => x.Company.Id == CompanyId)
                .Include(x => x.Company.EmployeesList)
                .SingleOrDefaultAsync(x => x.Id == Id);
                return manager;
        }
    }
}
