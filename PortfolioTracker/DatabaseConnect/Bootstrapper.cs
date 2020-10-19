﻿using PortfolioTracker.Database.DataModels;
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
            await ConfigureTickerDataRepo(services, client, databaseName);
        }

        private static async Task ConfigureTickerDataRepo(IServiceCollection services, CosmosClient client, string databaseName)
        {
            // Create TickerData container if it does not exist
            await client.GetDatabase(databaseName).DefineContainer(name: ContainerNames.TickerData, partitionKeyPath: "/id")
                                                    .CreateIfNotExistsAsync();

            //register data service
            services.AddSingleton((IDataService<TickerData>)new CosmosDataService<TickerData>(client, databaseName, ContainerNames.TickerData));
            services.AddSingleton<IRepository<TickerData>, TickerDataRepository>();
        }
    }
}