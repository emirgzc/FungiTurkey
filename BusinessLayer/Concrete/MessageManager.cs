using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class MessageManager : IMessageService
	{
		IMessageDal _messageDal;

		public MessageManager(IMessageDal messageDal)
		{
			_messageDal = messageDal;
		}

		public List<Message> GetAll()
		{
			return _messageDal.GetAll();
		}

		public Message GetById(int id)
		{
			return _messageDal.Get(x => x.MessageId == id);
		}

		public List<Message> GetInboxMessage(string email)
		{
			return _messageDal.GetAll(x => x.ReceiverMail == email).OrderByDescending(z => z.MessageDate).ToList();
		}

		public List<Message> GetMessageById(int id)
		{
			return _messageDal.GetAll(x=>x.MessageId==id);
		}

		public List<Message> GetSendboxMessage(string email)
		{
			return _messageDal.GetAll(x => x.SenderMail == email).OrderByDescending(z => z.MessageDate).ToList();
		}

		public void MessageAdd(Message message)
		{
			_messageDal.Add(message);
		}

		public void MessageDelete(Message message)
		{
			_messageDal.Delete(message);
		}

		public void MessageUpdate(Message message)
		{
			_messageDal.Update(message);
		}
	}
}
