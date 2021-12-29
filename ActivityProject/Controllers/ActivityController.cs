using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActivityProject.Controllers
{
	public class ActivityController : Controller
	{
		ActivityValidator validationRules = new ActivityValidator();
		ActivityManager acm = new ActivityManager(new EfActivityDal());
		SettingsManager sm = new SettingsManager(new EfSettingsDal());
		Context c = new Context();
		[AllowAnonymous]
		public ActionResult Index()
		{
			var actlist = acm.GetStatusTrue();
			return View(actlist);
		}
		[AllowAnonymous]
		public ActionResult ActivityDetails(int id)
		{
			var idact = acm.GetActivityByID(id);
			return View(idact);
		}
		[AllowAnonymous]
		public PartialViewResult ActvSocial()
		{
			var setlist = sm.GetAll();
			return PartialView(setlist);
		}
		public ActionResult AActivityList()
		{
			var list = acm.GetAll().OrderByDescending(z=>z.FinishDate).ToList();
			return View(list);
		}
		[HttpGet]
		public ActionResult ANewAct()
		{
			return View();
		}
		[HttpPost]
		[ValidateInput(false)]
		public ActionResult ANewAct(Activity b)
		{
			ValidationResult result = validationRules.Validate(b);

			string filename = Path.GetFileName(Request.Files[0].FileName);
			string uzanti = Path.GetExtension(Request.Files[0].FileName);
			Random rand = new Random();
			filename = DateTime.Now.ToShortDateString() + "-" + rand.Next(0, 9999999).ToString() + uzanti;
			string way = "~/Image/Activity/" + filename;
			b.Image = "/Image/Activity/" + filename;

			if (Request.Files.Count > 0)
			{
				if (uzanti.ToLower() == ".jpg" || uzanti.ToLower() == ".jpeg" || uzanti.ToLower() == ".png")
				{
					if (result.IsValid)
					{
						Request.Files[0].SaveAs(Server.MapPath(way));
						b.StatusAct = true;
						b.StatusRecord = true;
						acm.ActivitytAdd(b);
						return RedirectToAction("AActivityList");
					}
					else
					{
						foreach (var item in result.Errors)
						{
							ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
						}
					}
				}
				else
				{
					ViewBag.hata = "Dosya uzantısı yükleme için uygun değil. Uygun olan uzantılar : .jpg, .jpeg, .png";
				}
			}
			return View();
		}
		public ActionResult ADeleteActivity(int id)
		{
			var idgal = acm.GetByID(id);
			var filename = Request.MapPath("~" + idgal.Image);
			if (System.IO.File.Exists(filename))
			{
				System.IO.File.Delete(filename);
			}
			acm.ActivityDelete(idgal);
			return RedirectToAction("AActivityList");
		}
		public ActionResult AActivityDoFalse(int id)
		{
			var idser = acm.GetByID(id);
			idser.StatusAct = false;
			acm.ActivityUpdate(idser);
			return RedirectToAction("AActivityList");
		}
		public ActionResult AActivityDoTrue(int id)
		{
			var idser = acm.GetByID(id);
			idser.StatusAct = true;
			acm.ActivityUpdate(idser);
			return RedirectToAction("AActivityList");
		}
		public ActionResult AActivityDoFalseRecord(int id)
		{
			var idser = acm.GetByID(id);
			idser.StatusRecord = false;
			acm.ActivityUpdate(idser);
			return RedirectToAction("AActivityList");
		}
		public ActionResult AActivityDoTrueRecord(int id)
		{
			var idser = acm.GetByID(id);
			idser.StatusRecord = true;
			acm.ActivityUpdate(idser);
			return RedirectToAction("AActivityList");
		}
		[HttpGet]
		public ActionResult AActivityUpdate(int id)
		{
			var idserv = acm.GetByID(id);
			return View(idserv);
		}
		[HttpPost, ValidateInput(false)]
		public ActionResult AActivityUpdate(Activity b)
		{
			ValidationResult result = validationRules.Validate(b);

			string filename = Path.GetFileName(Request.Files[0].FileName);
			string uzanti = Path.GetExtension(Request.Files[0].FileName);

			Random rand = new Random();
			filename = DateTime.Now.ToShortDateString() + "-" + rand.Next(0, 999999999).ToString() + uzanti;

			string way = "~/Image/Activity/" + filename;
			b.Image = "/Image/Activity/" + filename;

			if (Request.Files.Count > 0)
			{
				if (uzanti.ToLower() == ".jpg" || uzanti.ToLower() == ".jpeg" || uzanti.ToLower() == ".png")
				{
					if (result.IsValid)
					{
						Request.Files[0].SaveAs(Server.MapPath(way));
						b.StatusAct = false;
						b.StatusRecord = false;
						acm.ActivityUpdate(b);
						return RedirectToAction("AActivityList");
					}
					else
					{
						foreach (var item in result.Errors)
						{
							ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
						}
					}
				}
				else
				{
					ViewBag.hata = "Dosya uzantısı yükleme için uygun değil. Uygun olan uzantılar : .jpg, .jpeg, .png";
				}
			}
			if (!System.IO.File.Exists(b.Image))
			{
				if (result.IsValid)
				{
					string resim = c.Activities.Where(x => x.ActId == b.ActId).Select(z => z.Image).FirstOrDefault();
					b.Image = resim;
					b.StatusAct = false;
					b.StatusRecord = false;
					acm.ActivityUpdate(b);
					return RedirectToAction("AActivityList");
				}
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
					}
				}
			}
			return View();
		}
	}
}