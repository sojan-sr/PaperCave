using Azure.Identity;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using PaperCave.Models.Settings;

namespace PaperCave.Infrastructure.Clients
{
    public class CosmosClientBuilder(IOptions<CosmosSettings> settings) : ICosmosClientBuilder
    {
        private CosmosClient? client;

        private CosmosClient CreateClient() 
        {
            if (client is null) 
            {            
                var credentials = new DefaultAzureCredential();
                client = new CosmosClient(settings.Value.ConnectionString, credentials);
                return client;
            }
            return client;
        }

        public Container GetContainer(string databaseName, string containerName)
        {
            return CreateClient().GetDatabase(databaseName).GetContainer(containerName);
        }
    }
}
