using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text.Json;

namespace MetrcDatabaseWriter;

public class MetrcModelRepository<T> : IRepository<T> where T : class, IMetrcModel
{
    private readonly MetrcDbContext _dbContext;
    private DbSet<T> _dbSet;
    private ILogger _logger;

    public MetrcModelRepository(MetrcDbContext context, ILogger logger)
    {
        _dbContext = context;
        _dbSet = _dbContext.Set<T>();
        _logger = logger;
    }
    
    public void Add(T entity) => _dbSet.Add(entity);

    public void Update(T entity, T dbTarget) => _dbContext.Entry(dbTarget).CurrentValues.SetValues(entity);

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

    public void AddOrUpdate(T source, T? dbTarget)
    {
        if (dbTarget is null)
        {
            Add(source);
        }
        else if (!Equals(source, dbTarget))
        {
            Update(source, dbTarget);
        }
    }

    public void AddOrUpdate(List<T> entities)
    {
        HashSet<int> uniqueIdsInResults = entities.Select(x => x.Id).ToHashSet();
        List<T> dbRecords = _dbSet.Where(r => uniqueIdsInResults.Contains(r.Id)).ToList();

        foreach (var e in entities)
        {
            T? dbMatch = dbRecords.Where(x => x.Id == e.Id && x.FacilityLicense == e.FacilityLicense).FirstOrDefault();

            AddOrUpdate(e, dbMatch);
        }
    }

    private void AddOrUpdateSubset(List<T> newEntities, List<T> dbEntities)
    {
        foreach (var e in newEntities)
        {
            T? dbMatch = _dbSet.Where(x => x.Id == e.Id).FirstOrDefault();

            AddOrUpdate(e, dbMatch);
        }
    }

    public void Remove(T entity) => _dbSet.Remove(entity);

    public void Remove(List<T> entities)
    {
        foreach (var e in entities)
        {
            Remove(e);
        }
    }

    public List<T> GetAll() => _dbSet.ToList();

    public T? Find(params object[] keyValues) => _dbSet.Find(keyValues);
}
