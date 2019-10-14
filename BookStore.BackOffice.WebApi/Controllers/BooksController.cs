using Microsoft.AspNetCore.Mvc;
using BookStore.BackOffice.WebApi.Models;
using BookStore.BackOffice.WebApi.FileFactory.Word;

namespace BookStore.BackOffice.WebApi.Controllers
{
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly DbQuery dbQuery;

        public BooksController(DbQuery dbQuery)
        {
            this.dbQuery = dbQuery;
        }

        //POST Books/Filter
        [HttpPost]
        [Route("books/filter")]
        public FileContentResult Filter([FromBody]Filter filter)
        {
            var books = dbQuery.GetFilteredBooks(filter);
            var word = new BookListToWord();
            var fileStream = word.GetWord(books);

            var result = new FileContentResult(fileStream.ToArray(), "application/ms-word");
            result.FileDownloadName = "myReport.docx";
            return result;
        }  
    }
}
