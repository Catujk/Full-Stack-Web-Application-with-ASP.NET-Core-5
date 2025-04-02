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
    public class AnnouncementManager : IAnnouncementService
    {
        IAnnouncementDAL _announcementDAL;

        public AnnouncementManager(IAnnouncementDAL announcementDAL)
        {
            _announcementDAL = announcementDAL;
        }

        public void TAdd(Announcement entity)
        {
            _announcementDAL.Insert(entity);
        }

        public void TDelete(Announcement entity)
        {
            _announcementDAL.Delete(entity);
        }

        public Announcement TGetByID(int id)
        {
            return _announcementDAL.GetById(id);
        }

        public List<Announcement> TGetList()
        {
            return _announcementDAL.GetList();
        }

        public List<Announcement> TGetListWithFilter(string filter)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Announcement entity)
        {
            _announcementDAL.Update(entity);
        }
    }
}
