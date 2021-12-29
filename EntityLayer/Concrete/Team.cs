using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Team : IEntity
	{
		[Key]
		public int PersonId { get; set; }
		[StringLength(50)]
		public string Title { get; set; }
		[StringLength(500)]
		public string About { get; set; }
		[StringLength(50)]
		public string Job { get; set; }
		[StringLength(50)]
		public string Image { get; set; }
		[StringLength(50)]
		public string Facebook { get; set; }
		[StringLength(50)]
		public string Twitter { get; set; }
		[StringLength(50)]
		public string Linkedin { get; set; }
		[StringLength(50)]
		public string Instagram { get; set; }
		public bool Status { get; set; }
	}
}
