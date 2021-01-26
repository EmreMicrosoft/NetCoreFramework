using FluentNHibernate.Mapping;
using Repository.Entities.Concrete;

namespace Repository.DataAccess.Concrete.NHibernate.Mappings
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