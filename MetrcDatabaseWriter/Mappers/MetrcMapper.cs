using MetrcAPIService;
using Riok.Mapperly.Abstractions;

namespace MetrcDatabaseWriter;

[Mapper(PropertyNameMappingStrategy = PropertyNameMappingStrategy.CaseInsensitive)]
public partial class MetrcMapper
{
    private Dictionary<(Type model, int id, string facility), IMetrcModel> ModelCache = new();
    public delegate T MetrcMap<T>(IMetrcDTO dto);

    public void ClearModelCache()
    {
        ModelCache = new();
    }

    #region GenericAndPrimitive

    

    public T AssignFacilityLicense<T>(T target, Facility facility) where T : IMetrcModel
    {
        var property = typeof(T).GetProperty("FacilityLicense");
        if (property != null && property.PropertyType == typeof(string))
        {
            property.SetValue(target, facility.LicenseNumber);
        }

        lock (ModelCache)
        {
            var cacheKey = (typeof(T), target.Id, facility.LicenseNumber);
            if (ModelCache.ContainsKey(cacheKey) && typeof(T) != typeof(LabTestResult))
            {
                return (T)ModelCache[cacheKey];
            }

            ModelCache[cacheKey] = target;
        }

        return target;
    }

    public List<T> AssignFacilityLicense<T>(List<T> target, Facility facility) where T : IMetrcModel
    {
        return Enumerable.ToList(Enumerable.Select(target, x => AssignFacilityLicense(x, facility)));
    }  

    public T DTO_ModelWithFacility<T>(IMetrcDTO source, MetrcMap<T> map, Facility facility) where T : IMetrcModel
    {
        T target = map(source);

        target = AssignFacilityLicense(target, facility);   

        return target;
    }

    public List<T> DTO_ModelsWithFacility<T>(IEnumerable<IMetrcDTO> source, MetrcMap<T> map, Facility facility) where T : IMetrcModel
    {
        return Enumerable.ToList(Enumerable.Select(source, x => DTO_ModelWithFacility(x, map, facility)));
    }

    private string[] MapToStringArray(object[] source)
    {
        var target = new string[source.Length];
        for (var i = 0; i < source.Length; i++)
        {
            target[i] = source[i].ToString();
        }
        return target;
    }

    #endregion GenericAndPrimitive 

    #region Packages

    public Package PackageDTO_Package(PackageDTO packageDto)
    {
        var target = new Package();
        target.Id = packageDto.Id;
        target.Label = packageDto.Label;
        target.PackageType = packageDto.PackageType;
        target.SourceHarvestCount = packageDto.SourceHarvestCount;
        target.SourcePackageCount = packageDto.SourcePackageCount;
        target.SourceProcessingJobCount = packageDto.SourceProcessingJobCount;
        target.SourceHarvestNames = packageDto.SourceHarvestNames;
        target.SourcePackageLabels = packageDto.SourcePackageLabels;
        target.LocationId = packageDto.LocationId;
        target.LocationName = packageDto.LocationName;
        target.LocationTypeName = packageDto.LocationTypeName;
        target.Quantity = (double)packageDto.Quantity;
        target.UnitOfMeasureName = packageDto.UnitOfMeasureName;
        target.UnitOfMeasureAbbreviation = packageDto.UnitOfMeasureAbbreviation;
        target.PatientLicenseNumber = packageDto.PatientLicenseNumber;
        target.ItemFromFacilityLicenseNumber = packageDto.ItemFromFacilityLicenseNumber;
        target.ItemFromFacilityName = packageDto.ItemFromFacilityName;
        target.Note = packageDto.Note;
        target.PackagedDate = packageDto.PackagedDate;
        target.ExpirationDate = packageDto.ExpirationDate;
        target.SellByDate = packageDto.SellByDate;
        target.UseByDate = packageDto.UseByDate;
        target.InitialLabTestingState = packageDto.InitialLabTestingState;
        target.LabTestingState = packageDto.LabTestingState;
        target.LabTestingStateDate = packageDto.LabTestingStateDate;
        target.LabTestResultExpirationDateTime = packageDto.LabTestResultExpirationDateTime;
        target.LabTestingRecordedDate = packageDto.LabTestingRecordedDate;
        target.IsProductionBatch = packageDto.IsProductionBatch;
        target.ProductionBatchNumber = packageDto.ProductionBatchNumber;
        target.SourceProductionBatchNumbers = packageDto.SourceProductionBatchNumbers;
        target.IsTradeSample = packageDto.IsTradeSample;
        target.IsTradeSamplePersistent = packageDto.IsTradeSamplePersistent;
        target.SourcePackageIsTradeSample = packageDto.SourcePackageIsTradeSample;
        target.IsDonation = packageDto.IsDonation;
        target.IsDonationPersistent = packageDto.IsDonationPersistent;
        target.SourcePackageIsDonation = packageDto.SourcePackageIsDonation;
        target.IsTestingSample = packageDto.IsTestingSample;
        target.IsProcessValidationTestingSample = packageDto.IsProcessValidationTestingSample;
        target.ProductRequiresRemediation = packageDto.ProductRequiresRemediation;
        target.ContainsRemediatedProduct = packageDto.ContainsRemediatedProduct;
        target.RemediationDate = packageDto.RemediationDate;
        target.ReceivedDateTime = packageDto.ReceivedDateTime;
        target.ReceivedFromManifestNumber = packageDto.ReceivedFromManifestNumber;
        target.ReceivedFromFacilityLicenseNumber = packageDto.ReceivedFromFacilityLicenseNumber;
        target.ReceivedFromFacilityName = packageDto.ReceivedFromFacilityName;
        target.IsOnHold = packageDto.IsOnHold;
        target.ArchivedDate = packageDto.ArchivedDate;
        target.FinishedDate = packageDto.FinishedDate;
        target.IsOnTrip = packageDto.IsOnTrip;
        target.IsOnRetailerDelivery = packageDto.IsOnRetailerDelivery;
        target.PackageForProductDestruction = packageDto.PackageForProductDestruction;
        target.LastModified = packageDto.LastModified;
        target.ItemId = packageDto.Item?.Id;
        return target;
    }

