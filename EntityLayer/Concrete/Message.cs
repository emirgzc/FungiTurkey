using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Message:IEntity
	{
		[Key]
		public int MessageId { get; set; }
		[StringLength(50)]
		public string SenderMail { get; set; }
		[StringLength(50)]
		public string ReceiverMail { get; set; }
		[StringLength(50)]
		public string Subject { get; set; }
		public string MessageCont { get; set; }
		public DateTime MessageDate { get; set; }

	}
}
