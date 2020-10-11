using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NetCoreFramework.Repository.Entities.ComplexTypes;

namespace NetCoreFramework.Repository.Entities.Configurations
{
    public class CitiesOfCountriesConfiguration : IEntityTypeConfiguration<CitiesOfCountries>
    {
        public void Configure(EntityTypeBuilder<CitiesOfCountries> entity)
        {
            entity.HasNoKey();

            entity.ToView("Cities_of_Countries");

            entity.Property(e => e.CodeAlpha2)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.Expr2).IsUnicode(false);

            entity.Property(e => e.Name).IsUnicode(false);
        }
    }
}