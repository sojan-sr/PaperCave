using CsvHelper;
using Microsoft.Extensions.Logging;
using PaperCave.BulkInsert.Fn.Maps;
using PaperCave.Models.Book;
using System.Globalization;

namespace PaperCave.BulkInsert.Fn.Utils
{
    public static class CsvUtil
    {
        public static List<BookModel> LoadBookDataFromCsv(string csvPath, ILogger logger)
        {
            try
            {
                using var reader = new StreamReader(csvPath);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                csv.Context.RegisterClassMap<BookModelMap>();
                var records = csv.GetRecords<BookModel>();
                return records.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Csv reading utility error: {Error}", ex.Message);
            }
            return [];
        }
    }
}
