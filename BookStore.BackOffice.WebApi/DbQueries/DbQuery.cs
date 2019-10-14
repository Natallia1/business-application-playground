using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.BackOffice.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.BackOffice.WebApi.DbQueries
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
            var query = context.Books.Include(b=>b.Author).AsQueryable();
            query = filter.AddBookFilters(query);
            return query.ToList();
        }
    }
}
