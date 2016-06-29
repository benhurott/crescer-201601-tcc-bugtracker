using BugTracker.Domain.Entity;
using BugTracker.Domain.Interface.Service;
using Interface.Presentation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interface.Presentation.Controllers
{
    public class ActivationController : Controller
    {
        private IActivationService activationService;

        private IUserService userService;

        public ActivationController()
        {
            this.activationService = ActivationServiceInjection.Create();
            this.userService = UserServiceInjection.Create();
        }

        [HttpGet]
        public ActionResult Code(string code)
        {
            Activation activation = activationService.FindByCode(code);

            if (activation != null)
            {
                User user = activation.User;

                userService.ActiveAccount(user);

                activationService.Remove(activation.IDActivation);

                ViewBag.Activation = "Your account was successively activated ViewBag";
                TempData["Activation"] = "Your account was successively activated TMPDATA";
            }

            return RedirectToAction("Index", "Home");
        }
    }
}