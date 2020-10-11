using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NetCoreFramework.Repository.Entities.Concrete;

namespace NetCoreFramework.Repository.Entities.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> entity)
        {
            entity.Property(e => e.CodeAlpha2)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.Name).IsUnicode(false);
        }
    }
}
