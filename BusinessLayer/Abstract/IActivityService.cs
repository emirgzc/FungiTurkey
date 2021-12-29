using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IActivityService
	{
        List<Activity> GetAll();
        List<Activity> GetStatusTrue();
        List<Activity> GetActivityByID(int id);
        Activity GetByID(int id);
        void ActivitytAdd(Activity activity);
        void ActivityUpdate(Activity activity);
        void ActivityDelete(Activity activity);
    }
}
