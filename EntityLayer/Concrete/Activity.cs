using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Activity : IEntity
	{
		[Key]
		public int ActId { get; set; }
		[StringLength(50)]
		public string Title { get; set; }
		public string Content { get; set; }
		[StringLength(50)]
		public string Image { get; set; }
		[StringLength(50)]
		public string StartDate { get; set; }
		[StringLength(50)]
		public string FinishDate { get; set; }
		[StringLength(50)]
		public string LastRecordDate { get; set; }
		public decimal Price { get; set; }
		[StringLength(50)]
		public string Director { get; set; }
		public int Quota { get; set; }
		public bool StatusAct { get; set; }
		public bool StatusRecord { get; set; }
		public ICollection<Record> Records { get; set; }
		public ICollection<ActivityComment> ActivityComments { get; set; }
	}
}
