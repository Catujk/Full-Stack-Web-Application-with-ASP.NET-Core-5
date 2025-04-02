using BusinessLayer.Absract;
using DataAccessLayer.Absract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterMessageManager : IWriterMessageService
    {
        IWriterMessageDAL _writerMessageDAL;
        public WriterMessageManager(IWriterMessageDAL writerMessageDAL)
        {
            _writerMessageDAL = writerMessageDAL;
        }

        public List<WriterMessage> GetListRecevierMessages(string p)
        {
            return _writerMessageDAL.GetByFilter(x => x.ReceiverMail == p);
        }

        public List<WriterMessage> GetListSenderMessages(string p)
        {
            return _writerMessageDAL.GetByFilter(x => x.SenderMail == p);
        }

        public void TAdd(WriterMessage entity)
        {
            _writerMessageDAL.Insert(entity);
        }

        public void TDelete(WriterMessage entity)
        {
            _writerMessageDAL.Delete(entity);
        }

        public WriterMessage TGetByID(int id)
        {
            return _writerMessageDAL.GetById(id);
        }

        public List<WriterMessage> TGetList()
        {
            return _writerMessageDAL.GetList();
        }

        public List<WriterMessage> TGetListWithFilter(string filter)
        {
            throw new NotImplementedException();
        }

        //public List<WriterMessage> TGetListWithFilter(string filter)
        //{
        //    return _writerMessageDAL.GetByFilter(x=>x.ReceiverMail == filter);
        //}

        public void TUpdate(WriterMessage entity)
        {
            _writerMessageDAL.Update(entity);
        }
    }
}
