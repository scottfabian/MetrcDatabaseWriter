using Microsoft.EntityFrameworkCore;

namespace MetrcDatabaseWriter;

[PrimaryKey(nameof(Id), nameof(FacilityLicense))]
public class Strain : IMetrcModel
{
    public      int              Id                      { get; set; }
    public      string           FacilityLicense         { get; set; }
    public      string           Name                    { get; set; }
    public      string           TestingStatus           { get; set; }
    public      double?          ThcLevel                { get; set; }
    public      double?          CbdLevel                { get; set; }
    public      double           IndicaPercentage        { get; set; }
    public      double           SativaPercentage        { get; set; }
    public      bool             IsUsed                  { get; set; }
    public      string           Genetics                { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null || !(obj is Strain other))
        {
            return false;
        }

        return Id.Equals(other.Id)
            && FacilityLicense.Equals(other.FacilityLicense)
            && Name.Equals(other.Name)
            && TestingStatus.Equals(other.TestingStatus)
            && ThcLevel.Equals(other.ThcLevel)
            && CbdLevel.Equals(other.CbdLevel)
            && IndicaPercentage.Equals(other.IndicaPercentage)
            && SativaPercentage.Equals(other.SativaPercentage)
            && IsUsed.Equals(other.IsUsed)
            && Genetics.Equals(other.Genetics);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + Id.GetHashCode();
            hash = hash * 23 + FacilityLicense.GetHashCode();
            hash = hash * 23 + Name.GetHashCode();
            hash = hash * 23 + TestingStatus.GetHashCode();
            hash = hash * 23 + ThcLevel?.GetHashCode() ?? 0;
            hash = hash * 23 + CbdLevel?.GetHashCode() ?? 0;
            hash = hash * 23 + IndicaPercentage.GetHashCode();
            hash = hash * 23 + SativaPercentage.GetHashCode();
            hash = hash * 23 + IsUsed.GetHashCode();
            hash = hash * 23 + Genetics.GetHashCode();
            return hash;
        }
    }

}
