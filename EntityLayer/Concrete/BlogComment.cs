using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class BlogComment : IEntity
	{
		[Key]
		public int BlogComId { get; set; }
		[StringLength(50)]
		public string Name { get; set; }
		[StringLength(50)]
		public string Surname { get; set; }
		[StringLength(50)]
		public string Email { get; set; }
		[StringLength(600)]
		public string Comment { get; set; }
		public DateTime CommentDate { get; set; }
		public bool Status { get; set; }
		public int BlogId { get; set; }
		public virtual Blog Blog { get; set; }
		public int MemberId { get; set; }
		public virtual Member Member { get; set; }
	}
}
