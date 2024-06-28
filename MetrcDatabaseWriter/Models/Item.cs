using Microsoft.EntityFrameworkCore;

namespace MetrcDatabaseWriter;

[PrimaryKey(nameof(Id), nameof(FacilityLicense))]
public class Item : IMetrcModel
{
    public      int              Id                                          { get; set; }
    public      string           FacilityLicense                             { get; set; }
    public      string?          Name                                        { get; set; }
    public      string?          ProductCategoryName                         { get; set; }
    public      string?          ProductCategoryType                         { get; set; }
    public      bool             IsExpirationDateRequired                    { get; set; }
    public      bool             HasExpirationDate                           { get; set; }
    public      bool             IsSellByDateRequired                        { get; set; }
    public      bool             HasSellByDate                               { get; set; }
    public      bool             IsUseByDateRequired                         { get; set; }
    public      bool             HasUseByDate                                { get; set; }
    public      string?          QuantityType                                { get; set; }
    public      string?          DefaultLabTestingState                      { get; set; }
    public      string?          UnitOfMeasureName                           { get; set; }
    public      string?          ApprovalStatus                              { get; set; }
    public      DateTime         ApprovalStatusDateTime                      { get; set; }
    public      int?             StrainId                                    { get; set; }
    public      string?          StrainName                                  { get; set; }
    public      int?             ItemBrandId                                 { get; set; }
    public      string?          ItemBrandName                               { get; set; }
    public      string?          AdministrationMethod                        { get; set; }
    public      string?          UnitCbdPercent                              { get; set; }
    public      string?          UnitCbdContent                              { get; set; }
    public      string?          UnitCbdContentUnitOfMeasureName             { get; set; }
    public      string?          UnitCbdContentDose                          { get; set; }
    public      string?          UnitCbdContentDoseUnitOfMeasureName         { get; set; }
    public      string?          UnitThcPercent                              { get; set; }
    public      string?          UnitThcContent                              { get; set; }
    public      string?          UnitThcContentUnitOfMeasureName             { get; set; }
    public      string?          UnitThcContentDose                          { get; set; }
    public      string?          UnitThcContentDoseUnitOfMeasureName         { get; set; }
    public      string?          UnitVolume                                  { get; set; }
    public      string?          UnitVolumeUnitOfMeasureName                 { get; set; }
    public      string?          UnitWeight                                  { get; set; }
    public      string?          UnitWeightUnitOfMeasureName                 { get; set; }
    public      string?          ServingSize                                 { get; set; }
    public      string?          SupplyDurationDays                          { get; set; }
    public      string?          NumberOfDoses                               { get; set; }
    public      string?          UnitQuantity                                { get; set; }
    public      string?          UnitQuantityUnitOfMeasureName               { get; set; }
    public      string?          PublicIngredients                           { get; set; }
    public      string?          Description                                 { get; set; }
    public      string?          Allergens                                   { get; set; }
    public      string[]?        ProductImages                               { get; set; }
    public      string?          ProductPhotoDescription                     { get; set; }
    public      string[]?        LabelImages                                 { get; set; }
    public      string?          LabelPhotoDescription                       { get; set; }
    public      string[]?        PackagingImages                             { get; set; }
    public      string?          PackagingPhotoDescription                   { get; set; }
    public      string[]?        ProductPDFDocuments                         { get; set; }
    public      bool             IsUsed                                      { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is null || !(obj is Item other))
        {
            return false;
        }

