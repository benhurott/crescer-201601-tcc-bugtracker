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
        private IUserService _userService;

        public UserController()
        {
            _userService = UserServiceInjection.Create();
        }

        public ActionResult Index()
        {
            var a = _userService.FindById(1);

            return View();
        }
    }
}