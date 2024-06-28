using Microsoft.EntityFrameworkCore;

namespace MetrcDatabaseWriter;

[PrimaryKey(nameof(Id), nameof(FacilityLicense))]
public class Package : IMetrcModel
{
    public      int                  Id                                             { get; set; }
    public      string               FacilityLicense                                { get; set; }
    public      string?              Label                                          { get; set; }
    public      string?              PackageType                                    { get; set; }
    public      int                  SourceHarvestCount                             { get; set; }
    public      int                  SourcePackageCount                             { get; set; }
    public      int                  SourceProcessingJobCount                       { get; set; }
    public      string?              SourceHarvestNames                             { get; set; }
    public      string?              SourcePackageLabels                            { get; set; }
    public      int                  LocationId                                     { get; set; }
    public      string?              LocationName                                   { get; set; }
    public      string?              LocationTypeName                               { get; set; }
    public      double               Quantity                                       { get; set; }
    public      string?              UnitOfMeasureName                              { get; set; }
    public      string?              UnitOfMeasureAbbreviation                      { get; set; }
    public      string?              PatientLicenseNumber                           { get; set; }
    public      string?              ItemFromFacilityLicenseNumber                  { get; set; }
    public      string?              ItemFromFacilityName                           { get; set; }
    public      string?              Note                                           { get; set; }
    public      string?              PackagedDate                                   { get; set; }
    public      DateTime?            ExpirationDate                                 { get; set; }
    public      DateTime?            SellByDate                                     { get; set; }
    public      DateTime?            UseByDate                                      { get; set; }
    public      string?              InitialLabTestingState                         { get; set; }
    public      string?              LabTestingState                                { get; set; }
    public      string?              LabTestingStateDate                            { get; set; }
    public      DateTime?            LabTestResultExpirationDateTime                { get; set; }
    public      DateTime?            LabTestingRecordedDate                         { get; set; }
    public      bool                 IsProductionBatch                              { get; set; }
    public      string?              ProductionBatchNumber                          { get; set; }
    public      string?              SourceProductionBatchNumbers                   { get; set; }
    public      bool                 IsTradeSample                                  { get; set; }
    public      bool                 IsTradeSamplePersistent                        { get; set; }
    public      bool                 SourcePackageIsTradeSample                     { get; set; }
    public      bool                 IsDonation                                     { get; set; }
    public      bool                 IsDonationPersistent                           { get; set; }
    public      bool                 SourcePackageIsDonation                        { get; set; }
    public      bool                 IsTestingSample                                { get; set; }
    public      bool                 IsProcessValidationTestingSample               { get; set; }
    public      bool                 ProductRequiresRemediation                     { get; set; }
    public      bool                 ContainsRemediatedProduct                      { get; set; }
    public      DateTime?            RemediationDate                                { get; set; }
    public      DateTime?            ReceivedDateTime                               { get; set; }
    public      string?              ReceivedFromManifestNumber                     { get; set; }
    public      string?              ReceivedFromFacilityLicenseNumber              { get; set; }
    public      string?              ReceivedFromFacilityName                       { get; set; }
    public      bool                 IsOnHold                                       { get; set; }
    public      DateTime?            ArchivedDate                                   { get; set; }
    public      DateTime?            FinishedDate                                   { get; set; }
    public      bool                 IsOnTrip                                       { get; set; }
    public      bool                 IsOnRetailerDelivery                           { get; set; }
    public      string?              PackageForProductDestruction                   { get; set; }
    public      DateTime             LastModified                                   { get; set; }
    public      int?                 ItemId                                         { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null || !(obj is Package other))
        {
            return false;
        }

