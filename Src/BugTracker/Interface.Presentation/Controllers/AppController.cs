using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interface.Presentation.Controllers
{
    public class AppController : Controller
    {
        // GET: App
        public ActionResult AppList()
        {
            var ap1 = new Models.ApplicationModel();
            ap1.Title = "FakeBook";

            var ap2 = new Models.ApplicationModel();
            ap2.Title = "Xml Reader";
            
            return View();
        }
    }
}