using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Queries.Companies
{
    public class GetCompanyQuery : QueryBase<Company>
    {
        public int Id { get; set; }
        public override async Task<Company> Execute(TaskManagerContext context)
        {
            var company = await context.Companies.FindAsync(Id);
            return company;
        }
    }
}
