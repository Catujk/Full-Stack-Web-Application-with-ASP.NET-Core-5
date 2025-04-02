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
    public class WriterUserManager : IWriterUserService
    {
        IWriterUserDAL _writerUserDAL;

        public WriterUserManager(IWriterUserDAL writerUserDAL)
        {
            _writerUserDAL = writerUserDAL;
        }

        public void TAdd(WriterUser entity)
        {
            _writerUserDAL.Insert(entity);
        }

        public void TDelete(WriterUser entity)
        {
            _writerUserDAL.Delete(entity);

        }

        public WriterUser TGetByID(int id)
        {
            return _writerUserDAL.GetById(id);
        }

        public List<WriterUser> TGetList()
        {
            return _writerUserDAL.GetList();
        }

        public List<WriterUser> TGetListWithFilter(string filter)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(WriterUser entity)
        {
            _writerUserDAL.Update(entity);
        }
    }
}
