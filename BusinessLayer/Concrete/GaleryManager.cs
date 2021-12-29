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
	public class GaleryManager:IGaleryService
	{
		IGaleryDal _galeryDal;

		public GaleryManager(IGaleryDal galeryDal)
		{
			_galeryDal = galeryDal;
		}

		public void GaleryAdd(Galery galery)
		{
			_galeryDal.Add(galery);
		}

		public void GaleryDelete(Galery galery)
		{
			_galeryDal.Delete(galery);
		}

		public void GaleryUpdate(Galery galery)
		{
			_galeryDal.Update(galery);
		}

		public List<Galery> GetAll()
		{
			return _galeryDal.GetAll();
		}

		public Galery GetByID(int id)
		{
			return _galeryDal.Get(x => x.PhotoId == id);
		}

		public List<Galery> GetGaleryByID(int id)
		{
			return _galeryDal.GetAll(x => x.PhotoId == id);
		}

		public List<Galery> GetListStatusTrue()
		{
			return _galeryDal.GetAll(x=>x.Status==true);
		}
	}
}
