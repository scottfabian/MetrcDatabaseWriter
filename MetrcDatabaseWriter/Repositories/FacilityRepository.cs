using Microsoft.EntityFrameworkCore;
using Serilog;

namespace MetrcDatabaseWriter;

public class FacilityRepository : IRepository<Facility>
{
    private readonly ILogger _logger;
    private readonly MetrcDbContext _dbContext;

    public FacilityRepository(MetrcDbContext context, ILogger logger)
    {
        _dbContext = context;
        _logger = logger;
    }


    public void Add(Facility facility) => _dbContext.Facility.Add(facility);

    public void Update(Facility facility, Facility dbTarget) => _dbContext.Entry(dbTarget).CurrentValues.SetValues(facility);

    public void AddOrUpdate(Facility facility)
    {
        Facility? existingFacility = _dbContext.Facility.Find(facility.LicenseNumber);

        if (existingFacility is null)
        {
            _dbContext.Facility.Add(facility);

        }
        else if (!Equals(facility, existingFacility))
        {
            _dbContext.Entry(existingFacility!).CurrentValues.SetValues(facility);
        }
    }

    public void AddOrUpdate(Facility facility, Facility? dbTarget)
    {
        if (dbTarget is null)
        {
            Add(facility);
        }
        else if(!Equals(facility, dbTarget))
        {
            Update(facility, dbTarget);
        }
    }

    public void AddOrUpdate(List<Facility> facilities)
    {
        _logger.Information("Resolving database changes for {Entity}", typeof(Facility).ToString());

        HashSet<string> uniqueLicensesInResults = facilities.Select(x => x.LicenseNumber).ToHashSet();
        List<Facility> dbFacilities = _dbContext.Facility.Where(f => uniqueLicensesInResults.Contains(f.LicenseNumber)).ToList();

        foreach (var f in facilities)
        {
            Facility? dbMatch = dbFacilities.Where(x => x.LicenseNumber == f.LicenseNumber).FirstOrDefault();

            AddOrUpdate(f, dbMatch);
        }

        _logger.Information("Done");
    }

    public void Remove(Facility entity) => _dbContext.Facility.Remove(entity);

    public void Remove(List<Facility> facilities)
    {
        foreach (var facility in facilities)
        {
            Remove(facility);
        }
    }

    public Facility? Find(params object[] keyValues) => _dbContext.Facility.Find(keyValues);

    public List<Facility> GetAll() => _dbContext.Facility.ToList();

    
}
