using Microsoft.EntityFrameworkCore;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess
{
    class TaskManagerContext : DbContext
    {
        public TaskManagerContext(DbContextOptions<TaskManagerContext> opt) : base(opt)
        {

        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manager>()
                .HasOne(a => a.Company)
                .WithOne(b => b.Manager)
                .HasForeignKey<Manager>(b => b.ManagerId);

            modelBuilder.Entity<Employee>()
            .HasOne(a => a.Board)
            .WithOne(b => b.Employee)
            .HasForeignKey<Employee>(b => b.EmployeeId);

            modelBuilder.Entity<Assignment>()
            .HasOne(a => a.Board)
            .WithMany(b => b.ToBePlanned);
        }

    }


}
