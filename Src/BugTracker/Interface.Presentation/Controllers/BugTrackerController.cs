using BugTracker.Domain.Interface.Service;
using Interface.Presentation.Services;
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
        private IBugTrackerService bugTrackerService;
        private IApplicationService applicationService;

        public BugTrackerController()
        {
            bugTrackerService = BugTrackerServiceInjection.Create();
            applicationService = ApplicationServiceInjection.Create();
        }

        // GET: api/BugTracker
        public IEnumerable<string> Get()
        {
            var t = applicationService.FindByUrl("dasd");

            //asd
            //var request =  HttpContext.Current.Request;
            //var browser = request.Browser.Browser;
            //var browserVersion = request.Browser.Version;
            //var SO = request.Browser.Platform;
            //string host = HttpContext.Current.Request.Url.Host;

            return new string[] { "value1", "value2" };
        }
    }
}
