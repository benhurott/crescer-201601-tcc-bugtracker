using BugTracker.Domain.Interface.Service;
using Interface.Presentation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interface.Presentation.Controllers
{
    public class ApplicationController : Controller
    {
        private IApplicationService applicationService;

        public ApplicationController()
        {
            applicationService = ApplicationServiceInjection.Create();
        }

        public ActionResult AppList()
        {
            var a = applicationService.FindByIDUser(1);

            var ap1 = new Models.ApplicationModel();
            ap1.Title = "FakeBook";

            var ap2 = new Models.ApplicationModel();
            ap2.Title = "Xml Reader";
            
            return View();
        }
    }
}