using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class SettingsPage : IEntity
	{
		[Key]
		public int PageId { get; set; }
		[StringLength(50)]
		public string ServicesTitle { get; set; }
		public string ServicesAbout { get; set; }
		[StringLength(50)]
		public string GaleryTitle { get; set; }
		public string GaleryAbout { get; set; }
		[StringLength(50)]
		public string SponsorTitle { get; set; }
		public string SponsorAbout { get; set; }
		[StringLength(50)]
		public string ContactTitle { get; set; }
		public string ContactAbout { get; set; }
		[StringLength(50)]
		public string TeamTitle { get; set; }
		public string TeamAbout { get; set; }
		[StringLength(50)]
		public string StatisticTitle { get; set; }
		public string StatisticAbout { get; set; }
	}
}
