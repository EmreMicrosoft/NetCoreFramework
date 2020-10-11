using Microsoft.EntityFrameworkCore;
using NetCoreFramework.Repository.Entities.ComplexTypes;
using NetCoreFramework.Repository.Entities.Concrete;
using NetCoreFramework.Repository.Entities.Configurations;

namespace NetCoreFramework.Repository.DataAccess.Concrete.EFCore
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext()
        {
        }

        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<CitiesOfCountries> CitiesOfCountries { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Data Source=.;Initial Catalog=net-core-framework-database;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CitiesOfCountriesConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            // TODO
        }
    }
}