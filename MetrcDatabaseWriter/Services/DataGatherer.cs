using MetrcAPIService;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace MetrcDatabaseWriter;

public class DataGatherer : IDisposable
{
    public delegate void MetrcExceptionHandler(MetrcApiException exception);
    public event MetrcExceptionHandler MetrcExceptionThrown;

    public delegate void DotNetExceptionHandler(Exception ex);
    public event DotNetExceptionHandler DotNetExceptionThrown;

    private MetrcAPI _metrc;
    private IConfiguration _config;
    private ILogger _logger;
    internal MetrcMapper Mapper = new();

    private Dictionary<string, string> compoundTypeMap = new Dictionary<string, string>();

    private delegate Task<T> MetrcGetPageNumber<T>(int pageNumber);
    private delegate Task<T> MetrcGetDateRange<T>(DateTime dStart, DateTime dEnd, int pageNumber);
    private delegate T MapDtos<T, U>(IEnumerable<U> enumerable, Facility facility);
    
    
    
    private int _retryDelay = 1000;


    public DataGatherer(MetrcAPI metrc, IConfiguration config, ILogger logger)
    {
        _metrc = metrc;
        _config = config;
        _logger = logger;

        MetrcExceptionThrown += LogMetrcException;
        DotNetExceptionThrown += HandleDotNetException;
    }

    public async Task<List<LabTestResult>> GetBatchPackageLabTestResults(List<Package> packages, List<LabTestType> testTypes)
    {
        List<LabTestResult> results = new();
        List<Task<List<LabTestResult>>> tasks = new();

        foreach (var package in packages)
        {
            if (package.LabTestingState != "TestPassed")
            {
                continue;
            }

            results.AddRange(await GetPackageLabTestResults(package.Id));

            //tasks.Add(GetPackageLabTestResults(package.Id));

        }

        //await Task.WhenAll(tasks);

        //foreach (var task in tasks)
        //{
        //    results.AddRange(task.Result);
        //}


        foreach (var result in results)
        {
            var resultTestType = testTypes.Where(x => x.Name == result.TestTypeName).FirstOrDefault();
            result.LabTestTypeId = resultTestType!.Id;
            result.SetCustomFields(resultTestType);
            SetResultCompoundType(result);
        }

        return results;
    }


    #region GetRequests


    #region Generic

    private async Task<List<T>> GetModels<T, U>(MetrcGetPageNumber<GenericDataResponseDTO<U>> get, MapDtos<List<T>, U> map, Facility activeFacility, int pageNumber = 1)
    {
        List<U> returnDtos = await GetDtos(get, pageNumber);
        List<T> models = map(returnDtos, activeFacility);

        return models;
    }

    private async Task<List<T>> GetModels<T, U>(MetrcGetDateRange<GenericDataResponseDTO<U>> get, MapDtos<List<T>, U> map, Facility facility, DateTime dStart, DateTime dEnd)
    {
        int dateDiff = (dEnd - dStart).Days;

        var returnObj = new List<T>();

        for (int i = 0; i < dateDiff; i++)
        {
            List<U> returnDtos = await GetDtos<U>(get, dStart, dStart.AddDays(1));
            List<T> modelList = map(returnDtos, facility);
            returnObj.AddRange(modelList);
            dStart = dStart.AddDays(1);
        }

        return returnObj;

    }

    private async Task<List<T>> GetDtos<T>(MetrcGetPageNumber<GenericDataResponseDTO<T>> get, int pageNumber = 1)
    {
        List<T> returnDtos = new();

        GenericDataResponseDTO<T> response = await SendAndRetryMetrcRequest<T>(() => get(pageNumber));

        if (response.Data is not null)
        {
            returnDtos.AddRange(response.Data);
        }      

        if (response.CurrentPage < response.TotalPages)
        {
            pageNumber++;
            returnDtos.AddRange(await GetDtos<T>(get, pageNumber));
        }

        return returnDtos;

        //try
        //{
        //    GenericDataResponseDTO<T> response = await SendAndRetryMetrcRequest<T>(() => get(pageNumber));
        //    //GenericDataResponseDTO<T> response = await get(pageNumber);
        //    returnDtos.AddRange(response.Data);

        //    if (response.CurrentPage < response.TotalPages)
        //    {
        //        pageNumber++;
        //        returnDtos.AddRange(await GetDtos<T>(get, pageNumber));
        //    }

        //}
        //catch (TooManyRequestsException ex)
        //{
        //    LogMetrcException(ex);
        //    await Task.Delay(_retryDelay);
        //    returnDtos.AddRange(await GetDtos<T>(get, pageNumber));
        //}
        //catch (MetrcApiException ex)
        //{
        //    LogMetrcException(ex);
        //    return new List<T>();
        //}
        //catch (Exception ex)
        //{
        //    HandleDotNetException(ex);
        //}




        //return returnDtos;
    }

