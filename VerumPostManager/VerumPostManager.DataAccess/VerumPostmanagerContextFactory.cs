using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerumPostManager.DataAccess
{
    public class VerumPostmanagerContextFactory : IDesignTimeDbContextFactory<VerumPostManagerContext>
    {
        public VerumPostManagerContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<VerumPostManagerContext>();

            options.UseSqlServer("Server=DESKTOP-TH6F0L5;Initial Catalog=VerumPostManagerDb;User ID=Verum;password=Verum;Integrated Security=True;Trusted_Connection=True;");

            return new VerumPostManagerContext(options.Options);
        }
    }
}
