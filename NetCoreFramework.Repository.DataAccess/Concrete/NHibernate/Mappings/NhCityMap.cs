using FluentNHibernate.Mapping;
using NetCoreFramework.Repository.Entities.Concrete;

namespace NetCoreFramework.Repository.DataAccess.Concrete.NHibernate.Mappings
{
    public class NhCityMap : ClassMap<City>
    {
        public NhCityMap()
        {
            Table(@"Cities");
            LazyLoad();

            Id(x => x.Id).Column("Id");

            Map(x => x.CountryId).Column("CountryId");
            Map(x => x.Name).Column("Name");
        }
    }
}