    public partial List<Package> PackageDTOs_Packages(IEnumerable<PackageDTO> packageDto);

    public Package PackageDTO_Package(PackageDTO packageDto, Facility facility)
    {
        var package = DTO_ModelWithFacility<Package>(packageDto, dto => PackageDTO_Package((PackageDTO)dto), facility);
        return package;

    }

    public List<Package> PackageDTOs_Packages(IEnumerable<PackageDTO> packageDtos, Facility facility)
    {
        return Enumerable.ToList(Enumerable.Select(packageDtos, x => PackageDTO_Package(x, facility)));
    }

    #endregion Packages

    #region Items

    public partial Item ItemDTO_Item(ItemDTO source);

    public partial List<Item> ItemDTOs_Items(IEnumerable<ItemDTO> items);

    public Item ItemDTO_Item(ItemDTO source, Facility facility)
    {
        return DTO_ModelWithFacility<Item>(source, dto => ItemDTO_Item((ItemDTO)dto), facility);
    }   

    public List<Item> ItemDTOs_Items(IEnumerable<ItemDTO> itemDTOs, Facility facility)
    {
        return DTO_ModelsWithFacility<Item>(itemDTOs, dto => ItemDTO_Item((ItemDTO)dto), facility);
    }

    #endregion Items

    #region Harvests

    public partial Harvest HarvestDTO_Harvest(HarvestDTO harvestDTO);

    public partial List<Harvest> HarvestDTOs_Harvests(IEnumerable<HarvestDTO> harvestDTOs);

    public Harvest HarvestDTO_Harvest(HarvestDTO harvestDTO, Facility facility)
    {
        return DTO_ModelWithFacility<Harvest>(harvestDTO, dto => HarvestDTO_Harvest((HarvestDTO)dto), facility);
    }

    public List<Harvest> HarvestDTOs_Harvests(IEnumerable<HarvestDTO> harvestDTOs, Facility facility)
    {
        return DTO_ModelsWithFacility<Harvest>(harvestDTOs, dto =>  HarvestDTO_Harvest((HarvestDTO)(dto)), facility);
    }

    #endregion Harvests

    #region LabData

    #region LabTestType

    public partial LabTestType LabTestTypeDTO_LabTestType(LabTestTypeDTO labTestType);

    public partial List<LabTestType> LabTestTypeDTOs_LabTestTypes(IEnumerable<LabTestTypeDTO> labTestTypeDTOs);

    public LabTestType LabTestTypeDTO_LabTestType(LabTestTypeDTO testTypeDTO, Facility facility)
    {
        return DTO_ModelWithFacility<LabTestType>(testTypeDTO, dto =>  LabTestTypeDTO_LabTestType((LabTestTypeDTO)dto), facility);
    }

