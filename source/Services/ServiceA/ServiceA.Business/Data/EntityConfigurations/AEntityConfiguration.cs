using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceA.Business.Data.Entities;

namespace ServiceA.Business.Data.EntityConfigurations
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
