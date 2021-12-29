using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IGaleryService
	{
        List<Galery> GetAll();
        List<Galery> GetListStatusTrue();
        List<Galery> GetGaleryByID(int id);
        Galery GetByID(int id);
        void GaleryAdd(Galery galery);
        void GaleryUpdate(Galery galery);
        void GaleryDelete(Galery galery);
    }
}
