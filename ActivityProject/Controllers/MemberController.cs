using ActivityProject.Utilities;
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
using System.Web.Security;

namespace ActivityProject.Controllers
{
	public class MemberController : Controller
	{
		MemberManager mb = new MemberManager(new EfMemberDal());
		RecordManager rm = new RecordManager(new EfRecordDal());
		BlogCommentManager bcm = new BlogCommentManager(new EfBlogCommentDal());
		ActivityCommentManager acm = new ActivityCommentManager(new EfActivityCommentDal());
		MessageManager mm = new MessageManager(new EfMessageDal());
		MemberValidator validationRules = new MemberValidator();
		MessageValidator validationRules2 = new MessageValidator();
		Context c = new Context();
		[HttpGet]
		public ActionResult MemberProfile(int id = 0)
		{
			string p = (string)Session["Email"];
			id = c.Members.Where(x => x.Email == p).Select(z => z.MemberId).FirstOrDefault();
			var memberid = mb.GetByID(id);
			return View(memberid);
		}
		[HttpPost]
		public ActionResult MemberProfile(Member w)
		{
			ValidationResult results = validationRules.Validate(w);
			string p = (string)Session["Email"];
			if (w.Password == null)
			{
				string pass = c.Members.Where(x => x.Email == p).Select(z => z.Password).FirstOrDefault();
				w.Password = pass;
				mb.MemberUpdate(w);
				FormsAuthentication.SignOut();
				Session.Abandon();
				return RedirectToAction("Index", "MemberLogin");
			}
			else
			{
				string sifrelipas = Sifrele.MD5Olustur(w.Password);
				w.Password = sifrelipas;
				mb.MemberUpdate(w);
				FormsAuthentication.SignOut();
				Session.Abandon();
				return RedirectToAction("Index", "MemberLogin");
			}
		}
		public ActionResult MemberRecordList(int id = 0)
		{
			string p = (string)Session["Email"];
			id = c.Members.Where(x => x.Email == p).Select(z => z.MemberId).FirstOrDefault();
			var list = c.Records.Include(x => x.Activity).Where(z => z.MemberId == id).OrderByDescending(y => y.RecordDate).ToList();
			return View(list);
		}
		public ActionResult MemberBlogComList(int id = 0)
		{
			string p = (string)Session["Email"];
			id = c.Members.Where(x => x.Email == p).Select(z => z.MemberId).FirstOrDefault();
			var list = c.BlogComments.Include(x => x.Blog).Where(z => z.MemberId == id).OrderByDescending(y => y.CommentDate).ToList();
			return View(list);
		}
		[HttpGet]
		public ActionResult MemberBlogComUpdate(int id)
		{
			var idcom = bcm.GetByID(id);
			return View(idcom);
		}
		[HttpPost]
		public ActionResult MemberBlogComUpdate(BlogComment b)
		{
			string emailmem = (string)Session["Email"];
			var membername = c.Members.Where(x => x.Email == emailmem).Select(z => z.Name).FirstOrDefault();
			var membersurname = c.Members.Where(x => x.Email == emailmem).Select(z => z.Surname).FirstOrDefault();
			var memberemail = c.Members.Where(x => x.Email == emailmem).Select(z => z.Email).FirstOrDefault();
			b.Status = false;
			b.Name = membername;
			b.Surname = membersurname;
			b.Email = memberemail;
			b.CommentDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
			bcm.BlogCommentUpdate(b);
			return RedirectToAction("MemberBlogComList");
		}
		public ActionResult MemberBlogComDelete(int id)
		{
			var idblgcom = bcm.GetByID(id);
			bcm.BlogCommentDelete(idblgcom);
			return RedirectToAction("MemberBlogComList");
		}
		public ActionResult MemberActivityComList(int id = 0)
		{
			string p = (string)Session["Email"];
			id = c.Members.Where(x => x.Email == p).Select(z => z.MemberId).FirstOrDefault();
			var list = c.ActivityComments.Include(x => x.Activity).Where(z => z.MemberId == id).OrderByDescending(y => y.CommentDate).ToList();
			return View(list);
		}
		[HttpGet]
		public ActionResult MemberActivityComUpdate(int id)
		{
			var idcom = acm.GetByID(id);
			return View(idcom);
		}
		[HttpPost]
		public ActionResult MemberActivityComUpdate(ActivityComment b)
		{
			string emailmem = (string)Session["Email"];
			var membername = c.Members.Where(x => x.Email == emailmem).Select(z => z.Name).FirstOrDefault();
			var membersurname = c.Members.Where(x => x.Email == emailmem).Select(z => z.Surname).FirstOrDefault();
			var memberemail = c.Members.Where(x => x.Email == emailmem).Select(z => z.Email).FirstOrDefault();
			b.Status = false;
			b.Name = membername;
			b.Surname = membersurname;
			b.Email = memberemail;
			b.CommentDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
			acm.ActivityCommentUpdate(b);
			return RedirectToAction("MemberActivityComList");
		}
		public ActionResult MemberActivityComDelete(int id)
		{
			var idactcom = acm.GetByID(id);
			acm.ActivityCommentDelete(idactcom);
			return RedirectToAction("MemberActivityComList");
		}
		//public ActionResult MemberContactInbox()
		//{
		//	string mail = (string)Session["Email"];
		//	var messagelist = mm.GetInboxMessage(mail);
		//	return View(messagelist);
		//}
		//public ActionResult MemberContactInboxDetails(int id)
		//{
		//	var mesdetails = mm.GetMessageById(id);
		//	return View(mesdetails);
		//}
		//public ActionResult MemberContactSendbox()
		//{
		//	string mail = (string)Session["Email"];
		//	var messagelist = mm.GetSendboxMessage(mail);
		//	return View(messagelist);
		//}
		//public ActionResult MemberContactSendboxDetails(int id)
		//{
		//	var mesdetails = mm.GetMessageById(id);
		//	return View(mesdetails);
		//}
		//[HttpGet]
		//public ActionResult NewMessage()
		//{
		//	string email = (string)Session["Email"];
		//	ViewBag.emailmem = email;
		//	return View();
		//}
		//[HttpPost]
		//public ActionResult NewMessage(Message m)
		//{
		//	ValidationResult results = validationRules2.Validate(m);
		//	if (results.IsValid)
		//	{
		//		string email = (string)Session["Email"];
		//		m.SenderMail = email;
		//		m.MessageDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
		//		mm.MessageAdd(m);
		//		return RedirectToAction("MemberContactSendbox");
		//	}
		//	else
		//	{
		//		foreach (var item in results.Errors)
		//		{
		//			ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
		//		}
		//	}
		//	return View();
		//}
		public ActionResult AMemberList()
		{
			var listmem = mb.GetAll();
			var memberCount = mb.GetAll().Count();
			ViewBag.membercountt = memberCount;
			return View(listmem);
		}
		public ActionResult AMemberDelete(int id)
		{
			var memid = mb.GetByID(id);
			mb.MemberDelete(memid);
			return RedirectToAction("AMemberList");
		}
	}
}