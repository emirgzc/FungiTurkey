using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActivityProject.Controllers
{
    public class ErrorPageController : Controller
    {
        [AllowAnonymous]
        public ActionResult Page404()
        {
            return View();
        }
        public ActionResult PageDefault()
		{
            return View();
		}
    }
}