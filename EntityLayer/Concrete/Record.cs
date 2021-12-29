﻿using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Record:IEntity
	{
		[Key]
		public int RecordId { get; set; }
		[StringLength(50)]
		public string Name { get; set; }
		[StringLength(50)]
		public string Surname { get; set; }
		[StringLength(50)]
		public string Email { get; set; }
		[StringLength(50)]
		public string Phone { get; set; }
		public int PeopleNumber { get; set; }
		public DateTime RecordDate { get; set; }
		public bool Status { get; set; }
		public bool StatusPrice { get; set; }
		public int ActId { get; set; }
		public virtual Activity Activity { get; set; }
		public int MemberId { get; set; }
		public virtual Member Member { get; set; }
	}
}
