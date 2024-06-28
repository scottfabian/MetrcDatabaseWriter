using Microsoft.EntityFrameworkCore;

namespace MetrcDatabaseWriter;

[PrimaryKey(nameof(LicenseNumber))]
public class Facility
{
    //License Details
    public      string              LicenseNumber                                       { get; set; }
    public      DateTime?           StartDate                                           { get; set; }
    public      DateTime?           EndDate                                             { get; set; }
    public      string              LicenseType                                         { get; set; }
    //Facility Details
    public      string              HireDate                                            { get; set; }
    public      bool                IsOwner                                             { get; set; }
    public      bool                IsManager                                           { get; set; }
    public      string              Name                                                { get; set; }
    public      string?             Alias                                               { get; set; }
    public      string              DisplayName                                         { get; set; }
    public      DateTime?           CredentialedDate                                    { get; set; }
    public      DateTime?           SupportActivationDate                               { get; set; }
    public      DateTime?           SupportExpirationDate                               { get; set; }
    public      DateTime?           SupportLastPaidDate                                 { get; set; }
    //Facility Type Details
    public      bool                IsMedical                                           { get; set; }
    public      bool                IsRetail                                            { get; set; }
    public      bool                IsHemp                                              { get; set; }
    public      int?                RestrictHarvestPlantRestoreTimeHours                { get; set; }
    public      int?                TotalMemberPatientsAllowed                          { get; set; }
    public      int?                RestrictWholesalePriceEditDays                      { get; set; }
    public      int?                RestrictPlantBatchAdjustmentTimeHours               { get; set; }
    public      bool                CanGrowPlants                                       { get; set; }
    public      bool                CanCreateOpeningBalancePlantBatches                 { get; set; }
    public      bool                CanClonePlantBatches                                { get; set; }
    public      bool                CanTagPlantBatches                                  { get; set; }
    public      bool                CanAssignLocationsToPlantBatches                    { get; set; }
    public      bool                PlantsRequirePatientAffiliation                     { get; set; }
    public      bool                PlantBatchesCanContainMotherPlants                  { get; set; }
    public      bool                CanUpdatePlantStrains                               { get; set; }
    public      bool                CanTrackVegetativePlants                            { get; set; }
    public      bool                CanCreateImmaturePlantPackagesFromPlants            { get; set; }
    public      bool                CanPackageVegetativePlants                          { get; set; }
    public      bool                CanPackageWaste                                     { get; set; }
    public      bool                CanReportHarvestSchedules                           { get; set; }
    public      bool                CanSubmitHarvestsForTesting                         { get; set; }
    public      bool                CanRequireHarvestSampleLabTestBatches               { get; set; }
    public      bool                CanReportStrainProperties                           { get; set; }
    public      bool                CanCreateOpeningBalancePackages                     { get; set; }
    public      bool                CanCreateDerivedPackages                            { get; set; }
    public      bool                CanAssignLocationsToPackages                        { get; set; }
    public      bool                CanUpdateLocationsOnPackages                        { get; set; }
    public      bool                PackagesRequirePatientAffiliation                   { get; set; }
    public      bool                CanCreateTradeSamplePackages                        { get; set; }
    public      bool                CanDonatePackages                                   { get; set; }
    public      bool                CanSubmitPackagesForTesting                         { get; set; }
    public      bool                CanCreateProcessValidationPackages                  { get; set; }
    public      bool                CanRequirePackageSampleLabTestBatches               { get; set; }
    public      bool                CanRequestProductRemediation                        { get; set; }
    public      bool                CanRemediatePackagesWithFailedLabResults            { get; set; }
    public      bool                CanInfuseProducts                                   { get; set; }
    public      bool                CanRecordProcessingJobs                             { get; set; }
    public      bool                CanRecordProductForDestruction                      { get; set; }
    public      bool                CanDestroyProduct                                   { get; set; }
    public      bool                CanTestPackages                                     { get; set; }
    public      bool                TestsRequireLabSample                               { get; set; }
    public      bool                CanTransferFromExternalFacilities                   { get; set; }
    public      bool                CanSellToConsumers                                  { get; set; }
    public      bool                CanSellToPatients                                   { get; set; }
    public      bool                CanSellToExternalPatients                           { get; set; }
    public      bool                CanSellToCaregivers                                 { get; set; }
    public      bool                CanTakePlantBatchesOnTrip                           { get; set; }
    public      bool                CanTakePlantsOnTrip                                 { get; set; }
    public      bool                CanTakeHarvestsOnTrip                               { get; set; }
    public      bool                CanTakePackagesOnTrip                               { get; set; }
    public      bool                CanSellFromPackagesOnTrip                           { get; set; }
    public      bool                AdvancedSales                                       { get; set; }
    public      bool                SalesRequirePatientNumber                           { get; set; }
    public      bool                SalesRequireExternalPatientNumber                   { get; set; }
    public      bool                SalesRequireExternalPatientIdentificationMethod     { get; set; }
    public      bool                SalesRequireCaregiverNumber                         { get; set; }
    public      bool                SalesRequireCaregiverPatientNumber                  { get; set; }
    public      bool                CanDeliverSalesToConsumers                          { get; set; }
    public      bool                SalesDeliveryAllowPlannedRoute                      { get; set; }
    public      bool                SalesDeliveryAllowAddress                           { get; set; }
    public      bool                SalesDeliveryAllowCity                              { get; set; }
    public      bool                SalesDeliveryAllowState                             { get; set; }
    public      bool                SalesDeliveryAllowCounty                            { get; set; }
    public      bool                SalesDeliveryAllowZip                               { get; set; }
    public      bool                SalesDeliveryRequireConsumerId                      { get; set; }
    public      bool                CanDeliverSalesToPatients                           { get; set; }
    public      bool                SalesDeliveryRequirePatientNumber                   { get; set; }
    public      bool                SalesDeliveryRequireRecipientName                   { get; set; }
    public      bool                IsSalesDeliveryHub                                  { get; set; }
    public      bool                CanHaveMemberPatients                               { get; set; }
    public      bool                CanReportPatientCheckIns                            { get; set; }
    public      bool                CanSpecifyPatientSalesLimitExemption                { get; set; }
    public      bool                CanReportPatientsAdverseResponses                   { get; set; }
    public      bool                RetailerDelivery                                    { get; set; }
    public      bool                RetailerDeliveryAllowTradeSamples                   { get; set; }
    public      bool                RetailerDeliveryAllowDonations                      { get; set; }
    public      bool                RetailerDeliveryRequirePrice                        { get; set; }
    public      bool                RetailerDeliveryAllowPartialPackages                { get; set; }
    public      bool                CanCreatePartialPackages                            { get; set; }
    public      bool                CanAdjustSourcePackagesWithPartials                 { get; set; }
    public      bool                CanReportOperationalExceptions                      { get; set; }
    public      bool                CanReportAdulteration                               { get; set; }
    public      bool                CanGenerateProductLabel                             { get; set; }
    public      bool                CanPrintProductLabel                                { get; set; }
    public      bool                CanReceiveAssociateProductLabel                     { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is null || !(obj is Facility other))
            return false;

