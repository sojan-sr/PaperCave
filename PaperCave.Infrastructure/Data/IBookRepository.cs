using PaperCave.Models;
namespace PaperCave.Infrastructure.Data;
public interface IBookRepository
{
    public Task<IEnumerable<BookModel>> GetBookByName(string name);
    public Task<IEnumerable<BookModel>> GetBooksByAuthor(string authorName);
    public Task<BookModel> InsertBook(BookModel bookToInsert);
}