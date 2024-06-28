using Microsoft.Extensions.Configuration;

namespace MetrcDatabaseWriter;

public class DbContextFactory
{
    private IConfiguration _config;

    public DbContextFactory(IConfiguration config)
    {
        _config = config;
    }

    public MetrcDbContext GetMetrcDbContext()
    {
        string connString;
        string writeMode = _config["DatabaseWriteMode"]!;

        switch (writeMode.ToLower())
        {
            case "sql":
                connString = _config["ConnectionStrings:SqlConnection"]!;
                return new MetrcSQLContext(connString);
            case "access":
                connString = _config["ConnectionStrings:AccessConnection"]!;
                return new MetrcAccessContext(connString);
        }

        return null;
    }
}
