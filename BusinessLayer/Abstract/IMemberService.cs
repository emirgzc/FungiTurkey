using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IMemberService
	{
        List<Member> GetAll();
        List<Member> GetMemberByID(int id);
        Member GetByID(int id);
        void MemberAdd(Member member);
        void MemberUpdate(Member member);
        void MemberDelete(Member member);
    }
}
