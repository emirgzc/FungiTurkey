using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActivityProject.Controllers
{
	public class SettingsController : Controller
	{
		SettingsValidator validationRules = new SettingsValidator();
		SettingsManager sm = new SettingsManager(new EfSettingsDal());
		public ActionResult ASetList()
		{
			var setlist = sm.GetAll();
			return View(setlist);
		}
		[HttpGet]
		public ActionResult ASettingUpdate(int id)
		{
			var set = sm.GetByID(id);
			return View(set);
		}
		[HttpPost]
		public ActionResult ASettingUpdate(Settings a)
		{
			ValidationResult result = validationRules.Validate(a);

			if (result.IsValid)
			{
				a.DeveloperName = "Emir Gözcü";
				sm.SettingsUpdate(a);
				return RedirectToAction("ASetList");
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
	}
}