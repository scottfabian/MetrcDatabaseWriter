using Microsoft.EntityFrameworkCore;

namespace MetrcDatabaseWriter;

[PrimaryKey(nameof(Id), nameof(FacilityLicense))]
public class Harvest : IMetrcModel
{
    public      int              Id                          { get; set; }
    public      string           FacilityLicense             { get; set; }
    public      string           Name                        { get; set; }
    public      string           HarvestType                 { get; set; }
    public      int              SourceStrainCount           { get; set; }
    public      string?          SourceStrainNames           { get; set; }
    public      int              DryingLocationId            { get; set; }
    public      string           DryingLocationName          { get; set; }
    public      string?          DryingLocationTypeName      { get; set; }
    public      string?          PatientLicenseNumber        { get; set; }
    public      double           CurrentWeight               { get; set; }
    public      double           TotalWasteWeight            { get; set; }
    public      int              PlantCount                  { get; set; }
    public      double           TotalWetWeight              { get; set; }
    public      double           TotalRestoredWeight         { get; set; }
    public      int              PackageCount                { get; set; }
    public      double           TotalPackagedWeight         { get; set; }
    public      string           UnitOfWeightName            { get; set; }
    public      string?          LabTestingState             { get; set; }
    public      DateTime?        LabTestingStateDate         { get; set; }
    public      bool             IsOnHold                    { get; set; }
    public      DateTime?        HarvestStartDate            { get; set; }
    public      DateTime?        FinishedDate                { get; set; }
    public      DateTime?        ArchivedDate                { get; set; }
    public      bool             IsOnTrip                    { get; set; }
    public      DateTime         LastModified                { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is null || !(obj is Harvest other))
        {
            return false;
        }

        return Id.Equals(other.Id)
            && FacilityLicense.Equals(other.FacilityLicense)
            && Name.Equals(other.Name)
            && HarvestType.Equals(other.HarvestType)
            && SourceStrainCount.Equals(other.SourceStrainCount)
            && (SourceStrainNames == other.SourceStrainNames || (SourceStrainNames != null && SourceStrainNames.Equals(other.SourceStrainNames)))
            && DryingLocationId.Equals(other.DryingLocationId)
            && DryingLocationName.Equals(other.DryingLocationName)
            && (PatientLicenseNumber == other.PatientLicenseNumber || (PatientLicenseNumber != null && PatientLicenseNumber.Equals(other.PatientLicenseNumber)))
            && CurrentWeight.Equals(other.CurrentWeight)
            && TotalWasteWeight.Equals(other.TotalWasteWeight)
            && PlantCount.Equals(other.PlantCount)
            && TotalWetWeight.Equals(other.TotalWetWeight)
            && TotalRestoredWeight.Equals(other.TotalRestoredWeight)
            && PackageCount.Equals(other.PackageCount)
            && TotalPackagedWeight.Equals(other.TotalPackagedWeight)
            && UnitOfWeightName.Equals(other.UnitOfWeightName)
            && (LabTestingState == other.LabTestingState || (LabTestingState != null && LabTestingState.Equals(other.LabTestingState)))
            && LabTestingStateDate.Equals(other.LabTestingStateDate)
            && IsOnHold.Equals(other.IsOnHold)
            && HarvestStartDate.Equals(other.HarvestStartDate)
            && FinishedDate.Equals(other.FinishedDate)
            && ArchivedDate.Equals(other.ArchivedDate)
            && IsOnTrip.Equals(other.IsOnTrip)
            && LastModified.Equals(other.LastModified);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + Id.GetHashCode();
            hash = hash * 23 + FacilityLicense.GetHashCode();
            hash = hash * 23 + Name.GetHashCode();
            hash = hash * 23 + HarvestType.GetHashCode();
            hash = hash * 23 + SourceStrainCount.GetHashCode();
            hash = hash * 23 + (SourceStrainNames?.GetHashCode() ?? 0);
            hash = hash * 23 + DryingLocationId.GetHashCode();
            hash = hash * 23 + DryingLocationName.GetHashCode();
            hash = hash * 23 + (PatientLicenseNumber?.GetHashCode() ?? 0);
            hash = hash * 23 + CurrentWeight.GetHashCode();
            hash = hash * 23 + TotalWasteWeight.GetHashCode();
            hash = hash * 23 + PlantCount.GetHashCode();
            hash = hash * 23 + TotalWetWeight.GetHashCode();
            hash = hash * 23 + TotalRestoredWeight.GetHashCode();
            hash = hash * 23 + PackageCount.GetHashCode();
            hash = hash * 23 + TotalPackagedWeight.GetHashCode();
            hash = hash * 23 + UnitOfWeightName.GetHashCode();
            hash = hash * 23 + (LabTestingState?.GetHashCode() ?? 0);
            hash = hash * 23 + LabTestingStateDate.GetHashCode();
            hash = hash * 23 + IsOnHold.GetHashCode();
            hash = hash * 23 + HarvestStartDate.GetHashCode();
            hash = hash * 23 + FinishedDate.GetHashCode();
            hash = hash * 23 + ArchivedDate.GetHashCode();
            hash = hash * 23 + IsOnTrip.GetHashCode();
            hash = hash * 23 + LastModified.GetHashCode();
            return hash;
        }
    }

}
