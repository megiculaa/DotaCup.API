using DotaCup.API.Data.Interfaces;
using DotaCup.API.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace DotaCup.API.Data.Repository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    private ApplicationContext _context;
    private DbSet<TEntity> dbSet;

    public GenericRepository(ApplicationContext context)
    {
        this._context = context;
        dbSet = context.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> Get(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Expression<Func<TEntity, object>>? includeProperties = null,
        int pageNumber = default,
        int pageSize = default)
    {
        IQueryable<TEntity> query = dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (includeProperties != null)
        {
            query = query.Include(includeProperties);
        }

        if (orderBy != null)
        {
            return await orderBy(query).ToListAsync();
        }
        else
        {
            return await query.ToListAsync();
        }
    }


    public virtual async Task<TEntity> GetByID(
        Guid id,
        Expression<Func<TEntity, object>>? includeProperties = null)
    {
        IQueryable<TEntity> query = dbSet;

        if (includeProperties != null)
        {
            query = query.Include(includeProperties);
        }

        return await query.Where(e => e.Id == id).FirstOrDefaultAsync();
    }

    public virtual async Task Delete(object id)
    {
        TEntity entityToDelete = await dbSet.FindAsync(id);
        await Delete(entityToDelete);
    }

    public virtual async Task Delete(TEntity entityToDelete)
    {
        if (_context.Entry(entityToDelete).State == EntityState.Detached)
        {
            dbSet.Attach(entityToDelete);
        }
        dbSet.Remove(entityToDelete);
    }

    public virtual async Task Update(TEntity entityToUpdate)
    {
        dbSet.Attach(entityToUpdate);
        _context.Entry(entityToUpdate).State = EntityState.Modified;
    }

    public virtual async Task<TEntity> Insert(TEntity entity)
    {
        await dbSet.AddAsync(entity);
        return entity;
    }

    public virtual async Task<bool> Exists(Guid id)
    {
        var entity = await GetByID(id);
        return entity != null;
    }

    public virtual async Task InsertRange(List<TEntity> entity)
    {
        await dbSet.AddRangeAsync(entity);
    }

    public virtual async Task UpdateRange(List<TEntity> entityToUpdate)
    {
        dbSet.AttachRange(entityToUpdate);
        _context.Entry(entityToUpdate).State = EntityState.Modified;
    }
}
