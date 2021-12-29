using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Sponsor : IEntity
	{
		[Key]
		public int SponsorId { get; set; }
		[StringLength(100)]
		public string SponsorName { get; set; }
		[StringLength(100)]
		public string SponsorWebSite { get; set; }
		[StringLength(80)]
		public string Image { get; set; }
		public bool Status { get; set; }
	}
}
