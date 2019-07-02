using Microsoft.EntityFrameworkCore;
using ServiceA.Business.Data.Entities;
using ServiceA.Business.Data.EntityConfigurations;

namespace ServiceA.Business.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AEntityConfiguration
                .Configure(modelBuilder.Entity<AEntity>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
