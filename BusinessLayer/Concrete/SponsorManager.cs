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
	public class SponsorManager:ISponsorService
	{
		ISponsorDal _sponsorDal;

		public SponsorManager(ISponsorDal sponsorDal)
		{
			_sponsorDal = sponsorDal;
		}

		public List<Sponsor> GetAll()
		{
			return _sponsorDal.GetAll();
		}

		public Sponsor GetByID(int id)
		{
			return _sponsorDal.Get(x => x.SponsorId == id);
		}

		public List<Sponsor> GetSponsorByID(int id)
		{
			return _sponsorDal.GetAll(x => x.SponsorId == id);
		}

		public List<Sponsor> GetStatusTrue()
		{
			return _sponsorDal.GetAll(z=>z.Status==true);
		}

		public void SponsorAdd(Sponsor sponsor)
		{
			_sponsorDal.Add(sponsor);
		}

		public void SponsorDelete(Sponsor sponsor)
		{
			_sponsorDal.Delete(sponsor);
		}

		public void SponsorUpdate(Sponsor sponsor)
		{
			_sponsorDal.Update(sponsor);
		}
	}
}
