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
                var app = applicationService.FindById((int)id);
                var model = new ApplicationModel();
                model.Id = app.IDApplication;
                model.Title = app.Title;
                model.Description = app.Description;
                model.Icon = app.Image;
                model.Tag = app.SpecialTag;

                return View("register-app", model);
            }

            return View("register-app");
        }

        public ActionResult NewEditApp(ApplicationModel model)
        {

            //TODO pegar id do usuario da sessao
            var user = userService.FindById(1);

            var app = new Application(model.Title, model.Description,
                                      model.Url, true, "imagem",
                                      model.Tag, user);


            if (model.Id.HasValue)
            {
                //edit
            }
            else
            {
                applicationService.Add(app);
            }
            
            return View();
        }

        
    }
}