using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IMemberLoginService
	{
		Member GetMember(string email,string password);
		Member GetMemberEmail(string email);
	}
}
