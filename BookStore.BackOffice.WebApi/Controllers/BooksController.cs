using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStore.BackOffice.WebApi.Models;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;

namespace BookStore.BackOffice.WebApi.Controllers
{
    [Route("books/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // POST Books/Filter
        [HttpPost]
        public WordDocument Filter([FromBody] Filter filter)
        {
        }
    }
}
