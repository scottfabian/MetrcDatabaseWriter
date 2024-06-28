using MetrcAPIService;
using Microsoft.Extensions.Configuration;

namespace MetrcDatabaseWriter;

public class DataGatherer
{
    private MetrcAPI _metrc;
    private IConfiguration _config;
    internal MetrcMapper Mapper = new();
    private Dictionary<string, string> compoundTypeMap = new Dictionary<string, string>();
    private delegate Task<T> MetrcGetActive<T>(int pageNumber);
    private delegate Task<T> MetrcGetActiveDateRange<T>(DateTime dStart, DateTime dEnd, int pageNumber);
    private delegate T MapDtos<T, U>(IEnumerable<U> enumerable, Facility facility);

    public DataGatherer(MetrcAPI metrc, IConfiguration config)
    {
        _metrc = metrc;
        _config = config;
    }

    public async Task<List<LabTestResult>> GetLabTestResults(List<Package> packages, List<LabTestType> testTypes)
    {
        List<LabTestResult> results = new();
        List<Task<List<LabTestResult>>> tasks = new();

        foreach (var package in packages)
        {
            if (package.LabTestingState != "TestPassed")
            {
                continue;
            }

            tasks.Add(GetPackageLabTestResults(package.Id));

        }

        await Task.WhenAll(tasks);

        foreach (var task in tasks)
        {
            results.AddRange(task.Result);
        }


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

    private async Task<List<T>> GetActiveModels<T, U>(MetrcGetActive<GenericDataResponseDTO<U>> get, MapDtos<List<T>, U> map, Facility activeFacility, int pageNumber = 1)
    {
        List<U> returnDtos = await GetActiveDtos(get, pageNumber);
        List<T> models = map(returnDtos, activeFacility);

        return models;
    }

    private async Task<List<T>> GetActiveModels<T, U>(MetrcGetActiveDateRange<GenericDataResponseDTO<U>> get, MapDtos<List<T>, U> map, Facility facility, DateTime dStart, DateTime dEnd)
    {
        int dateDiff = (dEnd - dStart).Days;

        var returnObj = new List<T>();

        for (int i = 0; i < dateDiff; i++)
        {
            List<U> returnDtos = await GetActiveDtos<U>(get, dStart, dStart.AddDays(1));
            List<T> modelList = map(returnDtos, facility);
            returnObj.AddRange(modelList);
            dStart = dStart.AddDays(1);
        }

        return returnObj;

    }

    private async Task<List<T>> GetActiveDtos<T>(MetrcGetActive<GenericDataResponseDTO<T>> get, int pageNumber = 1)
    {
        List<T> returnDtos = new();

        GenericDataResponseDTO<T> response = await get(pageNumber);

        returnDtos.AddRange(response.Data);

        if (response.CurrentPage < response.TotalPages)
        {
            pageNumber++;
            returnDtos.AddRange(await GetActiveDtos<T>(get, pageNumber));
        }


        return returnDtos;
    }

    private async Task<List<T>> GetActiveDtos<T>(MetrcGetActiveDateRange<GenericDataResponseDTO<T>> get, DateTime dStart, DateTime dEnd, int pageNumber = 1)
    {
        List<T> dtos = new();

        try
        {
            var response = await get(dStart, dEnd, pageNumber);
            dtos.AddRange(response.Data);

            if (response.Page < response.TotalPages)
            {
                pageNumber++;
                dtos.AddRange(await GetActiveDtos<T>(get, dStart, dEnd, pageNumber));
            }

        }
        catch (TooManyRequestsException ex)
        {
            HandleMetrcException(ex);
            await Task.Delay(2000);
            dtos.AddRange(await GetActiveDtos<T>(get, dStart, dEnd, pageNumber));
        }
        catch (MetrcApiException ex)
        {
            HandleMetrcException(ex);
            return new List<T>();
        }
        catch (Exception ex) 
        {
            HandleDotNetException(ex);
        }

        return dtos;

    }

    

    #endregion Generic

    public async Task<List<LabTestResult>> GetPackageLabTestResults(int packageID)
    {
        GenericDataResponseDTO<LabTestResultDTO> dto = new();

        try
        {
            dto = await _metrc.GetLabResultsForPackage(packageID);
        }
        catch (TooManyRequestsException)
        {
            await Task.Delay(2000);
            dto = await _metrc.GetLabResultsForPackage(packageID);
        }
        catch (MetrcApiException ex)
        {
            HandleMetrcException(ex);
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
        var facilityDtos = await _metrc.GetActiveFacilities();

        return Mapper.FacilityDTOs_Facilities(facilityDtos);
    }

    public async Task<List<Harvest>> GetAllActiveHarvests(Facility activeFacility)
    {
        DateTime dStart = CalculateStartDate();
        DateTime dEnd = DateTime.Today.AddDays(1);

        return await GetActiveModels<Harvest, HarvestDTO>(_metrc.GetActiveHarvests, Mapper.HarvestDTOs_Harvests, activeFacility, dStart, dEnd);
    }

    public async Task<List<Item>> GetAllActiveItems(Facility activeFacility, int pageNumber = 1)
    {
        return await GetActiveModels(_metrc.GetActiveItems, Mapper.ItemDTOs_Items, activeFacility, pageNumber);
    }

    public async Task<List<Package>> GetAllActivePackages(Facility activeFacility)
    {
        DateTime dStart = CalculateStartDate();
        DateTime dEnd = DateTime.Today.AddDays(1);

        return await GetActiveModels(_metrc.GetActivePackages, Mapper.PackageDTOs_Packages, activeFacility, dStart, dEnd);
    }

    public async Task<List<Strain>> GetAllActiveStrains(Facility activeFacility, int pageNumber = 1)
    {
        return await GetActiveModels(_metrc.GetActiveStrains, Mapper.StrainDTOs_Strains, activeFacility, pageNumber);
    }

    public async Task<List<LabTestType>> GetAllTestTypes(Facility activeFacility, int pageNumber = 1)
    {
        return await GetActiveModels(_metrc.GetLabTestTypes, Mapper.LabTestTypeDTOs_LabTestTypes, activeFacility, pageNumber);
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

    private void HandleMetrcException(MetrcApiException ex)
    {
        Console.WriteLine($"Request Failed, status code {ex.StatusCode.ToString()}");
        Console.WriteLine(ex.RequestURI);
        Console.WriteLine(ex.Response);
    }

    private void HandleDotNetException(Exception ex)
    {
        throw new NotImplementedException();       
    }

    #endregion Utilities
}