    public List<LabTestType> LabTestTypeDTOs_LabTestTypes(IEnumerable<LabTestTypeDTO> labTestTypeDTOs, Facility facility)
    {
        return DTO_ModelsWithFacility<LabTestType>(labTestTypeDTOs, dto =>  LabTestTypeDTO_LabTestType((LabTestTypeDTO)(dto)), facility);
    }

    #endregion LabTestType

    #region LabTestResult

    public partial LabTestResult LabTestResultDTO_LabTestResult(LabTestResultDTO source);

    public partial List<LabTestResult> LabTestResultDTOs_LabTestResults(IEnumerable<LabTestResultDTO> source);

    //public LabTestResult LabTestResultDTO_LabTestResult(LabTestResultDTO source, Facility facility)
    //{
    //    return DTO_ModelWithFacility<LabTestResult>(source, dto =>  LabTestResultDTO_LabTestResult((LabTestResultDTO)dto), facility);
    //}

    //public List<LabTestResult> LabTestResultDTOs_LabTestResults(IEnumerable<LabTestResultDTO> source, Facility facility)
    //{
    //    return DTO_ModelsWithFacility<LabTestResult>(source, dto => LabTestResultDTO_LabTestResult((LabTestResultDTO)dto), facility);
    //}

    #endregion LabTestResult

    #endregion LabData

    #region Facilities

    public partial Facility FacilityTypeDTO_Facility(FacilityTypeDTO source);

    public Facility FacilityDTO_Facility(FacilityDTO facilityDTO)
    {
        var target = new Facility();
        target = FacilityTypeDTO_Facility(facilityDTO.FacilityType);

        if (facilityDTO.CredentialedDate != null)
        {
            target.CredentialedDate = DateTime.Parse(facilityDTO.CredentialedDate);
        }
        else
        {
            target.CredentialedDate = null;
        }
        if (facilityDTO.SupportActivationDate != null)
        {
            target.SupportActivationDate = DateTime.Parse(facilityDTO.SupportActivationDate);
        }
        else
        {
            target.SupportActivationDate = null;
        }
        if (facilityDTO.SupportExpirationDate != null)
        {
            target.SupportExpirationDate = DateTime.Parse(facilityDTO.SupportExpirationDate);
        }
        else
        {
            target.SupportExpirationDate = null;
        }
        if (facilityDTO.SupportLastPaidDate != null)
        {
            target.SupportLastPaidDate = DateTime.Parse(facilityDTO.SupportLastPaidDate);
        }
        else
        {
            target.SupportLastPaidDate = null;
        }
        target.LicenseNumber = facilityDTO.License.Number;
        target.HireDate = facilityDTO.HireDate;
        target.IsOwner = facilityDTO.IsOwner;
        target.IsManager = facilityDTO.IsManager;
        target.Name = facilityDTO.Name;
        target.Alias = facilityDTO.Alias;
        target.DisplayName = facilityDTO.DisplayName;
        

        //flatten license details
        target.LicenseNumber = facilityDTO.License.Number;
        if (facilityDTO.License.StartDate is not null)
        {
            target.StartDate = DateTime.Parse(facilityDTO.License.StartDate);
        }
        if (facilityDTO.License.EndDate is not null)
        {
            target.EndDate = DateTime.Parse(facilityDTO.License.EndDate);
        }
        target.LicenseType = facilityDTO.License.LicenseType;

        

        return target;
    }

    public partial List<Facility> FacilityDTOs_Facilities(IEnumerable<FacilityDTO> facilities);

    #endregion Facilities

    #region Strains

    public partial Strain StrainDTO_Strain(StrainDTO strainDTO);

    public partial List<Strain> StrainDTOs_Strains(IEnumerable<StrainDTO> strainDTOs);

    public Strain StrainDTO_Strain(StrainDTO strainDto, Facility facility)
    {
        return DTO_ModelWithFacility<Strain>(strainDto, dto => StrainDTO_Strain((StrainDTO)dto), facility);
    }

    public List<Strain> StrainDTOs_Strains(IEnumerable<StrainDTO> strainDTOs, Facility facility)
    {
        return DTO_ModelsWithFacility(strainDTOs, dto => StrainDTO_Strain((StrainDTO)dto), facility);
    }

    #endregion Strains
}
