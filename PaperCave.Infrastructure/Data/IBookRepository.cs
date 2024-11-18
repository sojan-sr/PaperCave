using PaperCave.Models;
namespace PaperCave.Infrastructure.Data;
public interface IBookRepository
{
    public Task<IEnumerable<BookModel>> GetBookByName(string name);
    public Task<IEnumerable<BookModel>> GetBookById(string id);
    public Task<IEnumerable<BookModel>> GetBookByAuthor(string authorName);
}