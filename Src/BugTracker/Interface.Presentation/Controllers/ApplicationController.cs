using BugTracker.Domain.Entity;
using BugTracker.Domain.Interface.Service;
using Interface.Presentation.Models;
using Interface.Presentation.Models.Application;
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
        private IUserService userService;

        public ApplicationController()
        {
            applicationService = ApplicationServiceInjection.Create();
            userService = UserServiceInjection.Create();
        }

        public ActionResult RegisterApp(int? id)
        {
            if (id.HasValue)
            {
                //TODO implementar findById
                if (id.HasValue)
                {
                ICollection<Application> app = applicationService.FindByIDUser(1);

                var model = ApplicationViewModel.CollectionToViewModel(app);
                return View(model);

                }

                return View();

            }

            return View("register-app");
        }

        public ActionResult NewEditApp(ApplicationViewModel model)
        {

            //TODO pegar id do usuario da sessao
            var user = userService.FindById(1);

            var app = new Application(model.Title, model.Description,
                                      model.Url, true, "imagem",
                                      model.SpecialTag, user);

            if (model.IDApplication != 0)
            {
                //TODO implementar edit app
                //applicationService.Edit(app);
            }

            
            applicationService.Add(app);
            return View();
        }

        
    }
}