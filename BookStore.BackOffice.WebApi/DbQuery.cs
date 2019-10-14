using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.BackOffice.WebApi.Models;
using Microsoft.EntityFrameworkCore;

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
            var query = context.Books.Include(b=>b.Author).AsQueryable();
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
