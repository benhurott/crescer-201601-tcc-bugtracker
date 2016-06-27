using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interface.Presentation.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
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