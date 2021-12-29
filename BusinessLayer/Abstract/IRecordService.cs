using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IRecordService
	{
        List<Record> GetAll();
        List<Record> GetRecordByID(int id);
        List<Record> GetListRecordByMember(int id);
        List<Record> GetListRecordToActivityId(int id);
        Record GetByID(int id);
        void RecordAdd(Record record);
        void RecordUpdate(Record record);
        void RecordDelete(Record record);
    }
}
