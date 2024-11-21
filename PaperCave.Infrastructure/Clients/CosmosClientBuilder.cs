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
                client = new CosmosClient(settings.Value.ConnectionString, 
                    new CosmosClientOptions
                    {
                        ConnectionMode = ConnectionMode.Gateway,
                        SerializerOptions = new CosmosSerializationOptions
                        {
                            PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
                        }
                    });
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
