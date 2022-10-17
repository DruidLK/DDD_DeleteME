using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RichDomainModel.Brokers
{
    public sealed class StorageBrokerFactory : IDesignTimeDbContextFactory<StorageBroker>
    {
        public StorageBroker CreateDbContext(string[] args)
        {
            //var environment =
            //    Environment.GetEnvironmentVariable(variable:"ASPNETCORE_ENVIRONMENT");

            //var configuration = new ConfigurationBuilder()
            //.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../BookingApp.API/"))
            //.AddJsonFile(path: "appsettings", optional: false, reloadOnChange: true)
            //.AddJsonFile(path: $"appsettings.{environment}.json")
            //.AddEnvironmentVariables()
            //.Build();

            //IConfiguration configuration = new ConfigurationBuilder()
            //.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../RetailBank.API"))
            //.AddJsonFile("appsettings.Development.json")
            //.Build();

            var dbContextBuilder =
                new DbContextOptionsBuilder<StorageBroker>();

            var connectionString =
                "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = DDDEF; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
                //configuration.GetConnectionString("DefaultConnection");

            dbContextBuilder.UseSqlServer(connectionString);

            return new StorageBroker(dbContextBuilder.Options);
        }
    }
}
