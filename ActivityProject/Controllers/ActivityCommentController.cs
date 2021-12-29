using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActivityProject.Controllers
{
	public class ActivityCommentController : Controller
	{
		ActivityCommentManager acm = new ActivityCommentManager(new EfActivityCommentDal());
		ActivityCommentValidator validationRules = new ActivityCommentValidator();
		Context c = new Context();
		[AllowAnonymous]
		public PartialViewResult CommentList(int id)
		{
			var comlist = acm.GetCommentByActIdAndStatusTrue(id);
			return PartialView(comlist);
		}
		[HttpGet]
		[AllowAnonymous]
		public PartialViewResult LeaveComment(int id)
		{
			string emailmem = (string)Session["Email"];
			var memberid = c.Members.Where(x => x.Email == emailmem).Select(z => z.MemberId).FirstOrDefault();
			var membername = c.Members.Where(x => x.Email == emailmem).Select(z => z.Name).FirstOrDefault();
			var membersurname = c.Members.Where(x => x.Email == emailmem).Select(z => z.Surname).FirstOrDefault();
			var memberemail = c.Members.Where(x => x.Email == emailmem).Select(z => z.Email).FirstOrDefault();
			ViewBag.memid = memberid;
			ViewBag.actid = id;
			ViewBag.memname = membername;
			ViewBag.memsurname = membersurname;
			ViewBag.mememail = memberemail;
			return PartialView();

		}
		[HttpPost]
		[AllowAnonymous]
		public PartialViewResult LeaveComment(ActivityComment a)
		{
			ValidationResult result = validationRules.Validate(a);
			if (result.IsValid)
			{
				string emailmem = (string)Session["Email"];
				var memberid = c.Members.Where(x => x.Email == emailmem).Select(z => z.MemberId).FirstOrDefault();
				var membername = c.Members.Where(x => x.Email == emailmem).Select(z => z.Name).FirstOrDefault();
				var membersurname = c.Members.Where(x => x.Email == emailmem).Select(z => z.Surname).FirstOrDefault();
				var memberemail = c.Members.Where(x => x.Email == emailmem).Select(z => z.Email).FirstOrDefault();
				a.MemberId = memberid;
				a.Name = membername;
				a.Surname = membersurname;
				a.Email = memberemail;
				a.Status = false;
				acm.ActivityCommentAdd(a);
				return PartialView();
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return PartialView();
		}
		public ActionResult AActCommentList()
		{
			//var list = acm.GetAll();
			var list = c.ActivityComments.Include(x => x.Activity).OrderByDescending(z => z.CommentDate).ToList();
			return View(list);
		}
		public ActionResult AActCommentDetails(int id)
		{
			var contact = acm.GetByID(id);
			return View(contact);
		}
		public ActionResult AActCommentDelete(int id)
		{
			var contact = acm.GetByID(id);
			acm.ActivityCommentDelete(contact);
			return RedirectToAction("AActCommentList");
		}
		public ActionResult AActCommentDoStatusFalse(int id)
		{
			var idser = acm.GetByID(id);
			idser.Status = false;
			acm.ActivityCommentUpdate(idser);
			return RedirectToAction("AActCommentList");
		}
		public ActionResult AActCommentDoStatusTrue(int id)
		{
			var idser = acm.GetByID(id);
			idser.Status = true;
			acm.ActivityCommentUpdate(idser);
			return RedirectToAction("AActCommentList");
		}
	}
}