using Microsoft.EntityFrameworkCore;
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

    public void Add(LabTestResult result) => _dbContext.LabTestResult.Add(result);

    public void Update(LabTestResult source, LabTestResult dbTarget) => _dbContext.Entry(dbTarget).CurrentValues.SetValues(source);

    public void AddOrUpdate(LabTestResult result)
    {
        LabTestResult? existingResult = _dbContext.LabTestResult
                                            .FirstOrDefault(r => r.LabTestResultId == result.LabTestResultId
                                                              && r.LabTestTypeId == result.LabTestTypeId
                                                              && r.PackageId == result.PackageId
                                                              && r.SourcePackageLabel == result.SourcePackageLabel);

        if (existingResult is null)
        {
            Add(result);
        }
        else if (!Equals(result, existingResult))
        {
            result.Id = existingResult.Id;
            Update(result, existingResult);
        }
    }

    public void AddOrUpdate(LabTestResult source, LabTestResult? dbTarget)
    {
        if (dbTarget is null)
        {
            Add(source);
        }
        else if(!Equals(source, dbTarget))
        {
            source.Id = dbTarget.Id;
            Update(source, dbTarget);
        }
    }

    private void AddOrUpdateSubset(List<LabTestResult> currentResults, List<LabTestResult> dbResults)
    {
        foreach (var cResult in currentResults)
        {
            
            LabTestResult? dbMatch = dbResults.FirstOrDefault(r => r.LabTestResultId == cResult.LabTestResultId
                                                    && r.LabTestTypeId == cResult.LabTestTypeId
                                                    && r.PackageId == cResult.PackageId
                                                    && r.SourcePackageLabel == cResult.SourcePackageLabel);

            AddOrUpdate(cResult, dbMatch);
        }
    }

    public void AddOrUpdate(List<LabTestResult> results)
    {
        _logger.Information("Resolving database changes for {Entity}", typeof(LabTestResult).ToString());

        HashSet<int> uniqueResultIds = results.Select(x => x.LabTestResultId).ToHashSet();

        foreach (var id in uniqueResultIds)
        {
            List<LabTestResult> dbResults = _dbContext.LabTestResult.Where(r => r.LabTestResultId == id).ToList();
            List<LabTestResult> resultsForId = results.Where(x => x.LabTestResultId == id).ToList();

            AddOrUpdateSubset(resultsForId, dbResults);
        }

        _logger.Information("Done");
    }

    public void Remove(LabTestResult result) => _dbContext.LabTestResult.Remove(result);

    public void Remove(List<LabTestResult> results)
    {
        foreach(var r in results)
        {
            Remove(r);
        }
    }

    public LabTestResult? Find(params object[] keyValues) => _dbContext.LabTestResult.Find(keyValues);
}
