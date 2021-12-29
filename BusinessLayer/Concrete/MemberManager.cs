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
	public class MemberManager : IMemberService
	{
		IMemberDal _memberDal;

		public MemberManager(IMemberDal memberDal)
		{
			_memberDal = memberDal;
		}
		public List<Member> GetAll()
		{
			return _memberDal.GetAll();
		}

		public Member GetByID(int id)
		{
			return _memberDal.Get(x => x.MemberId == id);
		}

		public List<Member> GetMemberByID(int id)
		{
			return _memberDal.GetAll(x => x.MemberId == id);
		}
		public void MemberAdd(Member member)
		{
			_memberDal.Add(member);
		}

		public void MemberDelete(Member member)
		{
			_memberDal.Delete(member);
		}

		public void MemberUpdate(Member member)
		{
			_memberDal.Update(member);
		}
	}
}
