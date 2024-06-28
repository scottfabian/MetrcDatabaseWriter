--Create database
IF NOT EXISTS (
    SELECT name FROM sys.databases WHERE name = 'MetrcData'
)
BEGIN
	CREATE DATABASE MetrcData
END

--Create tables
USE MetrcData

GO
/****** Object:  Table [dbo].[Facility] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facility](
	[FacilityId] [int] IDENTITY(1,1) NOT NULL,
	[HireDate] [nvarchar](max) NOT NULL,
	[IsOwner] [bit] NOT NULL,
	[IsManager] [bit] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Alias] [nvarchar](max) NULL,
	[DisplayName] [nvarchar](max) NOT NULL,
	[CredentialedDate] [datetime2](7) NULL,
	[SupportActivationDate] [datetime2](7) NULL,
	[SupportExpirationDate] [datetime2](7) NULL,
	[SupportLastPaidDate] [datetime2](7) NULL,
	[FacilityTypeId] [int] NOT NULL,
	[LicenseNumber] [nvarchar](450) NULL,
 CONSTRAINT [PK_Facility] PRIMARY KEY CLUSTERED 
(
	[FacilityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacilityType] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacilityType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsMedical] [bit] NOT NULL,
	[IsRetail] [bit] NOT NULL,
	[IsHemp] [bit] NOT NULL,
	[RestrictHarvestPlantRestoreTimeHours] [int] NULL,
	[TotalMemberPatientsAllowed] [int] NULL,
	[RestrictWholesalePriceEditDays] [int] NULL,
	[RestrictPlantBatchAdjustmentTimeHours] [int] NULL,
	[CanGrowPlants] [bit] NOT NULL,
	[CanCreateOpeningBalancePlantBatches] [bit] NOT NULL,
	[CanClonePlantBatches] [bit] NOT NULL,
	[CanTagPlantBatches] [bit] NOT NULL,
	[CanAssignLocationsToPlantBatches] [bit] NOT NULL,
	[PlantsRequirePatientAffiliation] [bit] NOT NULL,
	[PlantBatchesCanContainMotherPlants] [bit] NOT NULL,
	[CanUpdatePlantStrains] [bit] NOT NULL,
	[CanTrackVegetativePlants] [bit] NOT NULL,
	[CanCreateImmaturePlantPackagesFromPlants] [bit] NOT NULL,
	[CanPackageVegetativePlants] [bit] NOT NULL,
	[CanPackageWaste] [bit] NOT NULL,
	[CanReportHarvestSchedules] [bit] NOT NULL,
	[CanSubmitHarvestsForTesting] [bit] NOT NULL,
	[CanRequireHarvestSampleLabTestBatches] [bit] NOT NULL,
	[CanReportStrainProperties] [bit] NOT NULL,
	[CanCreateOpeningBalancePackages] [bit] NOT NULL,
	[CanCreateDerivedPackages] [bit] NOT NULL,
	[CanAssignLocationsToPackages] [bit] NOT NULL,
	[CanUpdateLocationsOnPackages] [bit] NOT NULL,
	[PackagesRequirePatientAffiliation] [bit] NOT NULL,
	[CanCreateTradeSamplePackages] [bit] NOT NULL,
	[CanDonatePackages] [bit] NOT NULL,
	[CanSubmitPackagesForTesting] [bit] NOT NULL,
	[CanCreateProcessValidationPackages] [bit] NOT NULL,
	[CanRequirePackageSampleLabTestBatches] [bit] NOT NULL,
	[CanRequestProductRemediation] [bit] NOT NULL,
	[CanRemediatePackagesWithFailedLabResults] [bit] NOT NULL,
	[CanInfuseProducts] [bit] NOT NULL,
	[CanRecordProcessingJobs] [bit] NOT NULL,
	[CanRecordProductForDestruction] [bit] NOT NULL,
	[CanDestroyProduct] [bit] NOT NULL,
	[CanTestPackages] [bit] NOT NULL,
	[TestsRequireLabSample] [bit] NOT NULL,
	[CanTransferFromExternalFacilities] [bit] NOT NULL,
	[CanSellToConsumers] [bit] NOT NULL,
	[CanSellToPatients] [bit] NOT NULL,
	[CanSellToExternalPatients] [bit] NOT NULL,
	[CanSellToCaregivers] [bit] NOT NULL,
	[CanTakePlantBatchesOnTrip] [bit] NOT NULL,
	[CanTakePlantsOnTrip] [bit] NOT NULL,
	[CanTakeHarvestsOnTrip] [bit] NOT NULL,
	[CanTakePackagesOnTrip] [bit] NOT NULL,
	[CanSellFromPackagesOnTrip] [bit] NOT NULL,
	[AdvancedSales] [bit] NOT NULL,
	[SalesRequirePatientNumber] [bit] NOT NULL,
	[SalesRequireExternalPatientNumber] [bit] NOT NULL,
	[SalesRequireExternalPatientIdentificationMethod] [bit] NOT NULL,
	[SalesRequireCaregiverNumber] [bit] NOT NULL,
	[SalesRequireCaregiverPatientNumber] [bit] NOT NULL,
	[CanDeliverSalesToConsumers] [bit] NOT NULL,
	[SalesDeliveryAllowPlannedRoute] [bit] NOT NULL,
	[SalesDeliveryAllowAddress] [bit] NOT NULL,
	[SalesDeliveryAllowCity] [bit] NOT NULL,
	[SalesDeliveryAllowState] [bit] NOT NULL,
	[SalesDeliveryAllowCounty] [bit] NOT NULL,
	[SalesDeliveryAllowZip] [bit] NOT NULL,
	[SalesDeliveryRequireConsumerId] [bit] NOT NULL,
	[CanDeliverSalesToPatients] [bit] NOT NULL,
	[SalesDeliveryRequirePatientNumber] [bit] NOT NULL,
	[SalesDeliveryRequireRecipientName] [bit] NOT NULL,
	[IsSalesDeliveryHub] [bit] NOT NULL,
	[CanHaveMemberPatients] [bit] NOT NULL,
	[CanReportPatientCheckIns] [bit] NOT NULL,
	[CanSpecifyPatientSalesLimitExemption] [bit] NOT NULL,
	[CanReportPatientsAdverseResponses] [bit] NOT NULL,
	[RetailerDelivery] [bit] NOT NULL,
	[RetailerDeliveryAllowTradeSamples] [bit] NOT NULL,
	[RetailerDeliveryAllowDonations] [bit] NOT NULL,
	[RetailerDeliveryRequirePrice] [bit] NOT NULL,
	[RetailerDeliveryAllowPartialPackages] [bit] NOT NULL,
	[CanCreatePartialPackages] [bit] NOT NULL,
	[CanAdjustSourcePackagesWithPartials] [bit] NOT NULL,
	[CanReportOperationalExceptions] [bit] NOT NULL,
	[CanReportAdulteration] [bit] NOT NULL,
	[CanGenerateProductLabel] [bit] NOT NULL,
	[CanPrintProductLabel] [bit] NOT NULL,
	[CanReceiveAssociateProductLabel] [bit] NOT NULL,
 CONSTRAINT [PK_FacilityType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Harvest] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Harvest](
	[Id] [int] NOT NULL,
	[FacilityId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[HarvestType] [nvarchar](max) NOT NULL,
	[SourceStrainCount] [int] NOT NULL,
	[SourceStrainNames] [nvarchar](max) NULL,
	[DryingLocationId] [int] NOT NULL,
	[DryingLocationName] [nvarchar](max) NOT NULL,
	[DryingLocationTypeName] [nvarchar](max) NULL,
	[PatientLicenseNumber] [nvarchar](max) NULL,
	[CurrentWeight] [float] NOT NULL,
	[TotalWasteWeight] [float] NOT NULL,
	[PlantCount] [int] NOT NULL,
	[TotalWetWeight] [float] NOT NULL,
	[TotalRestoredWeight] [float] NOT NULL,
	[PackageCount] [int] NOT NULL,
	[TotalPackagedWeight] [float] NOT NULL,
	[UnitOfWeightName] [nvarchar](max) NOT NULL,
	[LabTestingState] [nvarchar](max) NULL,
	[LabTestingStateDate] [datetime2](7) NULL,
	[IsOnHold] [bit] NOT NULL,
	[HarvestStartDate] [datetime2](7) NULL,
	[FinishedDate] [datetime2](7) NULL,
	[ArchivedDate] [datetime2](7) NULL,
	[IsOnTrip] [bit] NOT NULL,
	[LastModified] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Harvest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[FacilityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[Id] [int] NOT NULL,
	[FacilityId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ProductCategoryName] [nvarchar](max) NULL,
	[ProductCategoryType] [nvarchar](max) NULL,
	[IsExpirationDateRequired] [bit] NOT NULL,
	[HasExpirationDate] [bit] NOT NULL,
	[IsSellByDateRequired] [bit] NOT NULL,
	[HasSellByDate] [bit] NOT NULL,
	[IsUseByDateRequired] [bit] NOT NULL,
	[HasUseByDate] [bit] NOT NULL,
	[QuantityType] [nvarchar](max) NULL,
	[DefaultLabTestingState] [nvarchar](max) NULL,
	[UnitOfMeasureName] [nvarchar](max) NULL,
	[ApprovalStatus] [nvarchar](max) NULL,
	[ApprovalStatusDateTime] [datetime2](7) NOT NULL,
	[StrainId] [int] NULL,
	[StrainName] [nvarchar](max) NULL,
	[ItemBrandId] [int] NULL,
	[ItemBrandName] [nvarchar](max) NULL,
	[AdministrationMethod] [nvarchar](max) NULL,
	[UnitCbdPercent] [nvarchar](max) NULL,
	[UnitCbdContent] [nvarchar](max) NULL,
	[UnitCbdContentUnitOfMeasureName] [nvarchar](max) NULL,
	[UnitCbdContentDose] [nvarchar](max) NULL,
	[UnitCbdContentDoseUnitOfMeasureName] [nvarchar](max) NULL,
	[UnitThcPercent] [nvarchar](max) NULL,
	[UnitThcContent] [nvarchar](max) NULL,
	[UnitThcContentUnitOfMeasureName] [nvarchar](max) NULL,
	[UnitThcContentDose] [nvarchar](max) NULL,
	[UnitThcContentDoseUnitOfMeasureName] [nvarchar](max) NULL,
	[UnitVolume] [nvarchar](max) NULL,
	[UnitVolumeUnitOfMeasureName] [nvarchar](max) NULL,
	[UnitWeight] [nvarchar](max) NULL,
	[UnitWeightUnitOfMeasureName] [nvarchar](max) NULL,
	[ServingSize] [nvarchar](max) NULL,
	[SupplyDurationDays] [nvarchar](max) NULL,
	[NumberOfDoses] [nvarchar](max) NULL,
	[UnitQuantity] [nvarchar](max) NULL,
	[UnitQuantityUnitOfMeasureName] [nvarchar](max) NULL,
	[PublicIngredients] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Allergens] [nvarchar](max) NULL,
	[ProductImages] [nvarchar](max) NULL,
	[ProductPhotoDescription] [nvarchar](max) NULL,
	[LabelImages] [nvarchar](max) NULL,
	[LabelPhotoDescription] [nvarchar](max) NULL,
	[PackagingImages] [nvarchar](max) NULL,
	[PackagingPhotoDescription] [nvarchar](max) NULL,
	[ProductPDFDocuments] [nvarchar](max) NULL,
	[IsUsed] [bit] NOT NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[FacilityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LabTestResult] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LabTestResult](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LabTestResultId] [int] NOT NULL,
	[PackageId] [int] NOT NULL,
	[SourcePackageLabel] [nvarchar](max) NOT NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[ProductCategoryName] [nvarchar](max) NOT NULL,
	[CompoundName] [nvarchar](max) NOT NULL,
	[CompoundType] [nvarchar](max) NOT NULL,
	[TestBatchName] [nvarchar](max) NULL,
	[TestResultLevel] [float] NOT NULL,
	[ReportUnit] [nvarchar](max) NOT NULL,
	[TestTypeName] [nvarchar](max) NOT NULL,
	[TestPassed] [bit] NOT NULL,
	[TestComment] [nvarchar](max) NOT NULL,
	[TestPerformedDate] [nvarchar](max) NOT NULL,
	[OverallPassed] [bit] NOT NULL,
	[LabFacilityLicenseNumber] [nvarchar](max) NOT NULL,
	[LabFacilityName] [nvarchar](max) NOT NULL,
	[TestInformationalOnly] [bit] NOT NULL,
	[ResultReleased] [bit] NOT NULL,
	[ResultReleaseDateTime] [datetime2](7) NULL,
	[ExpirationDateTime] [datetime2](7) NULL,
	[RevokedDate] [datetime2](7) NULL,
	[LabTestDetailRevokedDate] [datetime2](7) NULL,
	[LabTestTypeId] [int] NOT NULL,
	[LabTestTypeFacilityId] [int] NOT NULL,
	[FacilityId] [int] NOT NULL,
	[PackageFacilityId] [int] NOT NULL,
 CONSTRAINT [PK_LabTestResult] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LabTestType] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LabTestType](
	[Id] [int] NOT NULL,
	[FacilityId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[RequiresTestResult] [bit] NOT NULL,
	[InformationalOnly] [bit] NOT NULL,
	[AlwaysPasses] [bit] NOT NULL,
	[MaxAllowedFailureCount] [int] NOT NULL,
	[LabTestResultMode] [nvarchar](max) NOT NULL,
	[LabTestResultMinimum] [float] NOT NULL,
	[LabTestResultMaximum] [float] NOT NULL,
	[LabTestResultExpirationDays] [int] NULL,
	[DependencyMode] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_LabTestType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[FacilityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[License] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[License](
	[Number] [nvarchar](450) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [datetime2](7) NULL,
	[EndDate] [datetime2](7) NULL,
	[LicenseType] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_License] PRIMARY KEY CLUSTERED 
(
	[Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Package] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Package](
	[Id] [int] NOT NULL,
	[FacilityId] [int] NOT NULL,
	[Label] [nvarchar](max) NULL,
	[PackageType] [nvarchar](max) NULL,
	[SourceHarvestCount] [int] NOT NULL,
	[SourcePackageCount] [int] NOT NULL,
	[SourceProcessingJobCount] [int] NOT NULL,
	[SourceHarvestNames] [nvarchar](max) NULL,
	[SourcePackageLabels] [nvarchar](max) NULL,
	[LocationId] [int] NOT NULL,
	[LocationName] [nvarchar](max) NULL,
	[LocationTypeName] [nvarchar](max) NULL,
	[Quantity] [float] NOT NULL,
	[UnitOfMeasureName] [nvarchar](max) NULL,
	[UnitOfMeasureAbbreviation] [nvarchar](max) NULL,
	[PatientLicenseNumber] [nvarchar](max) NULL,
	[ItemFromFacilityLicenseNumber] [nvarchar](max) NULL,
	[ItemFromFacilityName] [nvarchar](max) NULL,
	[Note] [nvarchar](max) NULL,
	[PackagedDate] [nvarchar](max) NULL,
	[ExpirationDate] [datetime2](7) NULL,
	[SellByDate] [datetime2](7) NULL,
	[UseByDate] [datetime2](7) NULL,
	[InitialLabTestingState] [nvarchar](max) NULL,
	[LabTestingState] [nvarchar](max) NULL,
	[LabTestingStateDate] [nvarchar](max) NULL,
	[LabTestResultExpirationDateTime] [datetime2](7) NULL,
	[LabTestingRecordedDate] [datetime2](7) NULL,
	[IsProductionBatch] [bit] NOT NULL,
	[ProductionBatchNumber] [nvarchar](max) NULL,
	[SourceProductionBatchNumbers] [nvarchar](max) NULL,
	[IsTradeSample] [bit] NOT NULL,
	[IsTradeSamplePersistent] [bit] NOT NULL,
	[SourcePackageIsTradeSample] [bit] NOT NULL,
	[IsDonation] [bit] NOT NULL,
	[IsDonationPersistent] [bit] NOT NULL,
	[SourcePackageIsDonation] [bit] NOT NULL,
	[IsTestingSample] [bit] NOT NULL,
	[IsProcessValidationTestingSample] [bit] NOT NULL,
	[ProductRequiresRemediation] [bit] NOT NULL,
	[ContainsRemediatedProduct] [bit] NOT NULL,
	[RemediationDate] [datetime2](7) NULL,
	[ReceivedDateTime] [datetime2](7) NULL,
	[ReceivedFromManifestNumber] [nvarchar](max) NULL,
	[ReceivedFromFacilityLicenseNumber] [nvarchar](max) NULL,
	[ReceivedFromFacilityName] [nvarchar](max) NULL,
	[IsOnHold] [bit] NOT NULL,
	[ArchivedDate] [datetime2](7) NULL,
	[FinishedDate] [datetime2](7) NULL,
	[IsOnTrip] [bit] NOT NULL,
	[IsOnRetailerDelivery] [bit] NOT NULL,
	[PackageForProductDestruction] [nvarchar](max) NULL,
	[LastModified] [datetime2](7) NOT NULL,
	[ItemId] [int] NULL,
	[ItemFacilityId] [int] NULL,
 CONSTRAINT [PK_Package] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[FacilityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Strain] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Strain](
	[Id] [int] NOT NULL,
	[FacilityId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[TestingStatus] [nvarchar](max) NOT NULL,
	[ThcLevel] [float] NULL,
	[CbdLevel] [float] NULL,
	[IndicaPercentage] [float] NOT NULL,
	[SativaPercentage] [float] NOT NULL,
	[IsUsed] [bit] NOT NULL,
	[Genetics] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Strain] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[FacilityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Facility]  WITH CHECK ADD  CONSTRAINT [FK_Facility_FacilityType_FacilityTypeId] FOREIGN KEY([FacilityTypeId])
REFERENCES [dbo].[FacilityType] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Facility] CHECK CONSTRAINT [FK_Facility_FacilityType_FacilityTypeId]
GO
ALTER TABLE [dbo].[Facility]  WITH CHECK ADD  CONSTRAINT [FK_Facility_License_LicenseNumber] FOREIGN KEY([LicenseNumber])
REFERENCES [dbo].[License] ([Number])
GO
ALTER TABLE [dbo].[Facility] CHECK CONSTRAINT [FK_Facility_License_LicenseNumber]
GO
ALTER TABLE [dbo].[Harvest]  WITH CHECK ADD  CONSTRAINT [FK_Harvest_Facility_FacilityId] FOREIGN KEY([FacilityId])
REFERENCES [dbo].[Facility] ([FacilityId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Harvest] CHECK CONSTRAINT [FK_Harvest_Facility_FacilityId]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Facility_FacilityId] FOREIGN KEY([FacilityId])
REFERENCES [dbo].[Facility] ([FacilityId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_Facility_FacilityId]
GO
ALTER TABLE [dbo].[LabTestResult]  WITH CHECK ADD  CONSTRAINT [FK_LabTestResult_Facility_FacilityId] FOREIGN KEY([FacilityId])
REFERENCES [dbo].[Facility] ([FacilityId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LabTestResult] CHECK CONSTRAINT [FK_LabTestResult_Facility_FacilityId]
GO
ALTER TABLE [dbo].[LabTestResult]  WITH CHECK ADD  CONSTRAINT [FK_LabTestResult_LabTestType_LabTestTypeId_LabTestTypeFacilityId] FOREIGN KEY([LabTestTypeId], [LabTestTypeFacilityId])
REFERENCES [dbo].[LabTestType] ([Id], [FacilityId])
GO
ALTER TABLE [dbo].[LabTestResult] CHECK CONSTRAINT [FK_LabTestResult_LabTestType_LabTestTypeId_LabTestTypeFacilityId]
GO
ALTER TABLE [dbo].[LabTestResult]  WITH CHECK ADD  CONSTRAINT [FK_LabTestResult_Package_PackageId_PackageFacilityId] FOREIGN KEY([PackageId], [PackageFacilityId])
REFERENCES [dbo].[Package] ([Id], [FacilityId])
GO
ALTER TABLE [dbo].[LabTestResult] CHECK CONSTRAINT [FK_LabTestResult_Package_PackageId_PackageFacilityId]
GO
ALTER TABLE [dbo].[LabTestType]  WITH CHECK ADD  CONSTRAINT [FK_LabTestType_Facility_FacilityId] FOREIGN KEY([FacilityId])
REFERENCES [dbo].[Facility] ([FacilityId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LabTestType] CHECK CONSTRAINT [FK_LabTestType_Facility_FacilityId]
GO
ALTER TABLE [dbo].[Package]  WITH CHECK ADD  CONSTRAINT [FK_Package_Facility_FacilityId] FOREIGN KEY([FacilityId])
REFERENCES [dbo].[Facility] ([FacilityId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Package] CHECK CONSTRAINT [FK_Package_Facility_FacilityId]
GO
ALTER TABLE [dbo].[Package]  WITH CHECK ADD  CONSTRAINT [FK_Package_Item_ItemId_ItemFacilityId] FOREIGN KEY([ItemId], [ItemFacilityId])
REFERENCES [dbo].[Item] ([Id], [FacilityId])
GO
ALTER TABLE [dbo].[Package] CHECK CONSTRAINT [FK_Package_Item_ItemId_ItemFacilityId]
GO
ALTER TABLE [dbo].[Strain]  WITH CHECK ADD  CONSTRAINT [FK_Strain_Facility_FacilityId] FOREIGN KEY([FacilityId])
REFERENCES [dbo].[Facility] ([FacilityId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Strain] CHECK CONSTRAINT [FK_Strain_Facility_FacilityId]
GO
