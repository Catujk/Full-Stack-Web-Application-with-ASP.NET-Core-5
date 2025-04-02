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
    public class MessageManager : IMessageService
    {
        IMessageDAL _messageDAL;
        public MessageManager(IMessageDAL messageDAL)
        {
            _messageDAL = messageDAL;
        }

        public void TAdd(Message entity)
        {
            _messageDAL.Insert(entity);
        }

        public void TDelete(Message entity)
        {
            _messageDAL.Delete(entity);
        }

        public Message TGetByID(int id)
        {
            return _messageDAL.GetById(id);
        }

        public List<Message> TGetList()
        {
            return _messageDAL.GetList();
        }

        public List<Message> TGetListWithFilter(string filter)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message entity)
        {
            _messageDAL.Update(entity);
        }
    }
}
