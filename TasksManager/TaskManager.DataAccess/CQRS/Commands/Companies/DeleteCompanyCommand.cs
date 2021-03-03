using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DataAccess.CQRS.Commands.Companies
{
    public class DeleteCompanyCommand : CommandBase<int, int>
    {
        public async override Task<int> Execute(TaskManagerContext context)
        {
            var entity = await context.Companies.FindAsync(Parameter);
            context.Companies.Remove(entity);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
