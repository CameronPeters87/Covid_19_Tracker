using CovidTracker.WebApi.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CovidTracker.WebApi.Controllers
{
    public class CovidController : ApiController
    {
        private string baseUrl = "https://api.covid19api.com/";
        // GET: api/Covid
        public async Task<CovidModel> GetAsync()
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

            CovidModel covid = new CovidModel
            {
                Global = summary.Global,
                Countries = summary.Countries.OrderByDescending(c => c.TotalConfirmed)
            };

            return covid;
        }

        // GET: api/Covid/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Covid
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Covid/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Covid/5
        public void Delete(int id)
        {
        }
    }
}
