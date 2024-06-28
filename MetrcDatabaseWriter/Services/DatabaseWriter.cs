using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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



    public DatabaseWriter(IConfiguration config, DataGatherer gatherer, MetrcDbContext dbContext)
    {
        _config = config;
        _gatherer = gatherer;
        _targetFacilities = _config.GetSection("Metrc:FacilityLicense").Get<List<string>>()!;
        _connectionString = _config["ConnectionStrings:SqlConnection"]!;
        _dbContext = dbContext;
        //_logger = logger;

        _packageRepository = new(dbContext);
        _harvestRepository = new(dbContext);
        _labTestTypeRepository = new(dbContext);
        _facilityRepository = new(dbContext);
        _labTestResultRepository = new(dbContext);
        _strainRepository = new(dbContext);
        _itemRepository = new(dbContext);


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
        List<Package> packagesRetrieved = new();
        List<Harvest> harvestsRetrieved = new();
        List<LabTestType> testTypesRetrieved = new();
        List<Strain> strainsRetrieved = new();
        List<LabTestResult> testResultsRetrieved = new();
        List<Item> itemsRetrieved = new();



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

            // Augment packages with the obtained data


        }

        testResultsRetrieved = await _gatherer.GetLabTestResults(packagesRetrieved, testTypesRetrieved);

        //clean up memory
        packagesRetrieved.TrimExcess();
        harvestsRetrieved.TrimExcess();
        testTypesRetrieved.TrimExcess();
        strainsRetrieved.TrimExcess();
        testResultsRetrieved.TrimExcess();
        itemsRetrieved.TrimExcess();
        GC.Collect();

        //Package updatedPackage = packagesRetrieved.Where(x => x.Label == "1A40F0100000ED9000002788").First();
        //updatedPackage.SourceHarvestCount = 69;

        _facilityRepository.AddOrUpdate(_facilities);
        _itemRepository.AddOrUpdate(itemsRetrieved);
        _harvestRepository.AddOrUpdate(harvestsRetrieved);
        _labTestTypeRepository.AddOrUpdate(testTypesRetrieved);
        _labTestResultRepository.AddOrUpdate(testResultsRetrieved);
        _strainRepository.AddOrUpdate(strainsRetrieved);
        _packageRepository.AddOrUpdate(packagesRetrieved);

        _dbContext.SaveChanges();

        _gatherer.Mapper.ClearModelCache();
    }

}
