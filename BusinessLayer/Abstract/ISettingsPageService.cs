using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ISettingsPageService
	{
        List<SettingsPage> GetAll();
        List<SettingsPage> GetSettingsPageByID(int id);
        SettingsPage GetByID(int id);
        void SettingsPageAdd(SettingsPage settingsPage);
        void SettingsPageUpdate(SettingsPage settingsPage);
        void SettingsPageDelete(SettingsPage settingsPage);
    }
}
