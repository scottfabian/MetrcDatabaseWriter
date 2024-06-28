using MetrcAPIService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace MetrcDatabaseWriter;

public class Program
{
    public static void Main(string[] args)
    {
        //INSTALL PACKAGES - Microsoft.Extensions.DependencyInjection, Microsoft.Extensions.Configuration.Json

        //create service collection for DI
        ServiceCollection serviceCollection = new ServiceCollection();

        // build a configuration
        var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings.json");

        IConfiguration config = configurationBuilder.Build();


        //add the config to the service collection
        serviceCollection.AddSingleton<IConfiguration>(config);
        serviceCollection.AddSingleton<MetrcMapper>();
        serviceCollection.AddSingleton<MetrcApiFactory>();
        serviceCollection.AddSingleton<HttpClient>(serviceProvider =>
        {
            var socketHandler = new SocketsHttpHandler()
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(10),
            };

            return new HttpClient(socketHandler);
        });
        serviceCollection.AddSingleton<MetrcAPI>(serviceProvider =>
        {
            var metrcApiFactory = serviceProvider.GetRequiredService<MetrcApiFactory>();
            return metrcApiFactory.CreateMetrcAPI();
        });
        serviceCollection.AddSingleton<DbContextFactory>();
        serviceCollection.AddSingleton<MetrcDbContext>(serviceProvider =>
        {
            var dbContextFactory = serviceProvider.GetRequiredService<DbContextFactory>();
            return dbContextFactory.GetMetrcDbContext();
        });
        serviceCollection.AddSingleton<DataGatherer>();
        serviceCollection.AddSingleton<DatabaseWriter>();
        serviceCollection.AddSingleton<ILogger>(serviceProvider =>
        {
            IConfiguration _localConfig = serviceProvider.GetRequiredService<IConfiguration>();

            Log.Logger = new LoggerConfiguration()
                                .ReadFrom.Configuration(_localConfig)
                                .CreateLogger();
            return Log.Logger;
        });
        //add other services


        // build the service provider
        var serviceProvider = serviceCollection.BuildServiceProvider();

        //run app
        var writer = serviceProvider.GetService<DatabaseWriter>()!;

        writer.SyncMetrcData().GetAwaiter().GetResult();

        //try
        //{
        //    writer.SyncMetrcData().GetAwaiter().GetResult();
        //}
        //catch (Exception ex)
        //{
        //    Log.Logger.Error(ex.Message);

        //    if (ex.InnerException is not null)
        //    {
        //        Log.Logger.Error(ex.InnerException.Message);

        //        if (ex.InnerException.StackTrace is not null)
        //        {
        //            Log.Logger.Error(ex.InnerException.StackTrace);
        //        }             
        //    }

        //    if (ex.StackTrace is not null)
        //    {
        //        Log.Logger.Error(ex.StackTrace);
        //    }
        //}

        //serviceProvider.Dispose();
        Log.CloseAndFlush();
    }    
}
