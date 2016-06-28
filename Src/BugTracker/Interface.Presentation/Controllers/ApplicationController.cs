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
            var application = applicationService.FindByIDUser(1);
            
            return View();
        }
    }
}