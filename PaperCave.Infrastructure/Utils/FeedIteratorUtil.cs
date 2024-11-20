using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using PaperCave.Infrastructure.Clients;

namespace PaperCave.Infrastructure.Utils
{
    public class FeedIteratorUtil(ICosmosClientBuilder cosmosBuilder, ILogger<FeedIteratorUtil> logger)
    {
        public async Task<IEnumerable<T>> Fetch<T>(string queryString, string parameter, string value , string databaseName, string containerName) 
        {
            List<T> responseList = [];
            try
            {
                var query = new QueryDefinition(queryString).WithParameter(parameter, value);
                using FeedIterator<T> feed = cosmosBuilder.GetContainer(databaseName, containerName).GetItemQueryIterator<T>(query);

                while (feed.HasMoreResults)
                {
                    FeedResponse<T> response = await feed.ReadNextAsync();
                    responseList.AddRange(response);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Feed Util error: {Error}", ex.Message);
            }
            return responseList;
        }
    }
}
