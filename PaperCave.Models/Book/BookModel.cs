namespace PaperCave.Models;
public class BookModel
{
    public string Title { get; set; } = string.Empty;
    public string AuthorName { get; set; } = string.Empty;
    private int PageCount { get; set; }
}