using PaperCave.Infrastructure.Data;
using PaperCave.Models;
using PaperCave.Models.Requests.Enums;

namespace PaperCave.Services.BookService;

public class BookService(IBookRepository bookRepository) : IBookService
{
    public async Task<IEnumerable<BookModel>> GetBooksAsync(string parameter, FetchType fetchType) =>
        fetchType switch
        {
            FetchType.ByName => await bookRepository.GetBookByName(parameter),
            FetchType.ByAuthorName => await bookRepository.GetBooksByAuthor(parameter),   
            _ => throw new ArgumentException("Invalid fetch type")
        };

    public async Task<BookModel> InsertBook(BookModel book) { return await bookRepository.InsertBook(book); }
}