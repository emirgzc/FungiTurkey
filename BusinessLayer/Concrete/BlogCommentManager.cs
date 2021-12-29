using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class BlogCommentManager : IBlogCommentService
	{
		IBlogCommentDal _blogCommentDal;

		public BlogCommentManager(IBlogCommentDal blogCommentDal)
		{
			_blogCommentDal = blogCommentDal;
		}

		public void BlogCommentAdd(BlogComment blogComment)
		{
			_blogCommentDal.Add(blogComment);
		}

		public void BlogCommentDelete(BlogComment blogComment)
		{
			_blogCommentDal.Delete(blogComment);
		}

		public void BlogCommentUpdate(BlogComment blogComment)
		{
			_blogCommentDal.Update(blogComment);
		}

		public List<BlogComment> GetAll()
		{
			return _blogCommentDal.GetAll();
		}

		public List<BlogComment> GetBlogCommentByID(int id)
		{
			return _blogCommentDal.GetAll(x=>x.BlogComId==id);
		}

		public BlogComment GetByID(int id)
		{
			return _blogCommentDal.Get(x=>x.BlogComId==id);
		}

		public List<BlogComment> GetCommentByBlogId(int id)
		{
			return _blogCommentDal.GetAll(x => x.BlogId == id);
		}

		public List<BlogComment> GetCommentByBlogIdAndStatusTrue(int id)
		{
			return _blogCommentDal.GetAll(x => x.BlogId == id).OrderByDescending(z=>z.CommentDate).Where(c=>c.Status==true).ToList();
		}
	}
}
