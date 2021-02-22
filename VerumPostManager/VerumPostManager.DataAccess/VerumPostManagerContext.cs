using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerumPostManager.Domain.Models;

namespace VerumPostManager.DataAccess
{
    public class VerumPostManagerContext : DbContext
    {
        public VerumPostManagerContext(DbContextOptions<VerumPostManagerContext> opt) : base(opt) { }

        public DbSet<Sent> Sents { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Received> Receiveds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
