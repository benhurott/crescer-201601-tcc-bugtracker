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

            EditAcccountService.EditUser(model, userService);
            UserSessionService.RefreshSession(model);

            return View("account", model);
            
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
            //TODO: colocar no serviço
            string path = Server.MapPath("~/Library/");
            
            string libraryName = "cwitracker_1_0_0";
            
            int idUser = UserSessionService.LoggedUser.IDUser;
            
            //forma o nome do arquivo: pasta + nome da bibliota + id do usuário logado + extensão da bibliotecas
            string fileUser = path + libraryName + "-" + idUser + ".js";

            if (!System.IO.File.Exists(fileUser))
            {
                var user = userService.FindById(idUser);

                var libraryCode =
                    System.IO.File.ReadAllText(path + libraryName + ".js")
                    .Replace("hash_code_user", "'" + user.HashCode + "'");

                using (StreamWriter w = System.IO.File.AppendText(fileUser))
                {
                    w.WriteLine(libraryCode);
                    w.Close();
                }
            }

            return File(
                System.IO.File.ReadAllBytes(fileUser),
                System.Net.Mime.MediaTypeNames.Application.Octet,
                fileUser
            );
        }
    }
}