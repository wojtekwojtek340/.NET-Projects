using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Commands.Companies
{
    public class AddCompanyCommand : CommandBase<Company, Company>
    {
        public async override Task<Company> Execute(TaskManagerContext context)
        {
            await context.Companies.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
