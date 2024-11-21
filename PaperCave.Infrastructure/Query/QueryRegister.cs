namespace PaperCave.Infrastructure.Query
{
    public static class QueryRegister
    {
        public const string GetBookByName = "SELECT * FROM books p WHERE p.title = @name";
        public const string GetBooksByAuthor = "SELECT * FROM books p WHERE p.authorName = @name";
    }
}
