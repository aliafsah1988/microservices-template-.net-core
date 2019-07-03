using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceA.Data.Entities;

namespace ServiceA.Data.EntityConfigurations
{
    public class SomeEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<SomeEntity> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.AppId).IsRequired();
        }
    }
}
