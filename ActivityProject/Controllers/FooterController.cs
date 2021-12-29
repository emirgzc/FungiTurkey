using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActivityProject.Controllers
{
    [AllowAnonymous]
    public class FooterController : Controller
    {
        SettingsManager sm = new SettingsManager(new EfSettingsDal());
        public PartialViewResult Index()
        {
            var setlist = sm.GetAll();
            return PartialView(setlist);
        }
    }
}