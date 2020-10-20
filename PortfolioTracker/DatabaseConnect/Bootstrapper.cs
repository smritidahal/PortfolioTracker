using PortfolioTracker.Database.DataModels;
using PortfolioTracker.Database.Repositories;
using PortfolioTracker.Database.Services;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace PortfolioTracker.DatabaseConnect
{
    public static class Bootstrapper
    {
        public static async Task AddDatabaseRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            IConfigurationSection configurationSection = configuration.GetSection("CosmosDb");
            string databaseName = configurationSection.GetSection("DatabaseName").Value;
            string account = configurationSection.GetSection("Account").Value;
            string key = configurationSection.GetSection("Key").Value;

            CosmosClientBuilder clientBuilder = new CosmosClientBuilder(account, key);
            CosmosClient client = clientBuilder
                                .WithConnectionModeDirect()
                                .Build();


            // create Database
            await client.CreateDatabaseIfNotExistsAsync(databaseName);

            // register TickerData Repository
            await ConfigurePortfolioDataRepo(services, client, databaseName);
        }

        private static async Task ConfigurePortfolioDataRepo(IServiceCollection services, CosmosClient client, string databaseName)
        {
            // Create TickerData container if it does not exist
            await client.GetDatabase(databaseName).DefineContainer(name: ContainerNames.Portfolio, partitionKeyPath: "/id")
                                                    .CreateIfNotExistsAsync();

            //register data service
            services.AddSingleton((IDataService<Portfolio>)new CosmosDataService<Portfolio>(client, databaseName, ContainerNames.Portfolio));
            services.AddSingleton<IRepository<Portfolio>, PortfolioRepository>();
        }
    }
}
