﻿using BugTracker.Domain.Entity;
using BugTracker.Domain.Interface.Service;
using Interface.Presentation.Mail_Body;
using Interface.Presentation.Models.User;
using Interface.Presentation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interface.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private IUserService userService;

        public HomeController()
        {
            userService = UserServiceInjection.Create();
        }

        public ActionResult Index()
        {
            if(UserSessionService.IsLogged)
                return View();
            return RedirectToAction("Index", "Login");
        }

        public ActionResult SignIn()
        {

            return RedirectToAction("Index");
        }

        public ActionResult Documentation()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewRegister(RegisterUserViewModel userModel)
        {
            BugTracker.Domain.Entity.User userFound = userService.FindByEmail(userModel.Email);

            if (userFound != null)
            {
                if (userFound.Password != null)
                {
                    ModelState.AddModelError("INVALID_USER", "Email is already in use");
                    return View("Register");
                }
                else
                {
                    ModelState.AddModelError("INVALID_USER", "Email is used with github, you can set a password in your perfil settings");
                    return View("Register");
                }
            }
            else
            {
                BugTracker.Domain.Entity.User user = new User(
                    userModel.Name,
                    userModel.Email,
                    userModel.Password,
                    userModel.Image,
                    null,
                    true,
                    false);

                user = userService.Add(user);

                UserActivation.SendTo(user);

                return RedirectToAction("Index");
            }
        }

        //TODO: (Remover) Exemplo de upload de imagem
        public ActionResult Upload(HttpPostedFileBase file)
        {
            UploadImageService.UploadUserImage(file);

            return RedirectToAction("Index");
        }
    }
}