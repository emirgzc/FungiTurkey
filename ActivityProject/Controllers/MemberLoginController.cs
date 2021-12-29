using ActivityProject.Utilities;
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
using System.Web.Security;

namespace ActivityProject.Controllers
{
	[AllowAnonymous]
	public class MemberLoginController : Controller
	{
		Context c = new Context();
		MemberLoginManager mlm = new MemberLoginManager(new EfMemberDal());
		MemberManager mm = new MemberManager(new EfMemberDal());
		MemberValidator validationRules = new MemberValidator();
		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Index(Member p)
		{
			string sifre = Sifrele.MD5Olustur(p.Password);
			var memberuserinfo = mlm.GetMember(p.Email, sifre);
			if (memberuserinfo != null)
			{
				FormsAuthentication.SetAuthCookie(memberuserinfo.Email, false);
				Session["Email"] = memberuserinfo.Email;
				return RedirectToAction("Index", "Slider");
			}
			else
			{
				ViewBag.ErrorMessage = "Kullanıcı Adı veya Şifre Yanlış";
			}
			return View();
		}
		[HttpGet]
		public ActionResult CreateMember()
		{
			return View();
		}
		[HttpPost]
		public ActionResult CreateMember(Member m)
		{
			ValidationResult result = validationRules.Validate(m);
			var ishereemail = c.Members.FirstOrDefault(a => a.Email == m.Email);
			var isherephone = c.Members.FirstOrDefault(a => a.Phone == m.Phone);
			if (ishereemail == null)
			{
				if (isherephone==null)
				{
					if (result.IsValid)
					{
						string sifrele = Sifrele.MD5Olustur(m.Password);
						m.Password = sifrele;
						mm.MemberAdd(m);
						TempData["kayitmem"] = " ";
						return RedirectToAction("Index");
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
					ViewBag.eroor = "Bu telefon numarası sistemde kayıtlı.";
				}
			}
			else
			{
				ViewBag.eroor = "Bu email adresi sistemde kayıtlı.";
			}
			return View();
		}
		public ActionResult LogOut()
		{
			FormsAuthentication.SignOut();
			Session.Abandon();
			return RedirectToAction("Index", "Slider");
		}			
	}
}