using System;
using System.Collections.Generic;
using BookStore.BackOffice.WebApi.Enums;
using BookStore.BackOffice.WebApi.Extensions;

namespace BookStore.BackOffice.WebApi.Models
{
    public class Filter
    {
        private List<Func<Book, bool>> bookFilterList = new List<Func<Book, bool>>();
        private Func<Book, bool> bookFilter = b => true;

        public int? PublicationYear { get; set; }
        public Period? PeriodRelativeToPublicationYear { get; set; }
        public bool? IsBestSeller { get; set; }
        public int? AuthorId { get; set; }

        public Func<Book, bool> GetBookFilters()
        {
            bookFilterList.Add(GetIsBestsellerFilter());
            bookFilterList.Add(GetPeriodFilter());
            bookFilterList.Add(GetAuthorFilter());

            foreach (var filter in bookFilterList)
            {
                if(filter!=null)
                {
                    bookFilter = bookFilter.AndAlso(filter);
                }
            }
            return bookFilter;
        }

        private Func<Book, bool> GetIsBestsellerFilter()
        {
            if(IsBestSeller!=null)
            {
                return (b => b.IsBestSeller == IsBestSeller);
            }
            return null;
        }

        private Func<Book, bool> GetPeriodFilter()
        {
            if (PublicationYear!= null)
            {
                switch(PeriodRelativeToPublicationYear)
                {
                    case Period.AfterOrEqual:
                        return b => b.PublicationYear >= PublicationYear;
                    case Period.BeforeOrEqual:
                        return b => b.PublicationYear <= PublicationYear;
                    default:
                        throw new NotImplementedException
                            ($"{PeriodRelativeToPublicationYear.ToString()} option is not implemented.");         
                }
            }
            return null;
        }

        private Func<Book, bool> GetAuthorFilter()
        {
            if(AuthorId!=null)
            {
                return (b => b.Author.Id == AuthorId);
            }
            return null;
        }

        
    }
}