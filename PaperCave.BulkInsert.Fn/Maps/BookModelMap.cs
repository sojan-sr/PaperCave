using CsvHelper.Configuration;
using PaperCave.Models.Book;

namespace PaperCave.BulkInsert.Fn.Maps
{
    public sealed class BookModelMap : ClassMap<BookModel>
    {
        public BookModelMap()
        {
            Map(e => e.Title).Name("Title");
            Map(e => e.AuthorName).Name("Author");
            Map(e => e.Genre).Name("Genre");
            Map(e => e.PageCount).Name("Pages");
        }
    }
}
