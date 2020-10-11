using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreFramework.Repository.Entities.Concrete;

namespace NetCoreFramework.Repository.DataAccess.Concrete.EFCore.Mappings
{
    public class EfCountryMap : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable(@"Countries", @"dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.CodePhone).HasColumnName("Code_Phone");
            builder.Property(x => x.CodeAlpha2).HasColumnName("Code_Alpha2");
        }
    }
}