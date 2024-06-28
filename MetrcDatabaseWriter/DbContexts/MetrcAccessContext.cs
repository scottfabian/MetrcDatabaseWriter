using Microsoft.EntityFrameworkCore;
using EntityFrameworkCore.Jet;

namespace MetrcDatabaseWriter;

public class MetrcAccessContext : MetrcDbContext
{
    private readonly string _connectionString;


    public MetrcAccessContext()
    {
        _connectionString = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=.\MetrcData.accdb;";
    }

    public MetrcAccessContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseJet(_connectionString);
    }

}
