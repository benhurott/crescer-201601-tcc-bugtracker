using BugTracker.Domain.Interface.Service;
using Interface.Presentation.Models.BugTracker;
using Interface.Presentation.Services;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Domain = BugTracker.Domain.Entity;


namespace Interface.Presentation.Controllers
{
    public class BugTrackerController : Controller
    {
        private IBugTrackerService bugTrackerService;
        private IApplicationService applicationService;

        public BugTrackerController()
        {
            bugTrackerService = BugTrackerServiceInjection.Create();
            applicationService = ApplicationServiceInjection.Create();
        }

        public void Add(BugTrackerPostModel bugTrackerPostModel)
        {
            //HttpContext.Request.Url.Host
            var application = applicationService.FindByUrl("dasdasd");
            var request = HttpContext.Request;
            List<Domain.BugTrackerTag> a;
            a = new List<Domain.BugTrackerTag>();
            a.Add(new Domain.BugTrackerTag("teste"));


            bugTrackerService.Add(
                new Domain.BugTracker(
                    application,
                    bugTrackerPostModel.Status,
                    bugTrackerPostModel.Trace,
                    new System.DateTime(),
                    a,
                    new Domain.BugTrackerNavigation(
                        new Domain.Browser(request.Browser.Browser, request.Browser.Version),
                        new Domain.OperationalSystem(request.Browser.Platform)
                    )
                )
             );
        }
    }
}