    private async Task<List<T>> GetDtos<T>(MetrcGetDateRange<GenericDataResponseDTO<T>> get, DateTime dStart, DateTime dEnd, int pageNumber = 1)
    {
        List<T> dtos = new();

        GenericDataResponseDTO<T> response = await SendAndRetryMetrcRequest<T>(() => get(dStart, dEnd, pageNumber));

        if (response.Data is not null)
        {
            dtos.AddRange(response.Data);
        }


        if (response.Page < response.TotalPages)
        {
            pageNumber++;
            dtos.AddRange(await GetDtos<T>(get, dStart, dEnd, pageNumber));
        }

        return dtos;

        //try
        //{
        //    GenericDataResponseDTO<T> response = await SendAndRetryMetrcRequest<T>(() => get(dStart, dEnd, pageNumber));
        //    dtos.AddRange(response.Data);

        //    if (response.Page < response.TotalPages)
        //    {
        //        pageNumber++;
        //        dtos.AddRange(await GetDtos<T>(get, dStart, dEnd, pageNumber));
        //    }

        //}
        //catch (TooManyRequestsException ex)
        //{
        //    LogMetrcException(ex);
        //    await Task.Delay(_retryDelay);
        //    dtos.AddRange(await GetDtos<T>(get, dStart, dEnd, pageNumber));
        //}
        //catch (MetrcApiException ex)
        //{
        //    LogMetrcException(ex);
        //    return new List<T>();
        //}
        //catch (Exception ex) 
        //{
        //    HandleDotNetException(ex);
        //}

        //return dtos;

    }

    private async Task<GenericDataResponseDTO<T>> SendAndRetryMetrcRequest<T>(Func<Task<GenericDataResponseDTO<T>>> apiCall)
    {
        int retryCount = 0;

        try
        {
            return await apiCall();
        }
        catch (TooManyRequestsException ex)
        {
            MetrcExceptionThrown?.Invoke(ex);
            int retryTimeMs = _retryDelay + (retryCount * 1000);
            await Task.Delay(retryTimeMs);
            return await SendAndRetryMetrcRequest(apiCall);
        }
        catch (MetrcApiException ex)
        {
            MetrcExceptionThrown?.Invoke(ex);
        }
        catch(Exception ex)
        {
            DotNetExceptionThrown?.Invoke(ex);
        }


        return new();

    }


    #endregion Generic

    public async Task<List<LabTestResult>> GetPackageLabTestResults(int packageID, int retryCount = 0)
    {
        GenericDataResponseDTO<LabTestResultDTO> dto = new();
        List<LabTestResult> labTestResults = new();

        try
        {
            dto = await _metrc.GetLabResultsForPackage(packageID);
        }
        catch (TooManyRequestsException)
        {
            int retryTime = _retryDelay + (retryCount * 1000);
            _logger.Warning("TooManyRequests response when querying lab results for PackageID {PackageID}, retrying after {RetryDelaySeconds}", packageID, (retryTime / 1000));
            await Task.Delay(retryTime);
            

            retryCount++;

            if (retryCount > 10)
            {
                _logger.Warning("Maximum retries hit for package {PackageID}, moving to next package", packageID);

                return new();
            }

            return await GetPackageLabTestResults(packageID, retryCount);
        }
        catch (MetrcApiException ex)
        {
            LogMetrcException(ex);
            return new List<LabTestResult>();
        }
        catch (Exception ex)
        {
            HandleDotNetException(ex);
        }

        return Mapper.LabTestResultDTOs_LabTestResults(dto.Data);

    }

    public async Task<List<Facility>> GetAllActiveFacilities()
    {
        try
        {
            var facilityDtos = await _metrc.GetActiveFacilities();

            return Mapper.FacilityDTOs_Facilities(facilityDtos);
        }
        catch (TooManyRequestsException)
        {
            var facilityDtos = await _metrc.GetActiveFacilities();

            return Mapper.FacilityDTOs_Facilities(facilityDtos);
        }

        return default;
    }

