using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IMessageService
	{
		List<Message> GetAll();
		List<Message> GetMessageById(int id);
		List<Message> GetInboxMessage(string email);
		List<Message> GetSendboxMessage(string email);
		Message GetById(int id);
		void MessageAdd(Message message);
		void MessageUpdate(Message message);
		void MessageDelete(Message message);

	}
}