        return Id.Equals(other.Id)
            && FacilityLicense.Equals(other.FacilityLicense)
            && Equals(Label, other.Label)
            && Equals(PackageType, other.PackageType)
            && SourceHarvestCount.Equals(other.SourceHarvestCount)
            && SourcePackageCount.Equals(other.SourcePackageCount)
            && SourceProcessingJobCount.Equals(other.SourceProcessingJobCount)
            && Equals(SourceHarvestNames, other.SourceHarvestNames)
            && Equals(SourcePackageLabels, other.SourcePackageLabels)
            && LocationId.Equals(other.LocationId)
            && Equals(LocationName, other.LocationName)
            && Equals(LocationTypeName, other.LocationTypeName)
            && Quantity.Equals(other.Quantity)
            && Equals(UnitOfMeasureName, other.UnitOfMeasureName)
            && Equals(UnitOfMeasureAbbreviation, other.UnitOfMeasureAbbreviation)
            && Equals(PatientLicenseNumber, other.PatientLicenseNumber)
            && Equals(ItemFromFacilityLicenseNumber, other.ItemFromFacilityLicenseNumber)
            && Equals(ItemFromFacilityName, other.ItemFromFacilityName)
            && Equals(Note, other.Note)
            && Equals(PackagedDate, other.PackagedDate)
            && Equals(ExpirationDate, other.ExpirationDate)
            && Equals(SellByDate, other.SellByDate)
            && Equals(UseByDate, other.UseByDate)
            && Equals(InitialLabTestingState, other.InitialLabTestingState)
            && Equals(LabTestingState, other.LabTestingState)
            && Equals(LabTestingStateDate, other.LabTestingStateDate)
            && Equals(LabTestResultExpirationDateTime, other.LabTestResultExpirationDateTime)
            && Equals(LabTestingRecordedDate, other.LabTestingRecordedDate)
            && IsProductionBatch.Equals(other.IsProductionBatch)
            && Equals(ProductionBatchNumber, other.ProductionBatchNumber)
            && Equals(SourceProductionBatchNumbers, other.SourceProductionBatchNumbers)
            && IsTradeSample.Equals(other.IsTradeSample)
            && IsTradeSamplePersistent.Equals(other.IsTradeSamplePersistent)
            && SourcePackageIsTradeSample.Equals(other.SourcePackageIsTradeSample)
            && IsDonation.Equals(other.IsDonation)
            && IsDonationPersistent.Equals(other.IsDonationPersistent)
            && SourcePackageIsDonation.Equals(other.SourcePackageIsDonation)
            && IsTestingSample.Equals(other.IsTestingSample)
            && IsProcessValidationTestingSample.Equals(other.IsProcessValidationTestingSample)
            && ProductRequiresRemediation.Equals(other.ProductRequiresRemediation)
            && ContainsRemediatedProduct.Equals(other.ContainsRemediatedProduct)
            && Equals(RemediationDate, other.RemediationDate)
            && Equals(ReceivedDateTime, other.ReceivedDateTime)
            && Equals(ReceivedFromManifestNumber, other.ReceivedFromManifestNumber)
            && Equals(ReceivedFromFacilityLicenseNumber, other.ReceivedFromFacilityLicenseNumber)
            && Equals(ReceivedFromFacilityName, other.ReceivedFromFacilityName)
            && IsOnHold.Equals(other.IsOnHold)
            && Equals(ArchivedDate, other.ArchivedDate)
            && Equals(FinishedDate, other.FinishedDate)
            && IsOnTrip.Equals(other.IsOnTrip)
            && IsOnRetailerDelivery.Equals(other.IsOnRetailerDelivery)
            && Equals(PackageForProductDestruction, other.PackageForProductDestruction)
            && LastModified.Equals(other.LastModified)
            && Equals(ItemId, other.ItemId);
    }


    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + Id.GetHashCode();
            hash = hash * 23 + (FacilityLicense?.GetHashCode() ?? 0);
            hash = hash * 23 + (Label?.GetHashCode() ?? 0);
            hash = hash * 23 + (PackageType?.GetHashCode() ?? 0);
            hash = hash * 23 + SourceHarvestCount.GetHashCode();
            hash = hash * 23 + SourcePackageCount.GetHashCode();
            hash = hash * 23 + SourceProcessingJobCount.GetHashCode();
            hash = hash * 23 + (SourceHarvestNames?.GetHashCode() ?? 0);
            hash = hash * 23 + (SourcePackageLabels?.GetHashCode() ?? 0);
            hash = hash * 23 + LocationId.GetHashCode();
            hash = hash * 23 + (LocationName?.GetHashCode() ?? 0);
            hash = hash * 23 + (LocationTypeName?.GetHashCode() ?? 0);
            hash = hash * 23 + Quantity.GetHashCode();
            hash = hash * 23 + (UnitOfMeasureName?.GetHashCode() ?? 0);
            hash = hash * 23 + (UnitOfMeasureAbbreviation?.GetHashCode() ?? 0);
            hash = hash * 23 + (PatientLicenseNumber?.GetHashCode() ?? 0);
            hash = hash * 23 + (ItemFromFacilityLicenseNumber?.GetHashCode() ?? 0);
            hash = hash * 23 + (ItemFromFacilityName?.GetHashCode() ?? 0);
            hash = hash * 23 + (Note?.GetHashCode() ?? 0);
            hash = hash * 23 + (PackagedDate?.GetHashCode() ?? 0);
            hash = hash * 23 + (ExpirationDate?.GetHashCode() ?? 0);
            hash = hash * 23 + (SellByDate?.GetHashCode() ?? 0);
            hash = hash * 23 + (UseByDate?.GetHashCode() ?? 0);
            hash = hash * 23 + (InitialLabTestingState?.GetHashCode() ?? 0);
            hash = hash * 23 + (LabTestingState?.GetHashCode() ?? 0);
            hash = hash * 23 + (LabTestingStateDate?.GetHashCode() ?? 0);
            hash = hash * 23 + (LabTestResultExpirationDateTime?.GetHashCode() ?? 0);
            hash = hash * 23 + (LabTestingRecordedDate?.GetHashCode() ?? 0);
            hash = hash * 23 + IsProductionBatch.GetHashCode();
            hash = hash * 23 + (ProductionBatchNumber?.GetHashCode() ?? 0);
            hash = hash * 23 + (SourceProductionBatchNumbers?.GetHashCode() ?? 0);
            hash = hash * 23 + IsTradeSample.GetHashCode();
            hash = hash * 23 + IsTradeSamplePersistent.GetHashCode();
            hash = hash * 23 + SourcePackageIsTradeSample.GetHashCode();
            hash = hash * 23 + IsDonation.GetHashCode();
            hash = hash * 23 + IsDonationPersistent.GetHashCode();
            hash = hash * 23 + SourcePackageIsDonation.GetHashCode();
            hash = hash * 23 + IsTestingSample.GetHashCode();
            hash = hash * 23 + IsProcessValidationTestingSample.GetHashCode();
            hash = hash * 23 + ProductRequiresRemediation.GetHashCode();
            hash = hash * 23 + ContainsRemediatedProduct.GetHashCode();
            hash = hash * 23 + (RemediationDate?.GetHashCode() ?? 0);
            hash = hash * 23 + (ReceivedDateTime?.GetHashCode() ?? 0);
            hash = hash * 23 + (ReceivedFromManifestNumber?.GetHashCode() ?? 0);
            hash = hash * 23 + (ReceivedFromFacilityLicenseNumber?.GetHashCode() ?? 0);
            hash = hash * 23 + (ReceivedFromFacilityName?.GetHashCode() ?? 0);
            hash = hash * 23 + IsOnHold.GetHashCode();
            hash = hash * 23 + (ArchivedDate?.GetHashCode() ?? 0);
            hash = hash * 23 + (FinishedDate?.GetHashCode() ?? 0);
            hash = hash * 23 + IsOnTrip.GetHashCode();
            hash = hash * 23 + IsOnRetailerDelivery.GetHashCode();
            hash = hash * 23 + (PackageForProductDestruction?.GetHashCode() ?? 0);
            hash = hash * 23 + LastModified.GetHashCode();
            hash = hash * 23 + (ItemId?.GetHashCode() ?? 0);

            return hash;
        }
    }

}
