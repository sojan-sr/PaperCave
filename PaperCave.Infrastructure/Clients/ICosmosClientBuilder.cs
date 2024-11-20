using Microsoft.Azure.Cosmos;

namespace PaperCave.Infrastructure.Clients
{
    public interface ICosmosClientBuilder
    {
        public Container GetContainer(string databaseName, string containerName);

    }
}
