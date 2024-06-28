
using Microsoft.EntityFrameworkCore;

namespace MetrcDatabaseWriter;

public class FacilityRepository : IRepository<Facility>
{
    private readonly MetrcDbContext _dbContext;

    public FacilityRepository(MetrcDbContext context)
    {
        _dbContext = context;
    }

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

    public void AddOrUpdate(IEnumerable<Facility> facilities)
    {
        foreach (var f in facilities)
        {
            AddOrUpdate(f);
        }
    }

    public void Remove(Facility entity) => _dbContext.Facility.Remove(entity);

    public void Remove(IEnumerable<Facility> facilities)
    {
        foreach (var facility in facilities)
        {
            Remove(facility);
        }
    }

    public Facility? Find(params object[] keyValues) => _dbContext.Facility.Find(keyValues);

    public List<Facility> GetAll() => _dbContext.Facility.ToList();

}
