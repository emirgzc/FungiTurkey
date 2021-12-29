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
	public class MemberLoginManager : IMemberLoginService
	{
		IMemberDal _memberDal;

		public MemberLoginManager(IMemberDal memberDal)
		{
			_memberDal = memberDal;
		}

		public Member GetMember(string email, string password)
		{
			return _memberDal.Get(p=>p.Email==email && p.Password==password);
		}

		public Member GetMemberEmail(string email)
		{
			return _memberDal.Get(p => p.Email == email);
		}
	}
}
