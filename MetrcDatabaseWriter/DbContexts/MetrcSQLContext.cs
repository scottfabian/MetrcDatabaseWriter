using Microsoft.EntityFrameworkCore;

namespace MetrcDatabaseWriter;

public class MetrcSQLContext : MetrcDbContext
{
    private string _connectionString;


    public MetrcSQLContext()
    {
        _connectionString = @"Data Source=(local);Database=MetrcData;Integrated Security=false;User ID=sa;Password=TeklynxAdmin!;Trust Server Certificate=true";
    }

    public MetrcSQLContext(string connectionString)
    {
        _connectionString = connectionString;
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString,
            options => options.EnableRetryOnFailure())
            .EnableSensitiveDataLogging();
    }

}
