
using Microsoft.AspNetCore.Mvc;
using BookStore.BackOffice.WebApi.Models;
using System.Collections.Generic;

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
        public List<Book> Filter([FromBody]Filter filter)
        {
            //= new Filter() { IsBestSeller = true };
            var books = dbQuery.GetFilteredBooks(filter);

            return books;
        }
    }
}
