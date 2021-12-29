using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ISponsorService
	{
        List<Sponsor> GetAll();
        List<Sponsor> GetStatusTrue();
        List<Sponsor> GetSponsorByID(int id);
        Sponsor GetByID(int id);
        void SponsorAdd(Sponsor sponsor);
        void SponsorUpdate(Sponsor sponsor);
        void SponsorDelete(Sponsor sponsor);
    }
}
