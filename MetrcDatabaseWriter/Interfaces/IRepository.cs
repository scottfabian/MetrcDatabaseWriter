namespace MetrcDatabaseWriter;

public interface IRepository<T> where T : class
{
    void AddOrUpdate(IEnumerable<T> entities);
    void AddOrUpdate(T entity);
    T? Find(params object[] keyValues);
    void Remove(IEnumerable<T> entities);
    void Remove(T entity);
}