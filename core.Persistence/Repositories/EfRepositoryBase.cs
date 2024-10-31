using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories;

public class EfRepositoryBase<T, TContext> : IRepositoryAsync<T>
    where T : Entity
    where TContext : DbContext
{
    protected TContext _dbContext { get; }

    public EfRepositoryBase(TContext context)
    {
        _dbContext = context;
    }
    public virtual async Task<T?> GetAsync(int id)
    {
        var result = await _dbContext.Set<T>().FindAsync(id);

        return result;
    }

    public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> predicate,
                                                 Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                                 Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)

    {
        IQueryable<T> query = _dbContext.Set<T>();

        if (include != null) query = include(query);

        if (orderBy != null) query = orderBy(query);

        query = query.Where(predicate);

        return await query.FirstOrDefaultAsync();
    }

    public virtual async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null,
                                                           Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                                           Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
    {
        IQueryable<T> query = _dbContext.Set<T>();

        if (include != null) query = include(query);

        if (orderBy != null) query = orderBy(query);

        if (predicate != null) query = query.Where(predicate);

        return await query.ToListAsync();
    }

    public virtual async Task<T> CreateAsync(T entity)
    {
        var entityEntry = await _dbContext.Set<T>().AddAsync(entity);

        await _dbContext.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public virtual async Task<T> RemoveAsync(T entity)
    {
        var entityEntry = _dbContext.Set<T>().Remove(entity);

        await _dbContext.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public virtual async Task<T> UpdateAsync(T entity)
    {
        var entityEntry = _dbContext.Set<T>().Update(entity);

        await _dbContext.SaveChangesAsync();

        return entityEntry.Entity;
    }
}