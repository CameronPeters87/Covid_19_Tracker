using System.Collections.Generic;

namespace CovidTracker.WebApi.Models
{
    public class CovidModel
    {
        public virtual GlobalViewModel Global { get; set; }
        public IEnumerable<CountryViewModel> Countries { get; set; }
    }
}