    public async Task<List<Harvest>> GetAllActiveHarvests(Facility activeFacility)
    {
        DateTime dStart = CalculateStartDate();
        DateTime dEnd = DateTime.Today.AddDays(1);

        return await GetModels<Harvest, HarvestDTO>(_metrc.GetActiveHarvests, Mapper.HarvestDTOs_Harvests, activeFacility, dStart, dEnd);
    }

    public async Task<List<Harvest>> GetAllInactiveHarvests(Facility activeFacility)
    {
        DateTime dStart = CalculateStartDate();
        DateTime dEnd = DateTime.Today.AddDays(1);

        return await GetModels<Harvest, HarvestDTO>(_metrc.GetInactiveHarvests, Mapper.HarvestDTOs_Harvests, activeFacility, dStart, dEnd);
    }

    public async Task<List<Item>> GetAllActiveItems(Facility activeFacility, int pageNumber = 1)
    {
        return await GetModels(_metrc.GetActiveItems, Mapper.ItemDTOs_Items, activeFacility, pageNumber);
    }

    public async Task<List<Item>> GetAllInactiveItems(Facility activeFacility, int pageNumber = 1)
    {
        return await GetModels(_metrc.GetInactiveItems, Mapper.ItemDTOs_Items, activeFacility, pageNumber);
    }

    //public async Task<List<Item>> GetItemsFromPackages(List<GenericDataResponseDTO<PackageDTO>> packageDtos, )

    public async Task<List<Package>> GetAllActivePackages(Facility activeFacility)
    {
        DateTime dStart = CalculateStartDate();
        DateTime dEnd = DateTime.Today.AddDays(1);

        List<Package> packages = await GetModels(_metrc.GetActivePackages, Mapper.PackageDTOs_Packages, activeFacility, dStart, dEnd);

        return await GetModels(_metrc.GetActivePackages, Mapper.PackageDTOs_Packages, activeFacility, dStart, dEnd);
    }

    public async Task<List<Package>> GetAllInActivePackages(Facility activeFacility)
    {
        DateTime dStart = CalculateStartDate();
        DateTime dEnd = DateTime.Today.AddDays(1);

        return await GetModels(_metrc.GetInactivePackages, Mapper.PackageDTOs_Packages, activeFacility, dStart, dEnd);
    }

    public async Task<List<Strain>> GetAllActiveStrains(Facility activeFacility, int pageNumber = 1)
    {
        return await GetModels(_metrc.GetActiveStrains, Mapper.StrainDTOs_Strains, activeFacility, pageNumber);
    }

    public async Task<List<LabTestType>> GetAllTestTypes(Facility activeFacility, int pageNumber = 1)
    {
        return await GetModels(_metrc.GetLabTestTypes, Mapper.LabTestTypeDTOs_LabTestTypes, activeFacility, pageNumber);
    }


    #endregion GetRequests


    #region Utilities

    public MetrcAPI SetFacilityLicense(string license)
    {
        _metrc.FacilityLicense = license;
        return _metrc;
    }

    private LabTestResult SetResultCompoundType(LabTestResult result)
    {
        string compoundName = result.CompoundName;
        if (compoundTypeMap.ContainsKey(compoundName))
        {
            result.CompoundType = compoundTypeMap[compoundName];
            return result;
        }

        var compoundType = _config[$"CompoundTypes:{compoundName}"];

        if (string.IsNullOrEmpty(compoundName) || string.IsNullOrEmpty(compoundType))
        {
            return result;
        }

        compoundTypeMap[compoundName] = compoundType;
 
        result.CompoundType = compoundTypeMap[compoundName];

        return result;
    }

    private DateTime CalculateStartDate()
    {
        int dataDepth = Int32.Parse(_config["Metrc:DataDepthMonths"]);
        return DateTime.Today.AddMonths(-1 * dataDepth);
    }

    private void LogMetrcException(MetrcApiException ex)
    {
        _logger.Error("Request failed. Status code: {StatusCode}", ex.StatusCode);
        _logger.Error("{RequestURI}", ex.RequestURI);
        _logger.Error("{ResponseMessage}", ex.Response);
    }

    private void HandleDotNetException(Exception ex)
    {
        throw ex;     
    }

    public void Dispose()
    {
        MetrcExceptionThrown -= LogMetrcException;
    }

    #endregion Utilities
}
