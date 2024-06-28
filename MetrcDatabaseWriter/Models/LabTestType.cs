using Microsoft.EntityFrameworkCore;

namespace MetrcDatabaseWriter;

[PrimaryKey(nameof(Id), nameof(FacilityLicense))]
public class LabTestType : IMetrcModel
{
    public int              Id                              { get; set; }
    public string           FacilityLicense                 { get; set; }
    public string           Name                            { get; set; }
    public bool             RequiresTestResult              { get; set; }
    public bool             InformationalOnly               { get; set; }
    public bool             AlwaysPasses                    { get; set; }
    public int              MaxAllowedFailureCount          { get; set; }
    public string           LabTestResultMode               { get; set; }
    public double           LabTestResultMinimum            { get; set; }
    public double           LabTestResultMaximum            { get; set; }
    public int?             LabTestResultExpirationDays     { get; set; }
    public string           DependencyMode                  { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is null || !(obj is LabTestType other))
        {
            return false;
        }

        return Id.Equals(other.Id)
            && FacilityLicense.Equals(other.FacilityLicense)
            && Name.Equals(other.Name)
            && RequiresTestResult.Equals(other.RequiresTestResult)
            && InformationalOnly.Equals(other.InformationalOnly)
            && AlwaysPasses.Equals(other.AlwaysPasses)
            && MaxAllowedFailureCount.Equals(other.MaxAllowedFailureCount)
            && LabTestResultMode.Equals(other.LabTestResultMode)
            && LabTestResultMinimum.Equals(other.LabTestResultMinimum)
            && LabTestResultMaximum.Equals(other.LabTestResultMaximum)
            && LabTestResultExpirationDays.Equals(other.LabTestResultExpirationDays)
            && DependencyMode.Equals(other.DependencyMode);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + Id.GetHashCode();
            hash = hash * 23 + FacilityLicense.GetHashCode();
            hash = hash * 23 + Name.GetHashCode();
            hash = hash * 23 + RequiresTestResult.GetHashCode();
            hash = hash * 23 + InformationalOnly.GetHashCode();
            hash = hash * 23 + AlwaysPasses.GetHashCode();
            hash = hash * 23 + MaxAllowedFailureCount.GetHashCode();
            hash = hash * 23 + LabTestResultMode.GetHashCode();
            hash = hash * 23 + LabTestResultMinimum.GetHashCode();
            hash = hash * 23 + LabTestResultMaximum.GetHashCode();
            hash = hash * 23 + (LabTestResultExpirationDays?.GetHashCode() ?? 0);
            hash = hash * 23 + DependencyMode.GetHashCode();
            return hash;
        }
    }
}
