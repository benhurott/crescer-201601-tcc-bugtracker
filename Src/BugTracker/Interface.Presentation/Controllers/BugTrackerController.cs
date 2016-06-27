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
        // POST: api/BugTracker
        public IEnumerable<string> Post()
        {
            //var request =  HttpContext.Current.Request;
            //var browser = request.Browser.Browser;
            //var browserVersion = request.Browser.Version;
            //var SO = request.Browser.Platform;
            //string host = HttpContext.Current.Request.Url.Host;

            return new string[] { "value1", "value2" };
        }
    }
}
