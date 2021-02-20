using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DataAccess
{
    class TaskManagerContextFactory : IDesignTimeDbContextFactory<TaskManagerContext>
    {
        public TaskManagerContext CreateDbContext(string[] args)
        {
            var optionsBuildier = new DbContextOptionsBuilder<TaskManagerContext>();
            optionsBuildier.UseSqlServer("Data Source = DESKTOP - TH6F0L5; Initial Catalog = TaskManagerDb; Integrated Security = True");
            return new TaskManagerContext(optionsBuildier.Options);
        }
    }
}
