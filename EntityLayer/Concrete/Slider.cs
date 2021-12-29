using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Slider : IEntity
	{
		[Key]
		public int SliderId { get; set; }
		[StringLength(50)]
		public string Image { get; set; }
		[StringLength(50)]
		public string Title { get; set; }
		[StringLength(50)]
		public string ButonHref { get; set; }
		[StringLength(50)]
		public string ButonTitle { get; set; }
		public string Content { get; set; }
		public bool Status { get; set; }
		public DateTime SliderAddDate { get; set; }
	}
}
