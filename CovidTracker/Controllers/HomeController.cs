using CovidTracker.Extensions;
using CovidTracker.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CovidTracker.Controllers
{
    public class HomeController : Controller
    {
        private string baseUrl = "https://api.covid19api.com/";

        public async Task<ActionResult> Index()
        {
            SummaryViewModel summary = new SummaryViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                HttpResponseMessage responseMessage = await client.GetAsync("summary");

                if (responseMessage.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var covidResponse = responseMessage.Content
                        .ReadAsStringAsync().Result;

                    summary = JsonConvert.DeserializeObject<SummaryViewModel>(covidResponse);
                }
            }

            summary.Countries.OrderByDescending(c => c.TotalConfirmed).ToList();
            summary.TotalCountries = summary.Countries.Count();
            summary.SortedCountries = summary.Countries.OrderByDescending(c => c.TotalConfirmed).ToList();

            return View(summary);
        }

        public async Task<ActionResult> Tracker()
        {
            SummaryViewModel summary = new SummaryViewModel();
            TrackerViewModel tracker = new TrackerViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                HttpResponseMessage responseMessage = await client.GetAsync("summary");

                if (responseMessage.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var covidResponse = responseMessage.Content
                        .ReadAsStringAsync().Result;

                    summary = JsonConvert.DeserializeObject<SummaryViewModel>(covidResponse);
                }
            }

            tracker.Country_SouthAfrica = summary.Countries.Where(s => s.Country == "South Africa")
                .FirstOrDefault();

            tracker.RSA_TotalConfirmed = await Helper.FormatIntToString(
                tracker.Country_SouthAfrica.TotalConfirmed);

            tracker.RSA_TotalRecovered = await Helper.FormatIntToString(
                tracker.Country_SouthAfrica.TotalRecovered);

            tracker.RSA_TotalDeaths = await Helper.FormatIntToString(
                tracker.Country_SouthAfrica.TotalDeaths);

            return View(tracker);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}