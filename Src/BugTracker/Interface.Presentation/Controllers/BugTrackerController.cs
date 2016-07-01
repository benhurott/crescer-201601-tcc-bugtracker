using BugTracker.Domain.Interface.Service;
using Interface.Presentation.Extensions;
using Interface.Presentation.Filters;
using Interface.Presentation.Models.BugTracker;
using Interface.Presentation.Services;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain = BugTracker.Domain;


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

        [HttpPost]
        public JsonResult Add(BugTrackerPostModel bugTrackerPostModel)
        {
            var request = HttpContext.Request;

            var application = 
                applicationService.FindByUrlAndUserHashCode(
                    HttpContext.Request.Url.Host,
                    bugTrackerPostModel.HashCode
                 );

            if (application == null)
            {
                throw new HttpException(
                    (int)HttpStatusCode.BadRequest,
                    "Domain invalid or Libray broke. Verify your domain in painel and donwload again library."
                );
            }

            if (!ModelState.IsValid)
            {
                throw new HttpException(
                    (int)HttpStatusCode.BadRequest,
                    string.Join("; ", ModelState.Values
                        .SelectMany(x => x.Errors)
                        .Select(x => x.ErrorMessage)
                    )
                );
            }

            try
            {
                bugTrackerService.Add(
                    new Domain.Entity.BugTracker(
                        application,
                        bugTrackerPostModel.Status,
                        bugTrackerPostModel.Trace,
                        DateTime.Now,
                        bugTrackerPostModel.ToTrackerTag(),
                        new Domain.Entity.Browser(request.Browser.Browser, request.Browser.Version),
                        new Domain.Entity.OperationalSystem(request.Browser.Platform)
                    )
                );

                return Json(new { info = "Success!" });
            }
            catch (Domain.Exceptions.TagVeryLargeException e)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, e.ToString());
            }
            catch (Exception e)
            {
                throw new HttpException((int)HttpStatusCode.InternalServerError, e.ToString());
            }
        }

        [HttpGet]
        public ActionResult GetBugTrackerPaginedByApp(int idApplication, int page)
        {
            int limit = 30;

            var bugTrackers = bugTrackerService.FindByApplicationPagined(idApplication, limit, page);

            return PartialView("_bug-trackers-application", bugTrackers.FromModel());
        }

        [HttpGet]
        public JsonResult GetCountBugTrackerByApp(int idApplication)
        {
            return Json(new { count = bugTrackerService.GetCountBugsByApp(idApplication) }, JsonRequestBehavior.AllowGet); 
        }
    }
}
