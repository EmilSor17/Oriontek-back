using Microsoft.EntityFrameworkCore;
using Oriontek.Core.Entities;
using Oriontek.Core.Interfaces;
using Oriontek.Infraestructure.Data;
using System.Linq.Expressions;

namespace Oriontek.Infraestructure.Repositories
{
  public class BaseRepository<T> : IRepository<T> where T : BaseEntity
  {
    protected readonly DatContext _context;

    public BaseRepository(DatContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
      return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
      return await _context.Set<T>().FindAsync(id);
    }

    public virtual async Task AddAsync(T entity)
    {
      await _context.Set<T>().AddAsync(entity);
    }

    public virtual void Update(T entity)
    {
      _context.Set<T>().Update(entity);
    }

    public async Task DeleteAsync(int id)
    {
      var entity = await _context.Set<T>().FindAsync(id);
      if (entity != null)
      {
        _context.Set<T>().Remove(entity);
      }
    }

    public async Task<T> GetByIdWithIncludesAsync(int id, params string[] includes)
    {
      IQueryable<T> query = _context.Set<T>();

      foreach (var include in includes)
      {
        query = query.Include(include);
      }

      return await query.FirstOrDefaultAsync(e => e.Id == id);
    }

    public virtual async Task<IEnumerable<T>> GetAllWithIncludesAsync(params string[] includes)
    {
      IQueryable<T> query = _context.Set<T>();

      foreach (var include in includes)
      {
        query = query.Include(include);
      }

      return await query.ToListAsync();
    }

    public async Task<T?> FindAsync(Expression<Func<T, bool>> predicate)
    {
      return await _context.Set<T>().FirstOrDefaultAsync(predicate);
    }
  }
}
