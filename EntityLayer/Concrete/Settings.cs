using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Settings : IEntity
	{
		[Key]
		public int SetId { get; set; }
		[StringLength(70)]
		public string Address { get; set; }
		[StringLength(70)]
		public string Phone { get; set; }
		[StringLength(70)]
		public string Email { get; set; }
		[StringLength(70)]
		public string DirectorName { get; set; }
		[StringLength(70)]
		public string Facebook { get; set; }
		[StringLength(70)]
		public string Twitter { get; set; }
		[StringLength(70)]
		public string Linkedin { get; set; }
		[StringLength(70)]
		public string Instagram { get; set; }
		[StringLength(70)]
		public string Youtube { get; set; }
		[StringLength(700)]
		public string Map { get; set; }
		[StringLength(50)]
		public string DeveloperName { get; set; }
		[StringLength(100)]
		public string CopyrightSite { get; set; }
		public string RizaMetni { get; set; }
	}
}
