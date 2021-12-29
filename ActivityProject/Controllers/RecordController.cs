using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActivityProject.Controllers
{
    public class RecordController : Controller
    {
        RecordManager rm = new RecordManager(new EfRecordDal());
        SettingsManager sm = new SettingsManager(new EfSettingsDal());
        ActivityManager acm = new ActivityManager(new EfActivityDal());
        Context c = new Context();        
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index(int id)
        {
            ViewBag.idact = id;
            string mail = (string)Session["Email"];
            var membermailinfo = c.Members.Where(x => x.Email == mail).Select(z => z.Email).FirstOrDefault();
            var memberphoneinfo = c.Members.Where(x => x.Email == mail).Select(z => z.Phone).FirstOrDefault();
            var membernameinfo = c.Members.Where(x => x.Email == mail).Select(z => z.Name).FirstOrDefault();
            var membersurnameinfo = c.Members.Where(x => x.Email == mail).Select(z => z.Surname).FirstOrDefault();
            ViewBag.mailmem = membermailinfo;
            ViewBag.mailphone = memberphoneinfo;
            ViewBag.mailname = membernameinfo;
            ViewBag.mailsurname = membersurnameinfo;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(Record r)
        {
            string mail = (string)Session["Email"];
            var memberidinfo = c.Members.Where(x => x.Email == mail).Select(z => z.MemberId).FirstOrDefault();
            var membermailinfo = c.Members.Where(x => x.Email == mail).Select(z => z.Email).FirstOrDefault();
            var memberphoneinfo = c.Members.Where(x => x.Email == mail).Select(z => z.Phone).FirstOrDefault();
            var membernameinfo = c.Members.Where(x => x.Email == mail).Select(z => z.Name).FirstOrDefault();
            var membersurnameinfo = c.Members.Where(x => x.Email == mail).Select(z => z.Surname).FirstOrDefault();
            r.Phone = memberphoneinfo;
            r.Email = membermailinfo;
            r.MemberId = memberidinfo;
            r.Name = membernameinfo;
            r.Surname = membersurnameinfo;
            r.RecordDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
            r.Status = false;
            r.StatusPrice = false;
            rm.RecordAdd(r);
            TempData["kayit"] = " ";
            return RedirectToAction("Index", "Activity");
        }
        [AllowAnonymous]
        public PartialViewResult RizaMetni()
        {
            var list = sm.GetAll();
            return PartialView(list);
        }
        public ActionResult AActivityList()
		{
            var reclist = acm.GetStatusTrue();
            return View(reclist);
		}
        public ActionResult ARecordListByActivity(int id)
        {
            var listcount = rm.GetListRecordToActivityId(id).Count();
            ViewBag.countact = listcount;
            //var reclist = rm.GetListRecordToActivityId(id);
            var reclist = c.Records.Include(z=>z.Member).Where(x=>x.ActId==id).OrderByDescending(c=>c.RecordDate).ToList();
            return View(reclist);
        }
        public ActionResult ADeleteRecord(int id)
        {
            var idact = rm.GetByID(id);
            rm.RecordDelete(idact);
            return RedirectToAction("AActivityList");
        }
        public ActionResult ARecordDoFalse(int id)
        {
            var idser = rm.GetByID(id);
            idser.Status = false;
            rm.RecordUpdate(idser);
            return RedirectToAction("AActivityList");
        }
        public ActionResult ARecordDoTrue(int id)
        {
            var idser = rm.GetByID(id);
            idser.Status = true;
            rm.RecordUpdate(idser);
            return RedirectToAction("AActivityList");
        }
        public ActionResult ARecordDoPriceFalse(int id)
        {
            var idser = rm.GetByID(id);
            idser.StatusPrice = false;
            rm.RecordUpdate(idser);
            return RedirectToAction("AActivityList");
        }
        public ActionResult ARecordDoPriceTrue(int id)
        {
            var idser = rm.GetByID(id);
            idser.StatusPrice = true;
            rm.RecordUpdate(idser);
            return RedirectToAction("AActivityList");
        }
    }
}