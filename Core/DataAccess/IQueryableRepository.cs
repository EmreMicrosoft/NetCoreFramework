using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.DataAccess
{
    public interface IQueryableRepository<T> where T : class, IEntity, new()
    {
        IQueryable<T> Table { get; }
        //Task<IQueryable<T>> TableAsync { get; }
    }
}