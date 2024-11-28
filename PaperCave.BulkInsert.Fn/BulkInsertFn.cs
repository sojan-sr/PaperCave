using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using PaperCave.BulkInsert.Fn.Utils;
using PaperCave.Infrastructure.Data;
using PaperCave.Models.Book;

namespace PaperCave.BulkInsert.Fn
{
    public class BulkInsertFn(IBookRepository bookRepository, ILogger<BulkInsertFn> logger)
    {

        [Function("BulkInsert")]
        public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest httpRequest)
        {
            logger.LogInformation("Starting Bulk Insert at: {Time}", DateTime.Now);
            List<BookModel> failedCount = [];
            List<BookModel> bookList;

            try
            {
                var bookData = httpRequest.Form.Files["BulkInsertFile"];
                string filePath = Path.Combine("BookData.csv");

                if (bookData?.Length > 0)
                {
                    using Stream fileStream = new FileStream(filePath, FileMode.Create);
                    await bookData.CopyToAsync(fileStream);
                }

                bookList = CsvUtil.LoadBookDataFromCsv(filePath, logger);

                foreach (var book in bookList) 
                {
                    var result = await bookRepository.InsertBook(book);
                    if (string.IsNullOrEmpty(result.Title)) 
                    {
                        failedCount.Add(book);    
                    }
                }

                if (failedCount.Count == bookList.Count)
                {
                    return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                }
                else if(failedCount.Count > 0) 
                {
                    return new OkObjectResult(failedCount);
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Bulk Insert function error: {Message}", ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            logger.LogInformation("Bulk Insert Finished Successfully at: {Time}", DateTime.Now);
            return new OkObjectResult(bookList);
        }
    }
}