        return Id.Equals(other.Id)
            && FacilityLicense.Equals(other.FacilityLicense)
            && Name == other.Name
            && ProductCategoryName == other.ProductCategoryName
            && ProductCategoryType == other.ProductCategoryType
            && IsExpirationDateRequired.Equals(other.IsExpirationDateRequired)
            && HasExpirationDate.Equals(other.HasExpirationDate)
            && IsSellByDateRequired.Equals(other.IsSellByDateRequired)
            && HasSellByDate.Equals(other.HasSellByDate)
            && IsUseByDateRequired.Equals(other.IsUseByDateRequired)
            && HasUseByDate.Equals(other.HasUseByDate)
            && QuantityType == other.QuantityType
            && DefaultLabTestingState == other.DefaultLabTestingState
            && UnitOfMeasureName == other.UnitOfMeasureName
            && ApprovalStatus == other.ApprovalStatus
            && ApprovalStatusDateTime.Equals(other.ApprovalStatusDateTime)
            && StrainId.Equals(other.StrainId)
            && StrainName == other.StrainName
            && ItemBrandId.Equals(other.ItemBrandId)
            && ItemBrandName == other.ItemBrandName
            && AdministrationMethod == other.AdministrationMethod
            && UnitCbdPercent == other.UnitCbdPercent
            && UnitCbdContent == other.UnitCbdContent
            && UnitCbdContentUnitOfMeasureName == other.UnitCbdContentUnitOfMeasureName
            && UnitCbdContentDose == other.UnitCbdContentDose
            && UnitCbdContentDoseUnitOfMeasureName == other.UnitCbdContentDoseUnitOfMeasureName
            && UnitThcPercent == other.UnitThcPercent
            && UnitThcContent == other.UnitThcContent
            && UnitThcContentUnitOfMeasureName == other.UnitThcContentUnitOfMeasureName
            && UnitThcContentDose == other.UnitThcContentDose
            && UnitThcContentDoseUnitOfMeasureName == other.UnitThcContentDoseUnitOfMeasureName
            && UnitVolume == other.UnitVolume
            && UnitVolumeUnitOfMeasureName == other.UnitVolumeUnitOfMeasureName
            && UnitWeight == other.UnitWeight
            && UnitWeightUnitOfMeasureName == other.UnitWeightUnitOfMeasureName
            && ServingSize == other.ServingSize
            && SupplyDurationDays == other.SupplyDurationDays
            && NumberOfDoses == other.NumberOfDoses
            && UnitQuantity == other.UnitQuantity
            && UnitQuantityUnitOfMeasureName == other.UnitQuantityUnitOfMeasureName
            && PublicIngredients == other.PublicIngredients
            && Description == other.Description
            && Allergens == other.Allergens
            && Enumerable.SequenceEqual(ProductImages ?? Array.Empty<string>(), other.ProductImages ?? Array.Empty<string>())
            && ProductPhotoDescription == other.ProductPhotoDescription
            && Enumerable.SequenceEqual(LabelImages ?? Array.Empty<string>(), other.LabelImages ?? Array.Empty<string>())
            && LabelPhotoDescription == other.LabelPhotoDescription
            && Enumerable.SequenceEqual(PackagingImages ?? Array.Empty<string>(), other.PackagingImages ?? Array.Empty<string>())
            && PackagingPhotoDescription == other.PackagingPhotoDescription
            && Enumerable.SequenceEqual(ProductPDFDocuments ?? Array.Empty<string>(), other.ProductPDFDocuments ?? Array.Empty<string>())
            && IsUsed.Equals(other.IsUsed);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + Id.GetHashCode();
            hash = hash * 23 + FacilityLicense.GetHashCode();
            hash = hash * 23 + (Name?.GetHashCode() ?? 0);
            hash = hash * 23 + (ProductCategoryName?.GetHashCode() ?? 0);
            hash = hash * 23 + (ProductCategoryType?.GetHashCode() ?? 0);
            hash = hash * 23 + IsExpirationDateRequired.GetHashCode();
            hash = hash * 23 + HasExpirationDate.GetHashCode();
            hash = hash * 23 + IsSellByDateRequired.GetHashCode();
            hash = hash * 23 + HasSellByDate.GetHashCode();
            hash = hash * 23 + IsUseByDateRequired.GetHashCode();
            hash = hash * 23 + HasUseByDate.GetHashCode();
            hash = hash * 23 + (QuantityType?.GetHashCode() ?? 0);
            hash = hash * 23 + (DefaultLabTestingState?.GetHashCode() ?? 0);
            hash = hash * 23 + (UnitOfMeasureName?.GetHashCode() ?? 0);
            hash = hash * 23 + (ApprovalStatus?.GetHashCode() ?? 0);
            hash = hash * 23 + ApprovalStatusDateTime.GetHashCode();
            hash = hash * 23 + (StrainId?.GetHashCode() ?? 0);
            hash = hash * 23 + (StrainName?.GetHashCode() ?? 0);
            hash = hash * 23 + (ItemBrandId?.GetHashCode() ?? 0);
            hash = hash * 23 + (ItemBrandName?.GetHashCode() ?? 0);
            hash = hash * 23 + (AdministrationMethod?.GetHashCode() ?? 0);
            hash = hash * 23 + (UnitCbdPercent?.GetHashCode() ?? 0);
            hash = hash * 23 + (UnitCbdContent?.GetHashCode() ?? 0);
            hash = hash * 23 + (UnitCbdContentUnitOfMeasureName?.GetHashCode() ?? 0);
            hash = hash * 23 + (UnitCbdContentDose?.GetHashCode() ?? 0);
            hash = hash * 23 + (UnitCbdContentDoseUnitOfMeasureName?.GetHashCode() ?? 0);
            hash = hash * 23 + (UnitThcPercent?.GetHashCode() ?? 0);
            hash = hash * 23 + (UnitThcContent?.GetHashCode() ?? 0);
            hash = hash * 23 + (UnitThcContentUnitOfMeasureName?.GetHashCode() ?? 0);
            hash = hash * 23 + (UnitThcContentDose?.GetHashCode() ?? 0);
            hash = hash * 23 + (UnitThcContentDoseUnitOfMeasureName?.GetHashCode() ?? 0);
            hash = hash * 23 + (UnitVolume?.GetHashCode() ?? 0);
            hash = hash * 23 + (UnitVolumeUnitOfMeasureName?.GetHashCode() ?? 0);
            hash = hash * 23 + (UnitWeight?.GetHashCode() ?? 0);
            hash = hash * 23 + (UnitWeightUnitOfMeasureName?.GetHashCode() ?? 0);
            hash = hash * 23 + (ServingSize?.GetHashCode() ?? 0);
            hash = hash * 23 + (SupplyDurationDays?.GetHashCode() ?? 0);
            hash = hash * 23 + (NumberOfDoses?.GetHashCode() ?? 0);
            hash = hash * 23 + (UnitQuantity?.GetHashCode() ?? 0);
            hash = hash * 23 + (UnitQuantityUnitOfMeasureName?.GetHashCode() ?? 0);
            hash = hash * 23 + (PublicIngredients?.GetHashCode() ?? 0);
            hash = hash * 23 + (Description?.GetHashCode() ?? 0);
            hash = hash * 23 + (Allergens?.GetHashCode() ?? 0);
            hash = hash * 23 + (ProductPhotoDescription?.GetHashCode() ?? 0);
            hash = hash * 23 + (ProductImages?.Length ?? 0); // Array length for array comparison
            hash = hash * 23 + (LabelPhotoDescription?.GetHashCode() ?? 0);
            hash = hash * 23 + (LabelImages?.Length ?? 0); // Array length for array comparison
            hash = hash * 23 + (PackagingPhotoDescription?.GetHashCode() ?? 0);
            hash = hash * 23 + (PackagingImages?.Length ?? 0); // Array length for array comparison
            hash = hash * 23 + (ProductPDFDocuments?.Length ?? 0); // Array length for array comparison
            hash = hash * 23 + IsUsed.GetHashCode();
            return hash;
        }
    }

}
