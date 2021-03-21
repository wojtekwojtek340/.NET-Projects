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
        public int CompanyId { get; set; }
        public override async Task<List<Company>> Execute(TaskManagerContext context)
        {
            var companies = await context.Companies.Where(x => x.Id == CompanyId).Include(x => x.EmployeesList).Include(x => x.Manager).ToListAsync();
            return companies;
        }
    }
}
