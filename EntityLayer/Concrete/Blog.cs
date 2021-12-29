using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Blog : IEntity
	{
		[Key]
		public int BlogId { get; set; }
		[StringLength(50)]
		public string Title { get; set; }
		public string Content { get; set; }
		[StringLength(50)]
		public string Image { get; set; }
		[StringLength(50)]
		public string Author { get; set; }
		public DateTime BlogDate { get; set; }
		public bool Status { get; set; }
		public ICollection<BlogComment> BlogComments { get; set; }
	}
}
