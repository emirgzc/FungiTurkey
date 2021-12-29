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
	public class SettingsPageManager:ISettingsPageService
	{
		ISettingsPageDal _settingsPageDal;

		public SettingsPageManager(ISettingsPageDal settingsPageDal)
		{
			_settingsPageDal = settingsPageDal;
		}
		public List<SettingsPage> GetAll()
		{
			return _settingsPageDal.GetAll();
		}

		public SettingsPage GetByID(int id)
		{
			return _settingsPageDal.Get(x => x.PageId == id);
		}

		public List<SettingsPage> GetSettingsPageByID(int id)
		{
			return _settingsPageDal.GetAll(x => x.PageId == id);
		}

		public void SettingsPageAdd(SettingsPage settingsPage)
		{
			_settingsPageDal.Add(settingsPage);
		}

		public void SettingsPageDelete(SettingsPage settingsPage)
		{
			_settingsPageDal.Delete(settingsPage);
		}

		public void SettingsPageUpdate(SettingsPage settingsPage)
		{
			_settingsPageDal.Update(settingsPage);
		}
	}
}
