namespace MetrcDatabaseWriter;

public interface IRepository<T> where T : class
{
    void Add(T entity);
    void Update(T entity, T dbTarget);
    void AddOrUpdate(List<T> entities);
    void AddOrUpdate(T entity);
    T? Find(params object[] keyValues);
    void Remove(List<T> entities);
    void Remove(T entity);
}