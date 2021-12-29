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
	public class BlogCommentController : Controller
	{
		BlogCommentManager bcm = new BlogCommentManager(new EfBlogCommentDal());
		BlogCommentValidator validationRules = new BlogCommentValidator();
		Context c = new Context();
		[AllowAnonymous]
		public PartialViewResult CommentList(int id)
		{
			var comlist = bcm.GetCommentByBlogIdAndStatusTrue(id);
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
			ViewBag.blogid = id;
			ViewBag.memname = membername;
			ViewBag.memsurname = membersurname;
			ViewBag.mememail = memberemail;
			return PartialView();
		}
		[HttpPost]
		[AllowAnonymous]
		public PartialViewResult LeaveComment(BlogComment a)
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
				bcm.BlogCommentAdd(a);
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
		public ActionResult ABlogCommentList()
		{
			//var list = acm.GetAll();
			var list = c.BlogComments.Include(x => x.Blog).OrderByDescending(z => z.CommentDate).ToList();
			return View(list);
		}
		public ActionResult ABlogCommentDetails(int id)
		{
			var contact = bcm.GetByID(id);
			return View(contact);
		}
		public ActionResult ABlogCommentDelete(int id)
		{
			var contact = bcm.GetByID(id);
			bcm.BlogCommentDelete(contact);
			return RedirectToAction("ABlogCommentList");
		}
		public ActionResult ABlogCommentDoStatusFalse(int id)
		{
			var idser = bcm.GetByID(id);
			idser.Status = false;
			bcm.BlogCommentUpdate(idser);
			return RedirectToAction("ABlogCommentList");
		}
		public ActionResult ABlogCommentDoStatusTrue(int id)
		{
			var idser = bcm.GetByID(id);
			idser.Status = true;
			bcm.BlogCommentUpdate(idser);
			return RedirectToAction("ABlogCommentList");
		}
	}
}