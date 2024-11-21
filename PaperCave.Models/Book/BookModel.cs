using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace PaperCave.Models.Book;
public class BookModel
{
    public BookModel() { Id = Guid.NewGuid().ToString(); }

    [JsonProperty("id")]
    [SwaggerSchema(ReadOnly = true)]
    public string Id { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; } = string.Empty;

    [JsonProperty("authorName")]
    public string AuthorName { get; set; } = string.Empty;

    [JsonProperty("genre")]
    public string Genre { get; set; } = string.Empty;

    [JsonProperty("pageCount")]
    public int PageCount { get; set; }
}