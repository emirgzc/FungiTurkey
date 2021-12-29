﻿using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Galery : IEntity
	{
		[Key]
		public int PhotoId { get; set; }
		[StringLength(50)]
		public string Title { get; set; }
		[StringLength(50)]
		public string Image { get; set; }
		public bool Status { get; set; }
	}
}
