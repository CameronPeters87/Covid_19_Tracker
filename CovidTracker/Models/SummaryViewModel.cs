using System.Collections.Generic;

namespace CovidTracker.Models
{
    public class SummaryViewModel
    {
        // Actual Headings in the api with actual property names
        public virtual GlobalViewModel Global { get; set; }
        public IEnumerable<CountryViewModel> Countries { get; set; }

        //
        public IEnumerable<CountryViewModel> SortedCountries { get; set; }

        public int TotalCountries { get; set; }
    }
}