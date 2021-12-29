using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Services : IEntity
	{
		[Key]
		public int ServicesId { get; set; }
		[StringLength(50)]
		public string Title { get; set; }
		public string Content { get; set; }
		[StringLength(80)]
		public string Image { get; set; }
		public bool Status { get; set; }
	}
}
