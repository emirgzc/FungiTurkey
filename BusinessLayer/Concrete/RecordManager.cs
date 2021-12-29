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
	public class RecordManager : IRecordService
	{
		IRecordDal _recordDal;

		public RecordManager(IRecordDal recordDal)
		{
			_recordDal = recordDal;
		}
		public List<Record> GetAll()
		{
			return _recordDal.GetAll();
		}

		public Record GetByID(int id)
		{
			return _recordDal.Get(x => x.RecordId == id);
		}

		public List<Record> GetListRecordByMember(int id)
		{
			return _recordDal.GetAll(x=>x.MemberId==id);
		}

		public List<Record> GetListRecordToActivityId(int id)
		{
			return _recordDal.GetAll(x => x.ActId == id).OrderByDescending(z => z.RecordDate).ToList();
		}

		public List<Record> GetRecordByID(int id)
		{
			return _recordDal.GetAll(x => x.RecordId == id);
		}

		public void RecordAdd(Record record)
		{
			_recordDal.Add(record);
		}

		public void RecordDelete(Record record)
		{
			_recordDal.Delete(record);
		}

		public void RecordUpdate(Record record)
		{
			_recordDal.Update(record);
		}
	}
}
