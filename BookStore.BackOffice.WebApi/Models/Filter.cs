using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.BackOffice.WebApi.Enums;

namespace BookStore.BackOffice.WebApi.Models
{
    public class Filter
    {
        public int? PublicationYear { get; set; }
        public Period? PeriodRelativeToPublicationYear { get; set; }
        public bool? IsBestSeller { get; set; }
        public int? AuthorId { get; set; }

        public IQueryable<Book> AddBookFilters(IQueryable<Book> query)
        {
            query = GetIsBestsellerFilter(query);
            query = GetAuthorFilter(query);
            query = GetPeriodFilter(query);

            return query;
        }

        private IQueryable<Book> GetIsBestsellerFilter(IQueryable<Book> query)
        {
            if (IsBestSeller != null)
            {
                return query.Where(b => b.IsBestSeller == IsBestSeller);
            }
            return query;
        }

        private IQueryable<Book> GetAuthorFilter(IQueryable<Book> query)
        {
            if (AuthorId != null)
            {
                return query.Where(b => b.Author.Id == AuthorId);
            }
            return query;
        }

        private IQueryable<Book> GetPeriodFilter(IQueryable<Book> query)
        {
            if (PublicationYear != null)
            {
                switch (PeriodRelativeToPublicationYear)
                {
                    case Period.AfterOrEqual:
                        return query.Where(b => b.PublicationYear >= PublicationYear);
                    case Period.BeforeOrEqual:
                        return query.Where(b => b.PublicationYear <= PublicationYear);
                    default:
                        throw new NotImplementedException
                            ($"{PeriodRelativeToPublicationYear.ToString()} option is not implemented.");
                }
            }
            return query;
        }
    }
}