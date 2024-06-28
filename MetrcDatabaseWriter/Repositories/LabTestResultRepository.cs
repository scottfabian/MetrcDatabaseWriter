using Serilog;

namespace MetrcDatabaseWriter;

public class LabTestResultRepository : IRepository<LabTestResult>
{
    private readonly MetrcDbContext _dbContext;
    private ILogger _logger;

    public LabTestResultRepository(MetrcDbContext context, ILogger logger)
    {
        _dbContext = context;
        _logger = logger;
    }


    public void AddOrUpdate(LabTestResult result)
    {
        LabTestResult? existingResult = _dbContext.LabTestResult
        .FirstOrDefault(r => r.LabTestResultId == result.LabTestResultId
                          && r.LabTestTypeId == result.LabTestTypeId
                          && r.PackageId == result.PackageId
                          && r.SourcePackageLabel == result.SourcePackageLabel);

        if (existingResult is null)
        {
            _dbContext.LabTestResult.Add(result);

        }
        else if (!Equals(result, existingResult))
        {
            _dbContext.Entry(existingResult!).CurrentValues.SetValues(result);
        }
    }

    public void AddOrUpdate(IEnumerable<LabTestResult> results)
    {
        _logger.Debug("Resolving LabTestResult database changes");
        foreach (var r in results)
        {
            AddOrUpdate(r);
        }
        _logger.Debug("Done");
    }

    public void Remove(LabTestResult result) => _dbContext.LabTestResult.Remove(result);

    public void Remove(IEnumerable<LabTestResult> results)
    {
        foreach(var r in results)
        {
            Remove(r);
        }
    }

    public LabTestResult? Find(params object[] keyValues) => _dbContext.LabTestResult.Find(keyValues);
}
