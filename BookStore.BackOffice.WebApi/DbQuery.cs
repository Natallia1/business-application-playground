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
            //var bookFilters = filter.GetBookFilters();

            var query = context.Books.AsQueryable();
            if (filter.IsBestSeller.HasValue)
            {
                query = query.Where(x => x.IsBestSeller == filter.IsBestSeller);
            }
            if (filter.IsBestSeller.HasValue)
            {
                query = query.Where(x => x.Author.Id == filter.AuthorId);
            }

            return query.ToList();
        }
    }
}
