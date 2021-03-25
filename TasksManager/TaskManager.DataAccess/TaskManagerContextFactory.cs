using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess
{
    public class TaskManagerContextFactory : IDesignTimeDbContextFactory<TaskManagerContext>
    {
        public TaskManagerContext CreateDbContext(string[] args)
        {
            var optionsBuildier = new DbContextOptionsBuilder<TaskManagerContext>();
            optionsBuildier.UseSqlServer("Server=tcp:taskmanagerserv.database.windows.net,1433;Initial Catalog=TaskManagerDb;Persist Security Info=False;User ID=wojtekwojtowicz;Password=EAvJKBkpmg8t3U7f;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            //optionsBuildier.UseSqlServer("Server=DESKTOP-TH6F0L5;Initial Catalog=TaskManagerDb;User ID=TaskManager;password=adminadmin;Integrated Security=True;Trusted_Connection=True;");
            return new TaskManagerContext(optionsBuildier.Options);
        }
    }       
}
