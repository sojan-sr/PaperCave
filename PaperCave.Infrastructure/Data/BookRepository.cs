using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using PaperCave.Infrastructure.Clients;
using PaperCave.Infrastructure.Query;
using PaperCave.Infrastructure.Utils;
using PaperCave.Models.Book;

namespace PaperCave.Infrastructure.Data;

public class BookRepository(ICosmosClientBuilder cosmosBuilder, 
    ILogger<BookRepository> logger,
    FeedIteratorUtil feedIteratorUtil) : IBookRepository
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
        try
        {
            return await cosmosBuilder.GetContainer("PaperCave", "Books")
                .CreateItemAsync(item: bookToInsert, partitionKey: new PartitionKey(bookToInsert.Genre));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Book Repo error: {Error}", ex.Message);
            return new BookModel();
        }
    }
}