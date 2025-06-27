using Microsoft.EntityFrameworkCore;

namespace MetrcDatabaseWriter;

[PrimaryKey(nameof(Id))]
public class LabTestResult
{
    public      int                 Id                              { get; set; }   // NOT in Metrc, adding for database's sake
    public      int                 LabTestResultId                 { get; set; }
    public      int                 PackageId                       { get; set; }
    public      string              SourcePackageLabel              { get; set; }
    public      string              ProductName                     { get; set; }
    public      string              ProductCategoryName             { get; set; }
    public      string?             CompoundName                    { get; set; }   // derived from Metrc Data
    public      string?             CompoundType                    { get; set; }   // derived from Metrc data
    public      string?             TestBatchName                   { get; set; }   // derived from Metrc data
    public      double              TestResultLevel                 { get; set; }
    public      string?             ReportUnit                      { get; set; }   // derived from Metrc data
    public      string              TestTypeName                    { get; set; }
    public      bool                TestPassed                      { get; set; }
    public      string              TestComment                     { get; set; }
    public      string              TestPerformedDate               { get; set; }
    public      bool                OverallPassed                   { get; set; }
    public      string              LabFacilityLicenseNumber        { get; set; }
    public      string              LabFacilityName                 { get; set; }
    public      bool                TestInformationalOnly           { get; set; }
    public      bool                ResultReleased                  { get; set; }
    public      DateTime?           ResultReleaseDateTime           { get; set; }
    public      DateTime?           ExpirationDateTime              { get; set; }
    public      DateTime?           RevokedDate                     { get; set; }
    public      DateTime?           LabTestDetailRevokedDate        { get; set; }
    public      int                 LabTestTypeId                   { get; set; }   // Does not exist in Metrc, passing in
    

    public void SetCustomFields(LabTestType testType)
    {
        if (testType is null)
        {
            return;
        }
        this.ReportUnit = ExtractReportUnit(testType);
        this.CompoundName = ExtractCompoundName(testType);
    }

    private string ExtractCompoundName(LabTestType testType)
    {
        if (string.IsNullOrEmpty(TestTypeName))
        {
            return string.Empty;
        }

        int firstParenIndex = TestTypeName.IndexOf('(');

        if (firstParenIndex == -1)
        {
            return TestTypeName.Trim();
        }

        string compoundName = TestTypeName.Substring(0, firstParenIndex);

        return compoundName.Trim();
    }

    private string ExtractReportUnit(LabTestType testType)
    {
        if (string.IsNullOrEmpty(TestTypeName))
        {
            return string.Empty;
        }

        int startIndex = TestTypeName.IndexOf('(');
        int endIndex = TestTypeName.IndexOf(')');

        if (startIndex == -1 || endIndex == -1 || endIndex < startIndex)
        {
            return string.Empty;
        }

        return TestTypeName.Substring(startIndex + 1, endIndex - startIndex - 1);
    }


    public override bool Equals(object? obj)
    {
        if (obj is null || !(obj is LabTestResult other))
            return false;

        return LabTestResultId.Equals(other.LabTestResultId)
            && PackageId.Equals(other.PackageId)
            && Equals(SourcePackageLabel, other.SourcePackageLabel)
            && Equals(ProductName, other.ProductName)
            && Equals(ProductCategoryName, other.ProductCategoryName)
            && Equals(CompoundName, other.CompoundName)
            && Equals(CompoundType, other.CompoundType)
            && Equals(TestBatchName, other.TestBatchName)
            && TestResultLevel.Equals(other.TestResultLevel)
            && Equals(ReportUnit, other.ReportUnit)
            && Equals(TestTypeName, other.TestTypeName)
            && TestPassed == other.TestPassed
            && Equals(TestComment, other.TestComment)
            && Equals(TestPerformedDate, other.TestPerformedDate)
            && OverallPassed == other.OverallPassed
            && Equals(LabFacilityLicenseNumber, other.LabFacilityLicenseNumber)
            && Equals(LabFacilityName, other.LabFacilityName)
            && TestInformationalOnly == other.TestInformationalOnly
            && ResultReleased == other.ResultReleased
            && Equals(ResultReleaseDateTime, other.ResultReleaseDateTime)
            && Equals(ExpirationDateTime, other.ExpirationDateTime)
            && Equals(RevokedDate, other.RevokedDate)
            && Equals(LabTestDetailRevokedDate, other.LabTestDetailRevokedDate)
            && LabTestTypeId.Equals(other.LabTestTypeId);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + LabTestResultId.GetHashCode();
            hash = hash * 23 + PackageId.GetHashCode();
            hash = hash * 23 + (SourcePackageLabel?.GetHashCode() ?? 0);
            hash = hash * 23 + (ProductName?.GetHashCode() ?? 0);
            hash = hash * 23 + (ProductCategoryName?.GetHashCode() ?? 0);
            hash = hash * 23 + (CompoundName?.GetHashCode() ?? 0);
            hash = hash * 23 + (CompoundType?.GetHashCode() ?? 0);
            hash = hash * 23 + (TestBatchName?.GetHashCode() ?? 0);
            hash = hash * 23 + TestResultLevel.GetHashCode();
            hash = hash * 23 + (ReportUnit?.GetHashCode() ?? 0);
            hash = hash * 23 + (TestTypeName?.GetHashCode() ?? 0);
            hash = hash * 23 + TestPassed.GetHashCode();
            hash = hash * 23 + (TestComment?.GetHashCode() ?? 0);
            hash = hash * 23 + (TestPerformedDate?.GetHashCode() ?? 0);
            hash = hash * 23 + OverallPassed.GetHashCode();
            hash = hash * 23 + (LabFacilityLicenseNumber?.GetHashCode() ?? 0);
            hash = hash * 23 + (LabFacilityName?.GetHashCode() ?? 0);
            hash = hash * 23 + TestInformationalOnly.GetHashCode();
            hash = hash * 23 + ResultReleased.GetHashCode();
            hash = hash * 23 + (ResultReleaseDateTime?.GetHashCode() ?? 0);
            hash = hash * 23 + (ExpirationDateTime?.GetHashCode() ?? 0);
            hash = hash * 23 + (RevokedDate?.GetHashCode() ?? 0);
            hash = hash * 23 + (LabTestDetailRevokedDate?.GetHashCode() ?? 0);
            hash = hash * 23 + LabTestTypeId.GetHashCode();

            return hash;
        }
    }

}

