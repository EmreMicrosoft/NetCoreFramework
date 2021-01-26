using FluentNHibernate.Mapping;
using Repository.Entities.Concrete;

namespace Repository.DataAccess.Concrete.NHibernate.Mappings
{
    public class NhCountryMap : ClassMap<Country>
    {
        public NhCountryMap()
        {
            Table(@"Countries");
            LazyLoad();

            Id(x => x.Id).Column("Id");

            Map(x => x.Name).Column("Name");
            Map(x => x.CodePhone).Column("Code_Phone");
            Map(x => x.CodeAlpha2).Column("Code_Alpha2");
        }
    }
}