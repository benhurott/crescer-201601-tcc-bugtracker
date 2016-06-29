using BugTracker.Domain.Entity;
using BugTracker.Domain.Interface.Service;
using BugTracker.Domain.Service;
using Interface.Presentation.Filters;
using Interface.Presentation.Models.User;
using Interface.Presentation.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interface.Presentation.Controllers
{
    public class UserController : Controller
    {
        private IApplicationService applicationService;

        private IUserService userService;

        public UserController()
        {
            applicationService = ApplicationServiceInjection.Create();
            userService = UserServiceInjection.Create();
        }

        [UserToken]
        [HttpGet]
        public ActionResult Index()
        {
            var apps = applicationService.FindByIDUser(UserSessionService.LoggedUser.IDUser);
            return View(apps);
            
        }

        [UserToken]
        [HttpPost]
        public ActionResult Search(String name)
        {
            var model = applicationService.FindByName(name);

            return View("Index", model);
        }

        [UserToken]
        [HttpGet]
        public ActionResult Account()
        {
            return View();
        }

        [UserToken]
        [HttpGet]
        public ActionResult Download()
        {
            return View();
        }

        [UserToken]
        [HttpGet]
        public FileResult DownloadLibrary(string type)
        {
            string fileName = "cwitracker.js";

            if (type == "uncompressed")
            {
                fileName = "cwitracker_min.js";
            }

            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath("~/Library/") + fileName);

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}