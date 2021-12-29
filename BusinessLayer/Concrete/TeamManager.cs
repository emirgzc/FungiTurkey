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
	public class TeamManager : ITeamService
	{
		ITeamDal _teamDal;

		public TeamManager(ITeamDal teamDal)
		{
			_teamDal = teamDal;
		}
		public List<Team> GetAll()
		{
			return _teamDal.GetAll();
		}

		public Team GetByID(int id)
		{
			return _teamDal.Get(x => x.PersonId == id);
		}

		public List<Team> GetStatusTrue()
		{
			return _teamDal.GetAll(x=>x.Status==true);
		}

		public List<Team> GetTeamByID(int id)
		{
			return _teamDal.GetAll(x => x.PersonId == id);
		}

		public void TeamAdd(Team team)
		{
			_teamDal.Add(team);
		}

		public void TeamDelete(Team team)
		{
			_teamDal.Delete(team);
		}

		public void TeamUpdate(Team team)
		{
			_teamDal.Update(team);
		}
	}
}
