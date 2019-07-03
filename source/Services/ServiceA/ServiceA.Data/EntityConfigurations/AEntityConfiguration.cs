using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceA.Data.Entities;

namespace ServiceA.Data.EntityConfigurations
{
    public class AEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<AEntity> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.AppId).IsRequired();
        }
    }
}
