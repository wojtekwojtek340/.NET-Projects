using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Commands.Companies
{
    public class PutCompanyCommand : CommandBase<Company, Company>
    {
        public async override Task<Company> Execute(TaskManagerContext context)
        {
            context.ChangeTracker.Clear();
            context.Companies.Update(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
