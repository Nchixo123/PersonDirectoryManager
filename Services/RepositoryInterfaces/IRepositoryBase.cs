using System.Linq.Expressions;

namespace Services.RepositoryInterfaces;

public interface IRepositoryBase<T> where T : class
{
    T Get(params object[] id);
    Task<T> GetAsync(params object[] id);
    IQueryable<T> Set(Expression<Func<T, bool>> predicate);
    IQueryable<T> Set();
    Task<IQueryable<T>> SetAsync();
    void Insert(T entity);
    void Update(T entity);
    void InsertOrUpdate(T entity);
    void Delete(object id);
    void Delete(T entity);
}
