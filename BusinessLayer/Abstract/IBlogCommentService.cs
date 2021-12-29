using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IBlogCommentService
	{
        List<BlogComment> GetAll();
        List<BlogComment> GetCommentByBlogId(int id);
        List<BlogComment> GetCommentByBlogIdAndStatusTrue(int id);
        List<BlogComment> GetBlogCommentByID(int id);
        BlogComment GetByID(int id);
        void BlogCommentAdd(BlogComment blogComment);
        void BlogCommentUpdate(BlogComment blogComment);
        void BlogCommentDelete(BlogComment blogComment);
    }
}
