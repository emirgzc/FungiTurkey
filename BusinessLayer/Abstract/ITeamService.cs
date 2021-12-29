using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ITeamService
	{
        List<Team> GetAll();
        List<Team> GetStatusTrue();
        List<Team> GetTeamByID(int id);
        Team GetByID(int id);
        void TeamAdd(Team team);
        void TeamUpdate(Team team);
        void TeamDelete(Team team);
    }
}
