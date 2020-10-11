using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NetCoreFramework.Core.DataAccess.NHibernate;
using NHibernate;

namespace NetCoreFramework.Repository.DataAccess.Concrete.NHibernate.Helpers
{
    public class SqlServerHelper : NHibernateHelper
    {
        protected override ISessionFactory InitializeFactory()
        {

            return Fluently.Configure().Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(/*x => x.FromConnectionStringWithKey("RepositoryContext")*/
                    "Data Source=.;Initial Catalog=net-core-framework-database;Integrated Security=True"))
                .Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }
    }
}