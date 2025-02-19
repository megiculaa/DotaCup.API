using System.Linq.Expressions;

namespace DotaCup.API.Data.Interfaces;

public interface IGenericRepository<TEntity>
{
    Task<IEnumerable<TEntity>> Get(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           Expression<Func<TEntity, object>>? includeProperties = null,
           int pageNumber = default,
           int pageSize = default);

    Task<TEntity> GetByID(
        Guid id,
        Expression<Func<TEntity, object>>? includeProperties = null);
    Task<TEntity> Insert(TEntity entity);
    Task<bool> Exists(Guid id);
    Task InsertRange(List<TEntity> entity);
    Task Delete(object id);
    Task Delete(TEntity entityToDelete);
    Task Update(TEntity entityToUpdate);
    Task UpdateRange(List<TEntity> entityToUpdate);
}