        return Equals(LicenseNumber, other.LicenseNumber)
            && StartDate.Equals(other.StartDate)
            && EndDate.Equals(other.EndDate)
            && Equals(LicenseType, other.LicenseType)
            && HireDate.Equals(other.HireDate)
            && IsOwner == other.IsOwner
            && IsManager == other.IsManager
            && Equals(Name, other.Name)
            && Equals(Alias, other.Alias)
            && Equals(DisplayName, other.DisplayName)
            && CredentialedDate.Equals(other.CredentialedDate)
            && SupportActivationDate.Equals(other.SupportActivationDate)
            && SupportExpirationDate.Equals(other.SupportExpirationDate)
            && SupportLastPaidDate.Equals(other.SupportLastPaidDate)
            && IsMedical == other.IsMedical
            && IsRetail == other.IsRetail
            && IsHemp == other.IsHemp
            && RestrictHarvestPlantRestoreTimeHours == other.RestrictHarvestPlantRestoreTimeHours
            && TotalMemberPatientsAllowed == other.TotalMemberPatientsAllowed
            && RestrictWholesalePriceEditDays == other.RestrictWholesalePriceEditDays
            && RestrictPlantBatchAdjustmentTimeHours == other.RestrictPlantBatchAdjustmentTimeHours
            && CanGrowPlants == other.CanGrowPlants
            && CanCreateOpeningBalancePlantBatches == other.CanCreateOpeningBalancePlantBatches
            && CanClonePlantBatches == other.CanClonePlantBatches
            && CanTagPlantBatches == other.CanTagPlantBatches
            && PlantsRequirePatientAffiliation == other.PlantsRequirePatientAffiliation
            && PlantBatchesCanContainMotherPlants == other.PlantBatchesCanContainMotherPlants
            && CanUpdatePlantStrains == other.CanUpdatePlantStrains
            && CanTrackVegetativePlants == other.CanTrackVegetativePlants
            && CanCreateImmaturePlantPackagesFromPlants == other.CanCreateImmaturePlantPackagesFromPlants
            && CanPackageVegetativePlants == other.CanPackageVegetativePlants
            && CanPackageWaste == other.CanPackageWaste
            && CanReportHarvestSchedules == other.CanReportHarvestSchedules
            && CanSubmitHarvestsForTesting == other.CanSubmitHarvestsForTesting
            && CanRequireHarvestSampleLabTestBatches == other.CanRequireHarvestSampleLabTestBatches
            && CanReportStrainProperties == other.CanReportStrainProperties
            && CanCreateOpeningBalancePackages == other.CanCreateOpeningBalancePackages
            && CanCreateDerivedPackages == other.CanCreateDerivedPackages
            && CanAssignLocationsToPackages == other.CanAssignLocationsToPackages
            && CanUpdateLocationsOnPackages == other.CanUpdateLocationsOnPackages
            && PackagesRequirePatientAffiliation == other.PackagesRequirePatientAffiliation
            && CanCreateTradeSamplePackages == other.CanCreateTradeSamplePackages
            && CanDonatePackages == other.CanDonatePackages
            && CanSubmitPackagesForTesting == other.CanSubmitPackagesForTesting;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + (LicenseNumber?.GetHashCode() ?? 0);
            hash = hash * 23 + StartDate.GetHashCode();
            hash = hash * 23 + EndDate.GetHashCode();
            hash = hash * 23 + (LicenseType?.GetHashCode() ?? 0);
            hash = hash * 23 + HireDate.GetHashCode();
            hash = hash * 23 + IsOwner.GetHashCode();
            hash = hash * 23 + IsManager.GetHashCode();
            hash = hash * 23 + (Name?.GetHashCode() ?? 0);
            hash = hash * 23 + (Alias?.GetHashCode() ?? 0);
            hash = hash * 23 + (DisplayName?.GetHashCode() ?? 0);
            hash = hash * 23 + CredentialedDate.GetHashCode();
            hash = hash * 23 + SupportActivationDate.GetHashCode();
            hash = hash * 23 + SupportExpirationDate.GetHashCode();
            hash = hash * 23 + SupportLastPaidDate.GetHashCode();
            hash = hash * 23 + IsMedical.GetHashCode();
            hash = hash * 23 + IsRetail.GetHashCode();
            hash = hash * 23 + IsHemp.GetHashCode();
            hash = hash * 23 + RestrictHarvestPlantRestoreTimeHours.GetHashCode();
            hash = hash * 23 + TotalMemberPatientsAllowed.GetHashCode();
            hash = hash * 23 + RestrictWholesalePriceEditDays.GetHashCode();
            hash = hash * 23 + RestrictPlantBatchAdjustmentTimeHours.GetHashCode();
            hash = hash * 23 + CanGrowPlants.GetHashCode();
            hash = hash * 23 + CanCreateOpeningBalancePlantBatches.GetHashCode();
            hash = hash * 23 + CanClonePlantBatches.GetHashCode();
            hash = hash * 23 + CanTagPlantBatches.GetHashCode();
            hash = hash * 23 + PlantsRequirePatientAffiliation.GetHashCode();
            hash = hash * 23 + PlantBatchesCanContainMotherPlants.GetHashCode();
            hash = hash * 23 + CanUpdatePlantStrains.GetHashCode();
            hash = hash * 23 + CanTrackVegetativePlants.GetHashCode();
            hash = hash * 23 + CanCreateImmaturePlantPackagesFromPlants.GetHashCode();
            hash = hash * 23 + CanPackageVegetativePlants.GetHashCode();
            hash = hash * 23 + CanPackageWaste.GetHashCode();
            hash = hash * 23 + CanReportHarvestSchedules.GetHashCode();
            hash = hash * 23 + CanSubmitHarvestsForTesting.GetHashCode();
            hash = hash * 23 + CanRequireHarvestSampleLabTestBatches.GetHashCode();
            hash = hash * 23 + CanReportStrainProperties.GetHashCode();
            hash = hash * 23 + CanCreateOpeningBalancePackages.GetHashCode();
            hash = hash * 23 + CanCreateDerivedPackages.GetHashCode();
            hash = hash * 23 + CanAssignLocationsToPackages.GetHashCode();
            hash = hash * 23 + CanUpdateLocationsOnPackages.GetHashCode();
            hash = hash * 23 + PackagesRequirePatientAffiliation.GetHashCode();
            hash = hash * 23 + CanCreateTradeSamplePackages.GetHashCode();
            hash = hash * 23 + CanDonatePackages.GetHashCode();
            hash = hash * 23 + CanSubmitPackagesForTesting.GetHashCode();

            return hash;
        }
    }

}
