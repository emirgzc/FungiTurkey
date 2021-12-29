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
	public class ActivityCommentManager : IActivityCommentService
	{
		IActivityCommentDal _activityCommentDal;

		public ActivityCommentManager(IActivityCommentDal activityCommentDal)
		{
			_activityCommentDal = activityCommentDal;
		}

		public void ActivityCommentAdd(ActivityComment activityComment)
		{
			_activityCommentDal.Add(activityComment);
		}

		public void ActivityCommentDelete(ActivityComment activityComment)
		{
			_activityCommentDal.Delete(activityComment);
		}

		public void ActivityCommentUpdate(ActivityComment activityComment)
		{
			_activityCommentDal.Update(activityComment);
		}

		public List<ActivityComment> GetActivityCommentByID(int id)
		{
			return _activityCommentDal.GetAll(x => x.ActvtyComId == id);
		}

		public List<ActivityComment> GetAll()
		{
			return _activityCommentDal.GetAll();
		}

		public ActivityComment GetByID(int id)
		{
			return _activityCommentDal.Get(x=>x.ActvtyComId==id);
		}

		public List<ActivityComment> GetCommentByActId(int id)
		{
			return _activityCommentDal.GetAll(x => x.ActId == id);
		}

		public List<ActivityComment> GetCommentByActIdAndStatusTrue(int id)
		{
			return _activityCommentDal.GetAll(x => x.ActId == id).OrderByDescending(z => z.CommentDate).Where(c => c.Status == true).ToList();
		}
	}
}
