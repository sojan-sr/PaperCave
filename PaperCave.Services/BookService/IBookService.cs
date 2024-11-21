using PaperCave.Models.Book;
using PaperCave.Models.Requests.Enums;

namespace PaperCave.Services.BookService;

public interface IBookService
{
    public Task<IEnumerable<BookModel>> GetBooksAsync(string parameter, FetchType fetchType);
    public Task<BookModel> InsertBook(BookModel book);
}