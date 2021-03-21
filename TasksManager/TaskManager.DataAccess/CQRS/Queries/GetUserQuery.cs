using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Queries
{
    public class GetUserQuery<T> : QueryBase<T>
    {
        public string Login { get; set; }
        public override async Task<T> Execute(TaskManagerContext context)
        {
            if(typeof(T) == typeof(Manager))
            {
                Manager manager = await context.Managers.Where(x => x.Login == Login).Include(x => x.Company).FirstOrDefaultAsync();
                return (T) Convert.ChangeType(manager, typeof(T));
            }
            else if(typeof(T) == typeof(Employee))
            {
                Employee employee = await context.Employees.Where(x => x.Login == Login).Include(x => x.Company).FirstOrDefaultAsync();
                return (T)Convert.ChangeType(employee, typeof(T));
            }
            return default(T);
        }
    }
}
