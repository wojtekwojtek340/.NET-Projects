using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Commands.Companies
{
    public class DeleteCompanyCommand : CommandBase<Company, bool>
    {
        public async override Task<bool> Execute(TaskManagerContext context)
        {
            context.Companies.Remove(Parameter);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
