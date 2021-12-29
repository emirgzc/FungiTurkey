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
	public class ActivityManager:IActivityService
	{
		IActivityDal _activityDal;

		public ActivityManager(IActivityDal activityDal)
		{
			_activityDal = activityDal;
		}

		public void ActivityDelete(Activity activity)
		{
			_activityDal.Delete(activity);
		}

		public void ActivitytAdd(Activity activity)
		{
			_activityDal.Add(activity);
		}

		public void ActivityUpdate(Activity activity)
		{
			_activityDal.Update(activity);
		}

		public List<Activity> GetActivityByID(int id)
		{
			return _activityDal.GetAll(x => x.ActId == id);
		}

		public List<Activity> GetAll()
		{
			return _activityDal.GetAll();
		}

		public Activity GetByID(int id)
		{
			return _activityDal.Get(x => x.ActId == id);
		}

		public List<Activity> GetStatusTrue()
		{
			return _activityDal.GetAll(x=>x.StatusAct==true).OrderByDescending(z => z.FinishDate).ToList();
		}
	}
}
