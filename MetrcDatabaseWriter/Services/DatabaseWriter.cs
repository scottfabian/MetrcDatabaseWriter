using Microsoft.Extensions.Configuration;
using Serilog;

namespace MetrcDatabaseWriter;

public class DatabaseWriter
{
    private readonly MetrcDbContext _dbContext;
    private readonly IConfiguration _config;
    private readonly DataGatherer _gatherer;
    private readonly List<Facility> _facilities;
    private readonly List<string> _targetFacilities;
    private readonly string _connectionString;
    private readonly ILogger _logger;

    private readonly MetrcModelRepository<Package> _packageRepository;
    private readonly MetrcModelRepository<Harvest> _harvestRepository;
    private readonly MetrcModelRepository<LabTestType> _labTestTypeRepository;
    private readonly MetrcModelRepository<Strain> _strainRepository;
    private readonly LabTestResultRepository _labTestResultRepository;
    private readonly FacilityRepository _facilityRepository;
    private readonly MetrcModelRepository<Item> _itemRepository;



    public DatabaseWriter(IConfiguration config, DataGatherer gatherer, MetrcDbContext dbContext, ILogger logger)
    {
        _config = config;
        _gatherer = gatherer;
        _targetFacilities = _config.GetSection("Metrc:FacilityLicense").Get<List<string>>()!;
        _connectionString = _config["ConnectionStrings:SqlConnection"]!;
        _dbContext = dbContext;
        _logger = logger;

        _packageRepository = new(dbContext, logger);
        _harvestRepository = new(dbContext, logger);
        _labTestTypeRepository = new(dbContext, logger);
        _facilityRepository = new(dbContext, logger);
        _labTestResultRepository = new(dbContext, logger);
        _strainRepository = new(dbContext, logger);
        _itemRepository = new(dbContext, logger);


        _facilities = PopulateFacilites().GetAwaiter().GetResult();
    }

    private async Task<List<Facility>> PopulateFacilites()
    {
        var facilities = await _gatherer.GetAllActiveFacilities();

        facilities = facilities.Where(x =>
        {
            if (_targetFacilities is null || _targetFacilities.Count == 0)
            {
                return true; // if there are no target facilities specified or fail to get from config file, default to all facilities
            }

            return _targetFacilities.Contains(x.LicenseNumber);

        }).ToList();

        return facilities;
    }

    public async Task SyncMetrcData()
    {

        _logger.Information("Checking connection to database...");

        if (!CheckDatabaseConnection())
        {
            _logger.Error("Connection Failed. Check connection string and DatabaseWriteMode settings in appsettings.json");
            return;
        }

        _logger.Information("Database connection successful");

        List<Package> packagesRetrieved = new();
        List<Harvest> harvestsRetrieved = new();
        List<LabTestType> testTypesRetrieved = new();
        List<Strain> strainsRetrieved = new();
        List<LabTestResult> testResultsRetrieved = new();
        List<Item> itemsRetrieved = new();

        _logger.Information("Retrieving MetrcData");

        foreach (var facility in _facilities)
        {
            _gatherer.SetFacilityLicense(facility.LicenseNumber);

            // Start all tasks concurrently
            var harvestsTask = _gatherer.GetAllActiveHarvests(facility);
            var packagesTask = _gatherer.GetAllActivePackages(facility);
            var testTypesTask = _gatherer.GetAllTestTypes(facility);
            var strainsTask = _gatherer.GetAllActiveStrains(facility);
            var itemsTask = _gatherer.GetAllActiveItems(facility);

            // Wait for all tasks to complete
            await Task.WhenAll(harvestsTask, packagesTask, testTypesTask, strainsTask);

            // Add the results to the respective collections
            harvestsRetrieved.AddRange(await harvestsTask);
            packagesRetrieved.AddRange(await packagesTask);
            testTypesRetrieved.AddRange(await testTypesTask);
            strainsRetrieved.AddRange(await strainsTask);
            itemsRetrieved.AddRange(await itemsTask);
        }

        testResultsRetrieved = await _gatherer.GetLabTestResults(packagesRetrieved, testTypesRetrieved);

        _logger.Information("Cleaning up memory");
        //clean up memory
        packagesRetrieved.TrimExcess();
        harvestsRetrieved.TrimExcess();
        testTypesRetrieved.TrimExcess();
        strainsRetrieved.TrimExcess();
        testResultsRetrieved.TrimExcess();
        itemsRetrieved.TrimExcess();
        GC.Collect();


        _logger.Information("Resolving changes with database");

        _facilityRepository.AddOrUpdate(_facilities);
        _itemRepository.AddOrUpdate(itemsRetrieved);
        _harvestRepository.AddOrUpdate(harvestsRetrieved);
        _labTestTypeRepository.AddOrUpdate(testTypesRetrieved);
        _labTestResultRepository.AddOrUpdate(testResultsRetrieved);
        _strainRepository.AddOrUpdate(strainsRetrieved);
        _packageRepository.AddOrUpdate(packagesRetrieved);

        _logger.Information("Saving changes to database");

        _dbContext.SaveChanges();

        _gatherer.Mapper.ClearModelCache();

        _logger.Information("Metrc data sync complete");
    }

    private bool CheckDatabaseConnection()
    {
        return _dbContext.Database.CanConnect();
    }

}
