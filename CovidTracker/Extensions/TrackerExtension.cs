using CovidTracker.Models;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTracker.Extensions
{
    public static class TrackerExtension
    {
        public static async Task FillTrackerModel(this TrackerViewModel tracker,
            SummaryViewModel summary)
        {
            tracker.Country_SouthAfrica = summary.Countries.Where(s => s.Country == "South Africa")
                .FirstOrDefault();

            tracker.RSA_TotalConfirmed = await Helper.FormatIntToString(
                tracker.Country_SouthAfrica.TotalConfirmed);

            tracker.RSA_TotalRecovered = await Helper.FormatIntToString(
                tracker.Country_SouthAfrica.TotalRecovered);

            tracker.RSA_TotalDeaths = await Helper.FormatIntToString(
                tracker.Country_SouthAfrica.TotalDeaths);

            // Global
            tracker.Global_TotalConfirmed = await Helper.FormatIntToString(
                summary.Global.TotalConfirmed);
            tracker.Global_TotalRecovered = await Helper.FormatIntToString(
                summary.Global.TotalRecovered);
            tracker.Global_TotalDeaths = await Helper.FormatIntToString(
                summary.Global.TotalDeaths);
        }
    }
}