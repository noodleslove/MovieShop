using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Interfaces.Repository;
using MovieApp.Infrastructure.Data;

namespace MovieApp.Infrastructure.Repositories;

public class BaseAsyncRepository<T> : IAsyncRepository<T> where T : class
{
    protected readonly MovieDbContext _movieDbContext;

    public BaseAsyncRepository(MovieDbContext movieDbContext)
    {
        _movieDbContext = movieDbContext;
    }
    
    public virtual async Task<int> InsertAsync(T entity)
    {
        await _movieDbContext.Set<T>().AddAsync(entity);
        return await _movieDbContext.SaveChangesAsync();
    }

    public virtual async Task<int> UpdateAsync(T entity)
    {
        _movieDbContext.Set<T>().Entry(entity).State = EntityState.Modified;
        return await _movieDbContext.SaveChangesAsync();
    }

    public virtual async Task<int> DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null)
        {
            return 1;
        }

        _movieDbContext.Set<T>().Remove(entity);
        return await _movieDbContext.SaveChangesAsync();
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await _movieDbContext.Set<T>().FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _movieDbContext.Set<T>().ToListAsync();
    }
}