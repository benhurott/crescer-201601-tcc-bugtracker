using BugTracker.Domain.Entity;
using BugTracker.Domain.Interface.Service;
using BugTracker.Domain.Service;
using Interface.Presentation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interface.Presentation.Controllers
{
    public class UserController : Controller
    {
        private IApplicationService applicationService;

        public UserController()
        {
            applicationService = ApplicationServiceInjection.Create();
        }
        

        public ActionResult Home()
        {
            var model = applicationService.FindByIDUser(UserSessionService.LoggedUser.IDUser);

            return View(model);
        }

        public ActionResult Search(String name)
        {
            var model = applicationService.FindByName(name);

            return View( model);
        }

        public ActionResult Account()
        {
            return View();
        }

        public ActionResult Download()
        {
            return View();
        }

        public ActionResult Documentation()
        {
            return View();
        }
    }
}