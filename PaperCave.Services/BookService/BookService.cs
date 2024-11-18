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
            FetchType.ById => await bookRepository.GetBookById(parameter),
            FetchType.ByAuthorName => await bookRepository.GetBookByAuthor(parameter),   
            _ => throw new ApplicationException("Invalid fetch type")
        };
}