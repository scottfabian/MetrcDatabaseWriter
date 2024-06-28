using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetrcDatabaseWriter.Migrations
{
    /// <inheritdoc />
    public partial class MetrcSQLMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facility",
                columns: table => new
                {
                    LicenseNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LicenseType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HireDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOwner = table.Column<bool>(type: "bit", nullable: false),
                    IsManager = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CredentialedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SupportActivationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SupportExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SupportLastPaidDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsMedical = table.Column<bool>(type: "bit", nullable: false),
                    IsRetail = table.Column<bool>(type: "bit", nullable: false),
                    IsHemp = table.Column<bool>(type: "bit", nullable: false),
                    RestrictHarvestPlantRestoreTimeHours = table.Column<int>(type: "int", nullable: true),
                    TotalMemberPatientsAllowed = table.Column<int>(type: "int", nullable: true),
                    RestrictWholesalePriceEditDays = table.Column<int>(type: "int", nullable: true),
                    RestrictPlantBatchAdjustmentTimeHours = table.Column<int>(type: "int", nullable: true),
                    CanGrowPlants = table.Column<bool>(type: "bit", nullable: false),
                    CanCreateOpeningBalancePlantBatches = table.Column<bool>(type: "bit", nullable: false),
                    CanClonePlantBatches = table.Column<bool>(type: "bit", nullable: false),
                    CanTagPlantBatches = table.Column<bool>(type: "bit", nullable: false),
                    CanAssignLocationsToPlantBatches = table.Column<bool>(type: "bit", nullable: false),
                    PlantsRequirePatientAffiliation = table.Column<bool>(type: "bit", nullable: false),
                    PlantBatchesCanContainMotherPlants = table.Column<bool>(type: "bit", nullable: false),
                    CanUpdatePlantStrains = table.Column<bool>(type: "bit", nullable: false),
                    CanTrackVegetativePlants = table.Column<bool>(type: "bit", nullable: false),
                    CanCreateImmaturePlantPackagesFromPlants = table.Column<bool>(type: "bit", nullable: false),
                    CanPackageVegetativePlants = table.Column<bool>(type: "bit", nullable: false),
                    CanPackageWaste = table.Column<bool>(type: "bit", nullable: false),
                    CanReportHarvestSchedules = table.Column<bool>(type: "bit", nullable: false),
                    CanSubmitHarvestsForTesting = table.Column<bool>(type: "bit", nullable: false),
                    CanRequireHarvestSampleLabTestBatches = table.Column<bool>(type: "bit", nullable: false),
                    CanReportStrainProperties = table.Column<bool>(type: "bit", nullable: false),
                    CanCreateOpeningBalancePackages = table.Column<bool>(type: "bit", nullable: false),
                    CanCreateDerivedPackages = table.Column<bool>(type: "bit", nullable: false),
                    CanAssignLocationsToPackages = table.Column<bool>(type: "bit", nullable: false),
                    CanUpdateLocationsOnPackages = table.Column<bool>(type: "bit", nullable: false),
                    PackagesRequirePatientAffiliation = table.Column<bool>(type: "bit", nullable: false),
                    CanCreateTradeSamplePackages = table.Column<bool>(type: "bit", nullable: false),
                    CanDonatePackages = table.Column<bool>(type: "bit", nullable: false),
                    CanSubmitPackagesForTesting = table.Column<bool>(type: "bit", nullable: false),
                    CanCreateProcessValidationPackages = table.Column<bool>(type: "bit", nullable: false),
                    CanRequirePackageSampleLabTestBatches = table.Column<bool>(type: "bit", nullable: false),
                    CanRequestProductRemediation = table.Column<bool>(type: "bit", nullable: false),
                    CanRemediatePackagesWithFailedLabResults = table.Column<bool>(type: "bit", nullable: false),
                    CanInfuseProducts = table.Column<bool>(type: "bit", nullable: false),
                    CanRecordProcessingJobs = table.Column<bool>(type: "bit", nullable: false),
                    CanRecordProductForDestruction = table.Column<bool>(type: "bit", nullable: false),
                    CanDestroyProduct = table.Column<bool>(type: "bit", nullable: false),
                    CanTestPackages = table.Column<bool>(type: "bit", nullable: false),
                    TestsRequireLabSample = table.Column<bool>(type: "bit", nullable: false),
                    CanTransferFromExternalFacilities = table.Column<bool>(type: "bit", nullable: false),
                    CanSellToConsumers = table.Column<bool>(type: "bit", nullable: false),
                    CanSellToPatients = table.Column<bool>(type: "bit", nullable: false),
                    CanSellToExternalPatients = table.Column<bool>(type: "bit", nullable: false),
                    CanSellToCaregivers = table.Column<bool>(type: "bit", nullable: false),
                    CanTakePlantBatchesOnTrip = table.Column<bool>(type: "bit", nullable: false),
                    CanTakePlantsOnTrip = table.Column<bool>(type: "bit", nullable: false),
                    CanTakeHarvestsOnTrip = table.Column<bool>(type: "bit", nullable: false),
                    CanTakePackagesOnTrip = table.Column<bool>(type: "bit", nullable: false),
                    CanSellFromPackagesOnTrip = table.Column<bool>(type: "bit", nullable: false),
                    AdvancedSales = table.Column<bool>(type: "bit", nullable: false),
                    SalesRequirePatientNumber = table.Column<bool>(type: "bit", nullable: false),
                    SalesRequireExternalPatientNumber = table.Column<bool>(type: "bit", nullable: false),
                    SalesRequireExternalPatientIdentificationMethod = table.Column<bool>(type: "bit", nullable: false),
                    SalesRequireCaregiverNumber = table.Column<bool>(type: "bit", nullable: false),
                    SalesRequireCaregiverPatientNumber = table.Column<bool>(type: "bit", nullable: false),
                    CanDeliverSalesToConsumers = table.Column<bool>(type: "bit", nullable: false),
                    SalesDeliveryAllowPlannedRoute = table.Column<bool>(type: "bit", nullable: false),
                    SalesDeliveryAllowAddress = table.Column<bool>(type: "bit", nullable: false),
                    SalesDeliveryAllowCity = table.Column<bool>(type: "bit", nullable: false),
                    SalesDeliveryAllowState = table.Column<bool>(type: "bit", nullable: false),
                    SalesDeliveryAllowCounty = table.Column<bool>(type: "bit", nullable: false),
                    SalesDeliveryAllowZip = table.Column<bool>(type: "bit", nullable: false),
                    SalesDeliveryRequireConsumerId = table.Column<bool>(type: "bit", nullable: false),
                    CanDeliverSalesToPatients = table.Column<bool>(type: "bit", nullable: false),
                    SalesDeliveryRequirePatientNumber = table.Column<bool>(type: "bit", nullable: false),
                    SalesDeliveryRequireRecipientName = table.Column<bool>(type: "bit", nullable: false),
                    IsSalesDeliveryHub = table.Column<bool>(type: "bit", nullable: false),
                    CanHaveMemberPatients = table.Column<bool>(type: "bit", nullable: false),
                    CanReportPatientCheckIns = table.Column<bool>(type: "bit", nullable: false),
                    CanSpecifyPatientSalesLimitExemption = table.Column<bool>(type: "bit", nullable: false),
                    CanReportPatientsAdverseResponses = table.Column<bool>(type: "bit", nullable: false),
                    RetailerDelivery = table.Column<bool>(type: "bit", nullable: false),
                    RetailerDeliveryAllowTradeSamples = table.Column<bool>(type: "bit", nullable: false),
                    RetailerDeliveryAllowDonations = table.Column<bool>(type: "bit", nullable: false),
                    RetailerDeliveryRequirePrice = table.Column<bool>(type: "bit", nullable: false),
                    RetailerDeliveryAllowPartialPackages = table.Column<bool>(type: "bit", nullable: false),
                    CanCreatePartialPackages = table.Column<bool>(type: "bit", nullable: false),
                    CanAdjustSourcePackagesWithPartials = table.Column<bool>(type: "bit", nullable: false),
                    CanReportOperationalExceptions = table.Column<bool>(type: "bit", nullable: false),
                    CanReportAdulteration = table.Column<bool>(type: "bit", nullable: false),
                    CanGenerateProductLabel = table.Column<bool>(type: "bit", nullable: false),
                    CanPrintProductLabel = table.Column<bool>(type: "bit", nullable: false),
                    CanReceiveAssociateProductLabel = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facility", x => x.LicenseNumber);
                });

            migrationBuilder.CreateTable(
                name: "Harvest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FacilityLicense = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HarvestType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceStrainCount = table.Column<int>(type: "int", nullable: false),
                    SourceStrainNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DryingLocationId = table.Column<int>(type: "int", nullable: false),
                    DryingLocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DryingLocationTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientLicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentWeight = table.Column<double>(type: "float", nullable: false),
                    TotalWasteWeight = table.Column<double>(type: "float", nullable: false),
                    PlantCount = table.Column<int>(type: "int", nullable: false),
                    TotalWetWeight = table.Column<double>(type: "float", nullable: false),
                    TotalRestoredWeight = table.Column<double>(type: "float", nullable: false),
                    PackageCount = table.Column<int>(type: "int", nullable: false),
                    TotalPackagedWeight = table.Column<double>(type: "float", nullable: false),
                    UnitOfWeightName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LabTestingState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LabTestingStateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsOnHold = table.Column<bool>(type: "bit", nullable: false),
                    HarvestStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinishedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchivedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsOnTrip = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harvest", x => new { x.Id, x.FacilityLicense });
                    table.ForeignKey(
                        name: "FK_Harvest_Facility_FacilityLicense",
                        column: x => x.FacilityLicense,
                        principalTable: "Facility",
                        principalColumn: "LicenseNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FacilityLicense = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductCategoryType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsExpirationDateRequired = table.Column<bool>(type: "bit", nullable: false),
                    HasExpirationDate = table.Column<bool>(type: "bit", nullable: false),
                    IsSellByDateRequired = table.Column<bool>(type: "bit", nullable: false),
                    HasSellByDate = table.Column<bool>(type: "bit", nullable: false),
                    IsUseByDateRequired = table.Column<bool>(type: "bit", nullable: false),
                    HasUseByDate = table.Column<bool>(type: "bit", nullable: false),
                    QuantityType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultLabTestingState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitOfMeasureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovalStatusDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StrainId = table.Column<int>(type: "int", nullable: true),
                    StrainName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemBrandId = table.Column<int>(type: "int", nullable: true),
                    ItemBrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdministrationMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitCbdPercent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitCbdContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitCbdContentUnitOfMeasureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitCbdContentDose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitCbdContentDoseUnitOfMeasureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitThcPercent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitThcContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitThcContentUnitOfMeasureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitThcContentDose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitThcContentDoseUnitOfMeasureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitVolume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitVolumeUnitOfMeasureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitWeight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitWeightUnitOfMeasureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServingSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplyDurationDays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfDoses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitQuantity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitQuantityUnitOfMeasureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicIngredients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Allergens = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductImages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPhotoDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LabelImages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LabelPhotoDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackagingImages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackagingPhotoDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPDFDocuments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => new { x.Id, x.FacilityLicense });
                    table.UniqueConstraint("AK_Item_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Facility_FacilityLicense",
                        column: x => x.FacilityLicense,
                        principalTable: "Facility",
                        principalColumn: "LicenseNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LabTestType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FacilityLicense = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiresTestResult = table.Column<bool>(type: "bit", nullable: false),
                    InformationalOnly = table.Column<bool>(type: "bit", nullable: false),
                    AlwaysPasses = table.Column<bool>(type: "bit", nullable: false),
                    MaxAllowedFailureCount = table.Column<int>(type: "int", nullable: false),
                    LabTestResultMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LabTestResultMinimum = table.Column<double>(type: "float", nullable: false),
                    LabTestResultMaximum = table.Column<double>(type: "float", nullable: false),
                    LabTestResultExpirationDays = table.Column<int>(type: "int", nullable: true),
                    DependencyMode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTestType", x => new { x.Id, x.FacilityLicense });
                    table.ForeignKey(
                        name: "FK_LabTestType_Facility_FacilityLicense",
                        column: x => x.FacilityLicense,
                        principalTable: "Facility",
                        principalColumn: "LicenseNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Strain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FacilityLicense = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestingStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThcLevel = table.Column<double>(type: "float", nullable: true),
                    CbdLevel = table.Column<double>(type: "float", nullable: true),
                    IndicaPercentage = table.Column<double>(type: "float", nullable: false),
                    SativaPercentage = table.Column<double>(type: "float", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    Genetics = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strain", x => new { x.Id, x.FacilityLicense });
                    table.ForeignKey(
                        name: "FK_Strain_Facility_FacilityLicense",
                        column: x => x.FacilityLicense,
                        principalTable: "Facility",
                        principalColumn: "LicenseNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FacilityLicense = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceHarvestCount = table.Column<int>(type: "int", nullable: false),
                    SourcePackageCount = table.Column<int>(type: "int", nullable: false),
                    SourceProcessingJobCount = table.Column<int>(type: "int", nullable: false),
                    SourceHarvestNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourcePackageLabels = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    UnitOfMeasureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitOfMeasureAbbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientLicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemFromFacilityLicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemFromFacilityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackagedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SellByDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UseByDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InitialLabTestingState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LabTestingState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LabTestingStateDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LabTestResultExpirationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LabTestingRecordedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsProductionBatch = table.Column<bool>(type: "bit", nullable: false),
                    ProductionBatchNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceProductionBatchNumbers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTradeSample = table.Column<bool>(type: "bit", nullable: false),
                    IsTradeSamplePersistent = table.Column<bool>(type: "bit", nullable: false),
                    SourcePackageIsTradeSample = table.Column<bool>(type: "bit", nullable: false),
                    IsDonation = table.Column<bool>(type: "bit", nullable: false),
                    IsDonationPersistent = table.Column<bool>(type: "bit", nullable: false),
                    SourcePackageIsDonation = table.Column<bool>(type: "bit", nullable: false),
                    IsTestingSample = table.Column<bool>(type: "bit", nullable: false),
                    IsProcessValidationTestingSample = table.Column<bool>(type: "bit", nullable: false),
                    ProductRequiresRemediation = table.Column<bool>(type: "bit", nullable: false),
                    ContainsRemediatedProduct = table.Column<bool>(type: "bit", nullable: false),
                    RemediationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceivedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceivedFromManifestNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivedFromFacilityLicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivedFromFacilityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOnHold = table.Column<bool>(type: "bit", nullable: false),
                    ArchivedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinishedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsOnTrip = table.Column<bool>(type: "bit", nullable: false),
                    IsOnRetailerDelivery = table.Column<bool>(type: "bit", nullable: false),
                    PackageForProductDestruction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => new { x.Id, x.FacilityLicense });
                    table.UniqueConstraint("AK_Package_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Package_Facility_FacilityLicense",
                        column: x => x.FacilityLicense,
                        principalTable: "Facility",
                        principalColumn: "LicenseNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Package_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LabTestResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabTestResultId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    SourcePackageLabel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompoundName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompoundType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestBatchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestResultLevel = table.Column<double>(type: "float", nullable: false),
                    ReportUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestPassed = table.Column<bool>(type: "bit", nullable: false),
                    TestComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestPerformedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OverallPassed = table.Column<bool>(type: "bit", nullable: false),
                    LabFacilityLicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LabFacilityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestInformationalOnly = table.Column<bool>(type: "bit", nullable: false),
                    ResultReleased = table.Column<bool>(type: "bit", nullable: false),
                    ResultReleaseDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpirationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LabTestDetailRevokedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LabTestTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTestResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabTestResult_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Harvest_FacilityLicense",
                table: "Harvest",
                column: "FacilityLicense");

            migrationBuilder.CreateIndex(
                name: "IX_Item_FacilityLicense",
                table: "Item",
                column: "FacilityLicense");

            migrationBuilder.CreateIndex(
                name: "IX_LabTestResult_LabTestResultId",
                table: "LabTestResult",
                column: "LabTestResultId");

            migrationBuilder.CreateIndex(
                name: "IX_LabTestResult_PackageId",
                table: "LabTestResult",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_LabTestType_FacilityLicense",
                table: "LabTestType",
                column: "FacilityLicense");

            migrationBuilder.CreateIndex(
                name: "IX_Package_FacilityLicense",
                table: "Package",
                column: "FacilityLicense");

            migrationBuilder.CreateIndex(
                name: "IX_Package_ItemId",
                table: "Package",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Strain_FacilityLicense",
                table: "Strain",
                column: "FacilityLicense");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Harvest");

            migrationBuilder.DropTable(
                name: "LabTestResult");

            migrationBuilder.DropTable(
                name: "LabTestType");

            migrationBuilder.DropTable(
                name: "Strain");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Facility");
        }
    }
}
