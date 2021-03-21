using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Queries.Managers
{
    public class GetManagersQuery : QueryBase<List<Manager>>
    {
        public int CompanyId { get; set; }
        public override async Task<List<Manager>> Execute(TaskManagerContext context)
        {
            var managers = await context.Managers
                .Where(x => x.Company.Id == CompanyId)
                .Include(x => x.Company.EmployeesList).ToListAsync();

            return managers;
        }
    }
}
