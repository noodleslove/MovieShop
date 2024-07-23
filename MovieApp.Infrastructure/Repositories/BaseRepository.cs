using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Interfaces.Repository;
using MovieApp.Infrastructure.Data;

namespace MovieApp.Infrastructure.Repositories;

public class BaseRepository<T> : IRepository<T> where T : class
{
    protected readonly MovieDbContext _movieDbContext;

    public BaseRepository(MovieDbContext movieDbContext)
    {
        _movieDbContext = movieDbContext;
    }
    
    public virtual int Insert(T entity)
    {
        _movieDbContext.Set<T>().Add(entity);
        return _movieDbContext.SaveChanges();
    }

    public virtual int Update(T entity)
    {
        _movieDbContext.Set<T>().Entry(entity).State = EntityState.Modified;
        return _movieDbContext.SaveChanges();
    }

    public virtual int Delete(int id)
    {
        var entity = GetById(id);
        if (entity == null)
        {
            return 0;
        }

        _movieDbContext.Set<T>().Remove(entity);
        return _movieDbContext.SaveChanges();
    }

    public virtual T? GetById(int id)
    {
        return _movieDbContext.Set<T>().Find(id);
    }

    public virtual IEnumerable<T> GetAll()
    {
        return _movieDbContext.Set<T>().ToList();
    }
}