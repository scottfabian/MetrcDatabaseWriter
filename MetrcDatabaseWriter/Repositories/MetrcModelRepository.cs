using Microsoft.EntityFrameworkCore;

namespace MetrcDatabaseWriter;

public class MetrcModelRepository<T> : IRepository<T> where T : class, IMetrcModel
{
    private readonly MetrcDbContext _dbContext;
    private DbSet<T> _dbSet;

    public MetrcModelRepository(MetrcDbContext context)
    {
        _dbContext = context;
        _dbSet = _dbContext.Set<T>();
    }
    

    public void AddOrUpdate(T entity)
    {
        T? existingEntity = _dbSet.Find(entity.Id, entity.FacilityLicense);

        if (existingEntity is null)
        {
            _dbSet.Add(entity);
            
        }
        else if(!Equals(entity, existingEntity))
        {
            _dbContext.Entry(existingEntity!).CurrentValues.SetValues(entity);
        }       
    }

    public void AddOrUpdate(IEnumerable<T> entities)
    {
        foreach (var e in entities)
        {
            AddOrUpdate(e);
        }
    }

    public void Remove(T entity) => _dbSet.Remove(entity);

    public void Remove(IEnumerable<T> entities)
    {
        foreach (var e in entities)
        {
            Remove(e);
        }
    }

    public List<T> GetAll() => _dbSet.ToList();

    public T? Find(params object[] keyValues) => _dbSet.Find(keyValues);
}
