using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Statistic : IEntity
	{
		[Key]
		public int StatId { get; set; }
		[StringLength(50)]
		public string Title { get; set; }
		[StringLength(10)]
		public string Value { get; set; }
		public string About { get; set; }
		public bool Status { get; set; }
	}
}
