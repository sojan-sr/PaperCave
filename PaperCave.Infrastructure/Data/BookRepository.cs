using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using PaperCave.Infrastructure.Clients;
using PaperCave.Infrastructure.Query;
using PaperCave.Infrastructure.Utils;
using PaperCave.Models;
using PaperCave.Models.Settings;

namespace PaperCave.Infrastructure.Data;

public class BookRepository(ICosmosClientBuilder cosmosBuilder, 
    FeedIteratorUtil feedIteratorUtil, 
    IOptions<CosmosSettings> settings) : IBookRepository
{
    public async Task<IEnumerable<BookModel>> GetBookByName(string name)
    {
        return await feedIteratorUtil.Fetch<BookModel>(QueryRegister.GetBookByName, "@name", name, "PaperCave", "Books");
    }

    public async Task<IEnumerable<BookModel>> GetBooksByAuthor(string authorName)
    {
        return await feedIteratorUtil.Fetch<BookModel>(QueryRegister.GetBooksByAuthor, "@name", authorName, "PaperCave", "Books");
    }

    public IEnumerable<BookModel> GetBooks()
    {
        return cosmosBuilder.GetContainer("PaperCave", "Books").GetItemLinqQueryable<BookModel>();
    }

    public async Task<BookModel> InsertBook(BookModel bookToInsert)
    {
        return await cosmosBuilder.GetContainer("PaperCave", "Books").UpsertItemAsync(item: bookToInsert, 
            partitionKey: new PartitionKey(settings.Value.PartitionKey));
    }
}