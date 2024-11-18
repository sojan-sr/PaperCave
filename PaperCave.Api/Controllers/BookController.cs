using Microsoft.AspNetCore.Mvc;
using PaperCave.Models.Requests.Enums;
using PaperCave.Services.BookService;

namespace PaperCave.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController(IBookService bookService) : ControllerBase
{
    [HttpGet("ExtractName")]
    public async Task<IActionResult> ExtractBookName([FromForm]byte[] imageData)
    {
        
        await Task.FromResult(string.Empty);
        return Ok(string.Empty);
    }

    [HttpGet("GetBookByName")]
    public async Task<IActionResult> GetBookByName([FromQuery] string bookName)
    {
        var result = await bookService.GetBooksAsync(bookName, FetchType.ByName);
        return Ok(result);
    }
    
    [HttpGet("GetBookById")]
    public async Task<IActionResult> GetBookById([FromQuery] string bookName)
    {
        var result = await bookService.GetBooksAsync(bookName, FetchType.ByName);
        return Ok(result);
    }
    
    [HttpGet("GetBookByAuthor")]
    public async Task<IActionResult> GetBookByAuthor([FromQuery] string bookName)
    {
        var result = await bookService.GetBooksAsync(bookName, FetchType.ByName);
        return Ok(result);
    }
}