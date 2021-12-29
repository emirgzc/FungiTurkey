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
	public class AboutController : Controller
	{
		AboutValidator validationRules = new AboutValidator();
		TeamValidator validationRules2 = new TeamValidator();
		AboutManager abm = new AboutManager(new EfAboutDal());
		TeamManager tm = new TeamManager(new EfTeamDal());
		Context c = new Context();
		[AllowAnonymous]
		public ActionResult Index()
		{
			var aboutlist = abm.GetAll();
			return View(aboutlist);
		}
		[AllowAnonymous]
		public PartialViewResult TeamList()
		{
			var teamlist = tm.GetStatusTrue();
			return PartialView(teamlist);
		}
		public ActionResult AAboutList()
		{
			var aboutlist = abm.GetAll();
			return View(aboutlist);
		}
		[HttpGet]
		public ActionResult AAboutUpdate(int id)
		{
			var aboutid = abm.GetByID(id);
			return View(aboutid);
		}
		[HttpPost]
		[ValidateInput(false)]
		public ActionResult AAboutUpdate(About a)
		{
			ValidationResult result = validationRules.Validate(a);

			if (result.IsValid)
			{
				abm.AboutUpdate(a);
				return RedirectToAction("AAboutList");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}
		public ActionResult ATeamList()
		{
			var listteam = tm.GetAll();
			return View(listteam);
		}
		[HttpGet]
		public ActionResult ANewTeam()
		{
			return View();
		}
		[HttpPost]
		public ActionResult ANewTeam(Team b)
		{
			ValidationResult result = validationRules2.Validate(b);

			string filename = Path.GetFileName(Request.Files[0].FileName);
			string uzanti = Path.GetExtension(Request.Files[0].FileName);
			Random rand = new Random();
			filename = DateTime.Now.ToShortDateString() + "-" + rand.Next(0, 9999999).ToString() + uzanti;
			string way = "~/Image/Team/" + filename;
			b.Image = "/Image/Team/" + filename;


			if (Request.Files.Count > 0)
			{
				if (uzanti.ToLower() == ".jpg" || uzanti.ToLower() == ".jpeg" || uzanti.ToLower() == ".png")
				{
					if (result.IsValid)
					{
						Request.Files[0].SaveAs(Server.MapPath(way));
						b.Status = false;
						tm.TeamAdd(b);
						return RedirectToAction("ATeamList");
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
		public ActionResult ATeamDelete(int id)
		{
			var idgal = tm.GetByID(id);
			var filename = Request.MapPath("~" + idgal.Image);
			if (System.IO.File.Exists(filename))
			{
				System.IO.File.Delete(filename);
			}
			tm.TeamDelete(idgal);
			return RedirectToAction("ATeamList");
		}
		public ActionResult ATeamDoFalse(int id)
		{
			var idser = tm.GetByID(id);
			idser.Status = false;
			tm.TeamUpdate(idser);
			return RedirectToAction("ATeamList");
		}
		public ActionResult ATeamDoTrue(int id)
		{
			var idser = tm.GetByID(id);
			idser.Status = true;
			tm.TeamUpdate(idser);
			return RedirectToAction("ATeamList");
		}
		[HttpGet]
		public ActionResult ATeamUpdate(int id)
		{
			var idserv = tm.GetByID(id);
			return View(idserv);
		}
		[HttpPost, ValidateInput(false)]
		public ActionResult ATeamUpdate(Team s)
		{
			ValidationResult result = validationRules2.Validate(s);

			string filename = Path.GetFileName(Request.Files[0].FileName);
			string uzanti = Path.GetExtension(Request.Files[0].FileName);
			Random rand = new Random();
			filename = DateTime.Now.ToShortDateString() + "-" + rand.Next(0, 9999999).ToString() + uzanti;
			string way = "~/Image/Team/" + filename;
			s.Image = "/Image/Team/" + filename;

			if (Request.Files.Count > 0)
			{
				if (uzanti.ToLower() == ".jpg" || uzanti.ToLower() == ".jpeg" || uzanti.ToLower() == ".png")
				{
					if (result.IsValid)
					{
						Request.Files[0].SaveAs(Server.MapPath(way));
						s.Status = false;
						tm.TeamUpdate(s);
						return RedirectToAction("ATeamList");
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
					string resim = c.Teams.Where(x => x.PersonId == s.PersonId).Select(z => z.Image).FirstOrDefault();
					s.Image = resim;
					s.Status = false;
					tm.TeamUpdate(s);
					return RedirectToAction("ATeamList");
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