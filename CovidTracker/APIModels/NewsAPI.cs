using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovidTracker.APIModels
{
    public class NewsAPI
    {
        public IEnumerable<Article> Articles { get; set; }
    }
}