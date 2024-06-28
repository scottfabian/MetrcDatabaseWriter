using Microsoft.EntityFrameworkCore;

namespace MetrcDatabaseWriter;

public abstract class MetrcDbContext : DbContext
{
    public DbSet<Facility> Facility { get; set; }
    public DbSet<Harvest> Harvest { get; set; }
    public DbSet<Item> Item { get; set; }
    public DbSet<LabTestResult> LabTestResult { get; set; }
    public DbSet<LabTestType> LabTestType { get; set; }
    public DbSet<Package> Package { get; set; }
    public DbSet<Strain> Strain { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Facility>(entity =>
        {
            entity.HasKey(f => f.LicenseNumber);
        });

        modelBuilder.Entity<Harvest>(entity =>
        {
            entity.HasOne<Facility>()
                .WithMany()
                .HasForeignKey(h => h.FacilityLicense)
                .HasPrincipalKey(l => l.LicenseNumber);

            entity.Property(h => h.FacilityLicense)
                .IsRequired();
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasOne<Facility>()
                .WithMany()
                .HasForeignKey(i => i.FacilityLicense)
                .HasPrincipalKey(l => l.LicenseNumber);

            entity.Property(i => i.FacilityLicense).IsRequired();
        });

        modelBuilder.Entity<LabTestResult>(entity =>
        {
            entity.HasKey(e => e.Id); // Configure Id as the primary key
            entity.Property(e => e.Id).ValueGeneratedOnAdd(); // Configure Id to be auto-incrementing

            entity.HasIndex(e => e.LabTestResultId).IsUnique(false); // Ensure LabTestResultId is not unique

            entity.HasOne<Package>()
                .WithMany()
                .HasForeignKey(e => e.PackageId)
                .HasPrincipalKey(p => p.Id)
                .OnDelete(DeleteBehavior.NoAction);

        });

        modelBuilder.Entity<LabTestType>(entity =>
        {
            entity.HasOne<Facility>()
                .WithMany()
                .HasForeignKey(t => t.FacilityLicense)
                .HasPrincipalKey(l => l.LicenseNumber);

            entity.Property(t => t.FacilityLicense).IsRequired();
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.HasOne<Facility>()
                .WithMany()
                .HasForeignKey(p => p.FacilityLicense)
                .HasPrincipalKey(l => l.LicenseNumber);

            entity.HasOne<Item>()
                .WithMany()
                .HasForeignKey(p => p.ItemId)
                .HasPrincipalKey(i => i.Id);

            entity.Property(p => p.FacilityLicense).IsRequired();
        });

        modelBuilder.Entity<Strain>(entity =>
        {
            entity.HasOne<Facility>()
                .WithMany()
                .HasForeignKey(s => s.FacilityLicense)
                .HasPrincipalKey(l => l.LicenseNumber);

            entity.Property(s => s.FacilityLicense).IsRequired();
        });

    }
}
