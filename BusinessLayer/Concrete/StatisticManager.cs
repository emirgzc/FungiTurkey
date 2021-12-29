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
	public class StatisticManager:IStatisticService
	{
		IStatisticDal _statisticDal;

		public StatisticManager(IStatisticDal statisticDal)
		{
			_statisticDal = statisticDal;
		}

		public List<Statistic> GetAll()
		{
			return _statisticDal.GetAll();
		}

		public Statistic GetByID(int id)
		{
			return _statisticDal.Get(x => x.StatId == id);
		}

		public List<Statistic> GetStatisticByID(int id)
		{
			return _statisticDal.GetAll(x => x.StatId == id);
		}

		public void StatisticAdd(Statistic statistic)
		{
			_statisticDal.Add(statistic);
		}

		public void StatisticDelete(Statistic statistic)
		{
			_statisticDal.Delete(statistic);
		}

		public void StatisticUpdate(Statistic statistic)
		{
			_statisticDal.Update(statistic);
		}
	}
}
