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
	public class SponsorController : Controller
	{
		SponsorValidator validationRules = new SponsorValidator();
		SponsorManager sm = new SponsorManager(new EfSponsorDal());
		Context c = new Context();
		[AllowAnonymous]
		public ActionResult Index()
		{
			var sponsorlist = sm.GetStatusTrue();
			return View(sponsorlist);
		}
		public ActionResult ASponsorList()
		{
			var list = sm.GetAll();
			return View(list);
		}
		[HttpGet]
		public ActionResult AAddSponsor()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AAddSponsor(Sponsor s)
		{
			ValidationResult result = validationRules.Validate(s);

			string filename = Path.GetFileName(Request.Files[0].FileName);
			string uzanti = Path.GetExtension(Request.Files[0].FileName);
			Random rand = new Random();
			filename = DateTime.Now.ToShortDateString() + "-" + rand.Next(0, 9999999).ToString() + uzanti;
			string way = "~/Image/Sponsor/" + filename;
			s.Image = "/Image/Sponsor/" + filename;

			if (Request.Files.Count > 0)
			{
				if (uzanti.ToLower() == ".jpg" || uzanti.ToLower() == ".jpeg" || uzanti.ToLower() == ".png")
				{
					if (result.IsValid)
					{
						Request.Files[0].SaveAs(Server.MapPath(way));
						s.Status = true;
						sm.SponsorAdd(s);
						return RedirectToAction("ASponsorList");
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
		public ActionResult ASponsorDoTrue(int id)
		{
			var idser = sm.GetByID(id);
			idser.Status = true;
			sm.SponsorUpdate(idser);
			return RedirectToAction("ASponsorList");
		}
		public ActionResult ASponsorDoFalse(int id)
		{
			var idser = sm.GetByID(id);
			idser.Status = false;
			sm.SponsorUpdate(idser);
			return RedirectToAction("ASponsorList");
		}

		public ActionResult ASponsorDelete(int id)
		{
			var idgal = sm.GetByID(id);
			var filename = Request.MapPath("~" + idgal.Image);
			if (System.IO.File.Exists(filename))
			{
				System.IO.File.Delete(filename);
			}
			sm.SponsorDelete(idgal);
			return RedirectToAction("ASponsorList");
		}
		[HttpGet]
		public ActionResult ASponsorUpdate(int id)
		{
			var idserv = sm.GetByID(id);
			return View(idserv);
		}
		[HttpPost, ValidateInput(false)]
		public ActionResult ASponsorUpdate(Sponsor s)
		{
			ValidationResult result = validationRules.Validate(s);

			string filename = Path.GetFileName(Request.Files[0].FileName);
			string uzanti = Path.GetExtension(Request.Files[0].FileName);
			Random rand = new Random();
			filename = DateTime.Now.ToShortDateString() + "-" + rand.Next(0, 9999999).ToString() + uzanti;
			string way = "~/Image/Sponsor/" + filename;
			s.Image = "/Image/Sponsor/" + filename;

			if (Request.Files.Count > 0)
			{
				if (uzanti.ToLower() == ".jpg" || uzanti.ToLower() == ".jpeg" || uzanti.ToLower() == ".png")
				{
					if (result.IsValid)
					{
						Request.Files[0].SaveAs(Server.MapPath(way));
						s.Status = false;
						sm.SponsorUpdate(s);
						return RedirectToAction("ASponsorList");
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
			if (!System.IO.File.Exists(s.Image))
			{
				if (result.IsValid)
				{
					string resim = c.Sponsors.Where(x => x.SponsorId == s.SponsorId).Select(z => z.Image).FirstOrDefault();
					s.Image = resim;
					s.Status = false;
					sm.SponsorUpdate(s);
					return RedirectToAction("ASponsorList");
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