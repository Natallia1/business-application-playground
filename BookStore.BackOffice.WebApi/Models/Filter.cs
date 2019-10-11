using System;
using BookStore.BackOffice.WebApi.Enums;

namespace BookStore.BackOffice.WebApi.Models
{
    public class Filter
    {
        public int? PublicationYear { get; set; }
        public Period? PeriodRelativeToPublicationYear { get; set; }
        public bool? IsBestSeller { get; set; }
        public int? AuthorId { get; set; }

        public Func<Author, bool> GetAuthorFilters()
        {
            var author = GetAuthorIdFilter();
            return a => author(a);
        }

        public Func<Book, bool> GetBookFilters()
        {
            var isBestseller = GetIsBestsellerFilter();
            var period = GetPeriodFilter();

            return b => isBestseller(b) && period(b); 
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

        private Func<Author, bool> GetAuthorIdFilter()
        {
            if(AuthorId!=null)
            {
                return (a => a.Id == AuthorId);
            }
            return null;
        }
    }
}