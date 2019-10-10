using System.Collections.Generic;

namespace BookStore.BackOffice.WebApi.Models
{
    public class Filter
    {
        public int PublicationYear { get; set; }
        public Period PeriodRelativeToPublicationYear { get; set; }
        public bool IsBestSeller { get; set; }
        public List<Author> Author { get; set; }
    }

    public enum Period
    {
        BeforeOrEqual,
        AfterOrEqual
    }
}