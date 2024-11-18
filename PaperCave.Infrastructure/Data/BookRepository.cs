using PaperCave.Models;

namespace PaperCave.Infrastructure.Data;

public class BookRepository : IBookRepository
{
    public Task<IEnumerable<BookModel>> GetBookByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BookModel>> GetBookById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BookModel>> GetBookByAuthor(string authorName)
    {
        throw new NotImplementedException();
    }
}