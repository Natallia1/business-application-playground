using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.BackOffice.WebApi.Models;

namespace BookStore.BackOffice.WebApi
{
    public class DbQuery
    {
        private readonly BookStoreDbContext context;
        public DbQuery(BookStoreDbContext context)
        {
            this.context = context;
        }

        public List<Book> GetFilteredBooks(Filter filter)
        {
            var bookFilters = filter.GetBookFilters();
            var authorFilters = filter.GetAuthorFilters();

            return context.Books
                .Where(b => bookFilters(b) && authorFilters(b.Author))
                .ToList<Book>();
        }
    }
}
