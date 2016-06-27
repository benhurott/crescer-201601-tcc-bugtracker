using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Interface.Presentation.Controllers
{
    public class BugTrackerController : ApiController
    {
        // GET: api/BugTracker
        public IEnumerable<string> Get()
        {
            var request =  HttpContext.Current.Request;
            var browser = request.Browser.ToString();
            var browserVersion = request.Browser.Version;
            var SO = request.Browser.Platform;

                String url = HttpContext.Current.Request.Url.AbsoluteUri;
            // http://localhost:1302/TESTERS/Default6.aspx

            string path = HttpContext.Current.Request.Url.AbsolutePath;
            // /TESTERS/Default6.aspx

            string host = HttpContext.Current.Request.Url.Host;
            return new string[] { "value1", "value2" };
        }

        // POST: api/BugTracker
        public void Post([FromBody]string value)
        {

        }
    }
}
