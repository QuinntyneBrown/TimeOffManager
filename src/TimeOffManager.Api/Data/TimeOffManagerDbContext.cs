using TimeOffManager.Api.Models;
using TimeOffManager.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TimeOffManager.Api.Data
{
    public class TimeOffManagerDbContext: DbContext, ITimeOffManagerDbContext
    {
        public DbSet<Employee> Employees { get; private set; }
        public TimeOffManagerDbContext(DbContextOptions options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TimeOffManagerDbContext).Assembly);
        }
        
    }
}
