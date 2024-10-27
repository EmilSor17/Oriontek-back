using Oriontek.Core.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Oriontek.Core.Interfaces
{
  public interface IRepository<T> where T : BaseEntity
  {
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    void Update(T entity);
    Task DeleteAsync(int id);
    Task<T> GetByIdWithIncludesAsync(int id, params string[] includes);
    Task<IEnumerable<T>> GetAllWithIncludesAsync(params string[] includes);
    Task<T?> FindAsync(Expression<Func<T, bool>> predicate);
  }
}
