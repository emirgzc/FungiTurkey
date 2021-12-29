using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IStatisticService
	{
        List<Statistic> GetAll();
        List<Statistic> GetStatisticByID(int id);
        Statistic GetByID(int id);
        void StatisticAdd(Statistic statistic);
        void StatisticUpdate(Statistic statistic);
        void StatisticDelete(Statistic statistic);
    }
}
