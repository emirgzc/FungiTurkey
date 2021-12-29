using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IActivityCommentService
	{
        List<ActivityComment> GetAll();
        List<ActivityComment> GetCommentByActId(int id);
        List<ActivityComment> GetCommentByActIdAndStatusTrue(int id);
        List<ActivityComment> GetActivityCommentByID(int id);
        ActivityComment GetByID(int id);
        void ActivityCommentAdd(ActivityComment activityComment);
        void ActivityCommentUpdate(ActivityComment activityComment);
        void ActivityCommentDelete(ActivityComment activityComment);
    }
}
