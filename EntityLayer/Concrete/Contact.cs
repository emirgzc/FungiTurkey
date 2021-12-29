using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Contact : IEntity
	{
		[Key]
		public int ContactId { get; set; }
		[StringLength(50)]
		public string Name { get; set; }
		[StringLength(50)]
		public string Surname { get; set; }
		[StringLength(50)]
		public string Email { get; set; }
		[StringLength(100)]
		public string Subject { get; set; }
		[StringLength(50)]
		public string Phone { get; set; }
		public string Message { get; set; }
		public DateTime ContactDate { get; set; }

	}
}
