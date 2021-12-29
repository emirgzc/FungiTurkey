using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActivityProject.Controllers
{
	public class GaleryController : Controller
	{
		GaleryValidator validationRules = new GaleryValidator();
		GaleryManager gm = new GaleryManager(new EfGaleryDal());
		[AllowAnonymous]
		public ActionResult Index(int page=1)
		{
			var galerylist = gm.GetListStatusTrue().ToPagedList(page,8);
			return View(galerylist);
		}
		public ActionResult AGaleryList()
		{
			var galery = gm.GetAll();
			return View(galery);
		}
		[HttpGet]
		public ActionResult AGaleryAdd()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AGaleryAdd(Galery g)
		{
			ValidationResult results = validationRules.Validate(g);

			string filename = Path.GetFileName(Request.Files[0].FileName);
			string uzanti = Path.GetExtension(Request.Files[0].FileName);
			Random rand = new Random();
			filename = DateTime.Now.ToShortDateString() + "-" + rand.Next(0, 99999999).ToString() + uzanti;
			string way = "~/Image/Galery/" + filename;
			g.Image = "/Image/Galery/" + filename;

			if (Request.Files.Count > 0)
			{
				if (uzanti.ToLower() == ".jpg" || uzanti.ToLower() == ".jpeg" || uzanti.ToLower() == ".png")
				{
					if (results.IsValid)
					{
						Request.Files[0].SaveAs(Server.MapPath(way));
						g.Status = true;
						gm.GaleryAdd(g);
						return RedirectToAction("AGaleryList");
					}
					else
					{
						foreach (var item in results.Errors)
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
		public ActionResult AGaleryDelete(int id)
		{
			var idgal = gm.GetByID(id);
			var filename = Request.MapPath("~" + idgal.Image);
			if (System.IO.File.Exists(filename))
			{
				System.IO.File.Delete(filename);
			}
			gm.GaleryDelete(idgal);
			return RedirectToAction("AGaleryList");
		}
		public ActionResult AGaleryDoFalse(int id)
		{
			var idser = gm.GetByID(id);
			idser.Status = false;
			gm.GaleryUpdate(idser);
			return RedirectToAction("AGaleryList");
		}
		public ActionResult AGaleryDoTrue(int id)
		{
			var idser = gm.GetByID(id);
			idser.Status = true;
			gm.GaleryUpdate(idser);
			return RedirectToAction("AGaleryList");
		}
	}
}