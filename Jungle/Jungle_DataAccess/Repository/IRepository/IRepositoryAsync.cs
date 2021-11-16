using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jungle_DataAccess.Repository.IRepository
{
  // Ce doit être une interface générique <T> (T pour s'adapter au type d'objet classe ) publique
  public interface IRepositoryAsync<T> where T : class
  {
    // Les méthodes devant être implantées dans les repositories

    Task<T> GetAsync(int id);

    Task<IEnumerable<T>> GetAllAsync(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeProperties = null
        );

    Task<T> FirstOrDefaultAsync(
        Expression<Func<T, bool>> filter = null,
        string includeProperties = null
        );

    Task AddAsync(T entity);
    Task RemoveAsync(int id);
    Task RemoveAsync(T entity);
    Task RemoveRangeAsync(IEnumerable<T> entity);

  }

}
