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
	public class SliderController : Controller
	{
		SliderValidator validationRules = new SliderValidator();
		SliderManager sm = new SliderManager(new EfSliderDal());
		Context c = new Context();
		[AllowAnonymous]
		public ActionResult Index()
		{
			var sliderlist = sm.GetListStatusTrue();
			return View(sliderlist);
		}
		public ActionResult ASliderList()
		{
			var list = sm.GetAll().OrderByDescending(z=>z.SliderAddDate).ToList();
			return View(list);
		}
		[HttpGet]
		public ActionResult ANewSlider()
		{
			return View();
		}
		[HttpPost]
		public ActionResult ANewSlider(Slider b)
		{
			ValidationResult result = validationRules.Validate(b);

			string filename = Path.GetFileName(Request.Files[0].FileName);
			string uzanti = Path.GetExtension(Request.Files[0].FileName);
			Random rand = new Random();
			filename = DateTime.Now.ToShortDateString() + "-" + rand.Next(0, 9999999).ToString() + uzanti;
			string way = "~/Image/Slider/" + filename;
			b.Image = "/Image/Slider/" + filename;


			if (Request.Files.Count > 0)
			{
				if (uzanti.ToLower() == ".jpg" || uzanti.ToLower() == ".jpeg" || uzanti.ToLower() == ".png")
				{
					if (result.IsValid)
					{
						Request.Files[0].SaveAs(Server.MapPath(way));
						b.Status = false;
						b.SliderAddDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
						sm.SliderAdd(b);
						return RedirectToAction("ASliderList");
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
		public ActionResult ASliderDelete(int id)
		{
			var idgal = sm.GetByID(id);
			var filename = Request.MapPath("~" + idgal.Image);
			if (System.IO.File.Exists(filename))
			{
				System.IO.File.Delete(filename);
			}
			sm.SliderDelete(idgal);
			return RedirectToAction("ASliderList");
		}
		public ActionResult ASliderDoFalse(int id)
		{
			var idser = sm.GetByID(id);
			idser.Status = false;
			sm.SliderUpdate(idser);
			return RedirectToAction("ASliderList");
		}
		public ActionResult ASliderDoTrue(int id)
		{
			var idser = sm.GetByID(id);
			idser.Status = true;
			sm.SliderUpdate(idser);
			return RedirectToAction("ASliderList");
		}
		[HttpGet]
		public ActionResult ASliderUpdate(int id)
		{
			var idserv = sm.GetByID(id);
			return View(idserv);
		}
		[HttpPost, ValidateInput(false)]
		public ActionResult ASliderUpdate(Slider s)
		{
			ValidationResult result = validationRules.Validate(s);

			string filename = Path.GetFileName(Request.Files[0].FileName);
			string uzanti = Path.GetExtension(Request.Files[0].FileName);
			Random rand = new Random();
			filename = DateTime.Now.ToShortDateString() + "-" + rand.Next(0, 9999999).ToString() + uzanti;
			string way = "~/Image/Slider/" + filename;
			s.Image = "/Image/Slider/" + filename;

			if (Request.Files.Count > 0)
			{
				if (uzanti.ToLower() == ".jpg" || uzanti.ToLower() == ".jpeg" || uzanti.ToLower() == ".png")
				{
					if (result.IsValid)
					{
						Request.Files[0].SaveAs(Server.MapPath(way));
						s.Status = false;
						s.SliderAddDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
						sm.SliderUpdate(s);
						return RedirectToAction("ASliderList");
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
					string resim = c.Sliders.Where(x => x.SliderId == s.SliderId).Select(z => z.Image).FirstOrDefault();
					s.Image = resim;
					s.Status = false;
					s.SliderAddDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
					sm.SliderUpdate(s);
					return RedirectToAction("ASliderList");
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