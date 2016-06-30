using BugTracker.Domain.Entity;
using BugTracker.Domain.Interface.Service;
using BugTracker.Domain.Service;
using Interface.Presentation.Mail_Body;
using Interface.Presentation.Models.UserRecovery;
using Interface.Presentation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interface.Presentation.Controllers
{
    public class UserRecoveryController : Controller
    {
        IUserRecoveryService userRecoveryService = UserRecoveryServiceInjection.Create();

        IUserService userService = UserServiceInjection.Create();

        [HttpPost]
        public ActionResult NewPassword(UserRecoveryViewModel userModel)
        {
            UserRecovery userRecovery = userRecoveryService.FindByCode(userModel.IDCode);

            if (userRecovery != null)
            {
                userService.UpdatePassword(userRecovery.RequestUser, userModel.Password);

                TempData["Message"] = "Your passwor has been changed with success, try to login";
            }

                return RedirectToAction("Index","Login");
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View("ForgotPassword");
        }

        [HttpPost]
        public ActionResult ForgotPassword(string email)
        {
            var user = userService.FindByEmail(email);

            if(user != null)
            {
                RecoverPassword.SendTo(user);

                TempData["Message"] = "You will receive an email to change your password in a few minutes";
            }

            else
            {
                TempData["Message"] = "This email is not registred in our website";
            }

            return View("ForgotPassword");
        }

        [HttpGet]
        public ActionResult Code(string code)
        {
            UserRecovery userRecovery = userRecoveryService.FindByCode(code);

            if (userRecovery != null)
            {
                var model = new UserRecoveryViewModel() { IDCode = code};
                return View("UserRecovery",model);
            }

                TempData["Message"] = "This link is no longer valid";

                return RedirectToAction("Index", "Login");
        }
    }
}