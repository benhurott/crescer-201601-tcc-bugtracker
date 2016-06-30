using BugTracker.Domain.Entity;
using BugTracker.Domain.Interface.Service;
using BugTracker.Domain.Service;
using Interface.Presentation.Filters;
using Interface.Presentation.Models.Application;
using Interface.Presentation.Models.User;
using Interface.Presentation.Services;
using Interface.Presentation.Extensions;
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
            var apps = 
                applicationService.FindAppAndBugsByAppId(UserSessionService.LoggedUser.IDUser)
                .toApplicationAndBugsViewModel();

            return View(apps);
        }

        [UserToken]
        [HttpPost]
        public ActionResult Search(String name)
        {
            var model = applicationService.FindAppAndBugsByName(name, UserSessionService.LoggedUser.IDUser)
                .toApplicationAndBugsViewModel(); ;

            return View("Index", model);
        }

        [UserToken]
        [HttpGet]
        public ActionResult Account()
        {
            var user = userService.FindById(UserSessionService.LoggedUser.IDUser);
            var viewModel = new UserEditAccountViewModel();
            viewModel.Name = user.Name;
            viewModel.Email = user.Email;
            viewModel.Id = user.IDUser;
            viewModel.Image = user.Image;

            return View(viewModel);
        }

        [UserToken]
        [HttpPost]
        public ActionResult EditAccount(UserEditAccountViewModel model)
        {
            String fileName = model.Image;
            var apps = new List<Application>();

            if (model.File != null)
            {
                fileName = model.File.FileName;
            }

            var editedAccount = new User(model.Id.Value, model.Name, 
                                         model.Email, null,
                                         fileName, apps, true, true);

            userService.Update(editedAccount);
            UploadImageService.UploadUserImage(model.File);

            return View("index");

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