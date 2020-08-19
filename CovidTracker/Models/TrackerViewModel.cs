namespace CovidTracker.Models
{
    public class TrackerViewModel
    {
        public CountryViewModel Country_SouthAfrica { get; set; }

        //South Africa Stats
        public string RSA_TotalConfirmed { get; set; }
        public string RSA_TotalRecovered { get; set; }
        public string RSA_TotalDeaths { get; set; }

    }
}