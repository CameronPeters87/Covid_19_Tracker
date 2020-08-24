using CovidTracker.APIModels;
using CovidTracker.Extensions;
using CovidTracker.Models;
using Geocoding;
using Geocoding.Google;
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
        private string baseUrlNews = "http://newsapi.org/";
        private IGeocoder geocoder = new GoogleGeocoder() { ApiKey = "AIzaSyCPWzQ0h1vedStiQWFQ5Ez1Jf2f1rj209Q" };
        private ApplicationDbContext db = new ApplicationDbContext();
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
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            SummaryViewModel summary = new SummaryViewModel();
            NewsAPI newsAPI = new NewsAPI();
            TrackerViewModel tracker = new TrackerViewModel();

            #region HttpClient Config
            // Covid Stats
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
            // South Africa News
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrlNews);

                HttpResponseMessage responseMessage = await client.GetAsync("v2/top-headlines?country=za&category=health&apiKey=8066df69f5c2435c9a6b0510ea7b16d5");

                if (responseMessage.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var newsResponse = responseMessage.Content
                        .ReadAsStringAsync().Result;

                    newsAPI = JsonConvert.DeserializeObject<NewsAPI>(newsResponse);
                }
            }
            #endregion

            NewsViewModel news = new NewsViewModel
            {
                Articles = newsAPI.Articles.ToList()
            };

            tracker.FillTrackerModel(summary, news);

            var latLongTableExists = await summary.CheckDBForLatLongExists(db, geocoder);

            if (latLongTableExists)
            {
                ViewBag.DataPoints = db.LatLongDtos.ToList();
            }

            watch.Stop();
            _ = watch.ElapsedMilliseconds;
            _ = watch.Elapsed;

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