namespace MovieApp.Core.Interfaces.Repository;

public interface IRepository<T> where T : class
{
    int Insert(T entity);
    int Update(T entity);
    int Delete(int id);
    T? GetById(int id);
    IEnumerable<T> GetAll();
}