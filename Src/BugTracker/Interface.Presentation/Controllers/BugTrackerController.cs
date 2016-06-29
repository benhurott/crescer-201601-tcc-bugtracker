using BugTracker.Domain.Interface.Service;
using Interface.Presentation.Models.BugTracker;
using Interface.Presentation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
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

        public JsonResult Add(BugTrackerPostModel bugTrackerPostModel)
        {
            var application = applicationService.FindByUrl(HttpContext.Request.Url.Host);
            var request = HttpContext.Request;

            if (application == null)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Domain request invalid. Verify your domain in painel.");
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
                        DateTime.Today,
                        bugTrackerPostModel.ToTrackerTag(),
                        new Domain.Entity.BugTrackerNavigation(
                            new Domain.Entity.Browser(request.Browser.Browser, request.Browser.Version),
                            new Domain.Entity.OperationalSystem(request.Browser.Platform)
                        )
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
                throw new HttpException((int)HttpStatusCode.InternalServerError, "Error in saving request");
            }
        }
    }
}
