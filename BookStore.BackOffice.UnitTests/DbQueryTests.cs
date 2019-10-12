using System;
using Xunit;
using BookStore.BackOffice.WebApi;
using BookStore.BackOffice.WebApi.Models;

namespace BookStore.BackOffice.UnitTests
{
    public class DbQueryTests
    {
        private readonly DbQuery dbQuery;
        public DbQueryTests(DbQuery dbQuery)
        {
            this.dbQuery = dbQuery;
        }

        [Theory]
        [InlineData(true, 3)]
        public void FilterBooksByBestseller(bool isBestseller, int bookCount)
        {
            var filter = new Filter()
            {
                IsBestSeller = isBestseller
            };

            var books = dbQuery.GetFilteredBooks(filter);
            Assert.Equal(bookCount, books.Count);
        }
    }
}
