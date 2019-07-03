using Microsoft.EntityFrameworkCore;
using ServiceA.Data.EntityConfigurations;
using ServiceA.Data.Entities;

namespace ServiceA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SomeEntityConfiguration
                .Configure(modelBuilder.Entity<SomeEntity>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
