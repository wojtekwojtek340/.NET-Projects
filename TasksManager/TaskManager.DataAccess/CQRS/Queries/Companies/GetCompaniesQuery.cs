using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Queries.Companies
{
    public class GetCompaniesQuery : QueryBase<List<Company>>
    {
        public override async Task<List<Company>> Execute(TaskManagerContext context)
        {
            var companies = await context.Companies.Include(x => x.EmployeesList).Include(x => x.Manager).ToListAsync();
            return companies;
        }
    }
}
