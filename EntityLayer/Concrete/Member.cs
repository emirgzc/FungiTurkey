using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Member : IEntity
	{
		[Key]
		public int MemberId { get; set; }
		[StringLength(50)]
		public string Name { get; set; }
		[StringLength(50)]
		public string Surname { get; set; }
		[StringLength(50)]
		public string Email { get; set; }
		[StringLength(50)]
		public string Phone { get; set; }
		[StringLength(50)]
		public string City { get; set; }
		public string Job { get; set; }
		public string About { get; set; }
		[StringLength(50)]
		public string Password { get; set; }
		public ICollection<Record> Records { get; set; }
		public ICollection<ActivityComment> ActivityComments { get; set; }
		public ICollection<BlogComment> BlogComments { get; set; }
	}
}
